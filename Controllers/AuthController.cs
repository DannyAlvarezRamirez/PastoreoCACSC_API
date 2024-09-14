using Microsoft.AspNetCore.Mvc;
using PastoreoCACSC_API.Classes;
using PastoreoCACSC_API.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly PastoreoContext _context;
    private readonly IPasswordService _passwordService;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(PastoreoContext context, IPasswordService passwordService, IJwtTokenService jwtTokenService)
    {
        _context = context;
        _passwordService = passwordService; 
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        var response = new ApiResponse();

        var user = _context.Tbammaeusuarios.SingleOrDefault(u => u.Username == model.Username);
        if (user == null || !_passwordService.VerifyPassword(model.Password, user.PasswordHash) || user.Estado == 0)
        {
            response.SetResponse(false, ExitCode.ErrorUnauthorized, "Invalid username or password or user is inactive");
            return Ok(response);
        }

        // Generate JWT token
        var token = _jwtTokenService.GenerateToken(user.Username);

        // Structure the response
        response.Data.Add(new { User = user, Token = token });
        response.SetResponse(true, ExitCode.Success, "Login successful");

        return Ok(response);

        //testing
        //return Ok("User Authenticated Successfully!");
    }

    [HttpPost("checkEmail")]
    public IActionResult CheckEmail([FromBody] EmailRequest model)
    {
        var response = new ApiResponse();

        // Find user by email
        var user = _context.Tbammaeusuarios.SingleOrDefault(u => u.Email == model.Email);

        // If no user is found
        if (user == null)
        {
            response.SetResponse(false, ExitCode.ErrorNotFound, "El correo electrónico no existe en el sistema. Por favor, contacte a soporte.");
            return Ok(response); // Exit code 1 for email not found
        }

        // If user is found and active
        if (user.Estado == 1) // Assuming '1' means active
        {
            response.Data.Add(new { Username = user.Username });
            response.SetResponse(true, ExitCode.Success, $"Su nombre de usuario es {user.Username}. Redirigiendo a la recuperación de contraseña.");
            return Ok(response); // Exit code 0 for success
        }

        // If user is found but inactive
        if (user.Estado == 0) // Assuming '0' means inactive
        {
            response.Data.Add(new { Username = user.Username, Email = user.Email });
            response.SetResponse(false, ExitCode.ErrorUnauthorized, "El usuario está inactivo. Contacte a soporte.");
            return Ok(response); // Exit code 2 for user inactive
        }

        // Fallback in case of unexpected condition
        response.SetResponse(false, ExitCode.ErrorServer, "Ha ocurrido un problema inesperado.");
        return StatusCode(500, response); // Exit code 3 for server error
    }
}
