using Microsoft.AspNetCore.Mvc;
using PastoreoCACSC_API.Classes;
using PastoreoCACSC_API.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;
    private readonly PastoreoContext _context;
    private readonly PasswordService _passwordService;

    public AuthController(JwtTokenService jwtTokenService, PastoreoContext context, PasswordService passwordService)
    {
        _jwtTokenService = jwtTokenService;
        _context = context;
        _passwordService = passwordService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        var user = _context.Tbammaeusuarios.SingleOrDefault(u => u.Username == model.Username);
        if (user == null || !_passwordService.VerifyPassword(model.Password, user.PasswordHash))
        {
            return Unauthorized();
        }

        var token = _jwtTokenService.GenerateToken(user.Username);
        return Ok(new { Token = token });
    }
}
