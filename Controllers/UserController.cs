using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PastoreoCACSC_API.Classes;
using PastoreoCACSC_API.Models;

namespace PastoreoCACSC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PastoreoContext _context;

        public UserController(PastoreoContext context)
        {
            _context = context;
        }

        // POST: api/User/search
        [HttpPost("search")]
        public IActionResult SearchUser([FromBody] UserFilterRequest filters)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure with the provided filters
                var userList = _context.SpamslUsuarios
                    .FromSqlInterpolated(
                        $"EXEC dbo.SPAMSLUsuarios @FullName = {filters.FullName}, @Email = {filters.Email}, @RolId = {filters.RolId}, @AccountStatus = {filters.AccountStatus}"
                    )
                    .ToList();

                // If no results, set a "no results found" response
                if (userList.Count == 0)
                {
                    response.SetResponse(true, ExitCode.Success, "No se encontraron resultados.");
                }
                else
                {
                    response.Data.AddRange(userList);
                    response.SetResponse(true, ExitCode.Success, "Resultados de búsqueda de usuarios obtenidos correctamente.");
                }
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error retrieving user search results.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }


        // POST: api/User/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] UserCreateRequest newUser)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure to insert a new User record
                var id = _context.Database
                    .ExecuteSqlInterpolated($@"
                        EXEC dbo.SPAMINUsuarios 
                            @Username = {newUser.Username},
                            @PasswordHash = {newUser.PasswordHash},
                            @FullName = {newUser.FullName},
                            @Email = {newUser.Email},
                            @Phone = {newUser.Phone},
                            @RolId = {newUser.RolId}, 
                            @CreadoPor = {newUser.CreadoPor}
                    ");

                // Set success response after the update
                response.SetResponse(true, ExitCode.Success, "User created successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the creation process
                response.SetResponse(false, ExitCode.ErrorServer, "Error creating User.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }


        // PUT: api/User/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult Update(decimal id, [FromBody] UserUpdateRequest updatedUser)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the User exists before attempting to update
                var userExists = _context.Tbammaeusuarios.Any(u => u.Id == id);
                if (!userExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "User not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to update the User record
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMUPUsuarios 
                        @Id = {id},
                        @FullName = {updatedUser.FullName}, 
                        @Email = {updatedUser.Email},
                        @RolId = {updatedUser.RolId}, 
                        @ModificadoPor = {updatedUser.ModificadoPor}
                ");

                // Set success response after the update
                response.SetResponse(true, ExitCode.Success, "User updated successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the update
                response.SetResponse(false, ExitCode.ErrorServer, "Error updating User.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // DELETE: api/User/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(decimal id)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the User exists before attempting to delete
                var userExists = _context.Tbammaeusuarios.Any(u => u.Id == id);
                if (!userExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "User not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to delete the User
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMDLUsuarios @Id = {id}
                ");

                // Set the success response after deletion
                response.SetResponse(true, ExitCode.Success, "User deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the delete operation
                response.SetResponse(false, ExitCode.ErrorServer, "Error deleting User.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // GET: api/User/dropdownsUser
        [HttpGet("dropdownsUser")]
        public IActionResult GetDropdownOptions()
        {
            var response = new ApiResponse();

            try
            {
                // Assuming there are lookup tables or hardcoded values for dropdowns
                var roles = _context.Tbamdetroles
                    .Select(r => new { r.Id, r.Descripcion })
                    .ToList();

                response.Data.Add(new
                {
                    Roles = roles
                });

                response.SetResponse(true, ExitCode.Success, "Dropdown options retrieved successfully.");
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error retrieving dropdown options.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }
    }
}
