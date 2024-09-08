using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PastoreoCACSC_API.Models;
using PastoreoCACSC_API.Classes;

namespace PastoreoCACSC_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PastoreoContext _context;
        private readonly IPasswordService _passwordService;

        public UserController(PastoreoContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Tbammaeusuarios.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Tbammaeusuarios.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] Tbammaeusuario user)
        {
            // Check if the username already exists
            var existingUser = _context.Tbammaeusuarios.SingleOrDefault(u => u.Username == user.Username);
            if (existingUser != null)
            {
                return BadRequest("Username is already taken.");
            }

            // Check if a password is provided
            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                return BadRequest("Password is required.");
            }

            // Hash the password before saving to the database
            var hashedPassword = _passwordService.HashPassword(user.PasswordHash);
            user.PasswordHash = hashedPassword;

            // Set any other required default values if necessary
            user.FechaCreacion = DateTime.UtcNow;
            user.CreadoPor = "System"; // Replace with actual creator info (e.g., the current logged-in user)

            // Save the new user to the database
            _context.Tbammaeusuarios.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }


    }

}
