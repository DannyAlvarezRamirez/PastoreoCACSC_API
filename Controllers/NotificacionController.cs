using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PastoreoCACSC_API.Models;
using PastoreoCACSC_API.Classes;

namespace PastoreoCACSC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionController : ControllerBase
    {
        private readonly PastoreoContext _context;

        public NotificacionController(PastoreoContext context)
        {
            _context = context;
        }

        // GET: api/Notificacion/getByUser/{usuarioId}
        [HttpGet("getByUser/{usuarioId}")]
        public IActionResult GetNotificacionesByUser(decimal usuarioId)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure to retrieve notifications by user ID
                var notificaciones = _context.NotificacionResult
                    .FromSqlInterpolated($"EXEC dbo.SPAMSLNotificacion @UsuarioId = {usuarioId}")
                    .ToList();

                // If no notifications are found
                if (notificaciones.Count == 0)
                {
                    response.SetResponse(true, ExitCode.Success, "No se encontraron notificaciones para este usuario.");
                }
                else
                {
                    response.Data.AddRange(notificaciones);
                    response.SetResponse(true, ExitCode.Success, "Notificaciones recuperadas exitosamente.");
                }
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error recuperando las notificaciones.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // POST: api/Notificacion/create
        [HttpPost("create")]
        public IActionResult CreateNotificacion([FromBody] NotificacionCreateRequest newNotificacion)
        {
            var response = new ApiResponse();

            try
            {
                // Convert the list of user IDs to a comma-separated string
                var usuarioIds = string.Empty; // string.Join(",", newNotificacion.UsuarioIds);

                // Execute the stored procedure to insert the notification and its recipients
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMINNotificacion 
                        @De = {newNotificacion.De},
                        @Asunto = {newNotificacion.Asunto},
                        @Mensaje = {newNotificacion.Mensaje},
                        @FechaCreacion = {newNotificacion.FechaCreacion},
                        @AlertConfig = {newNotificacion.AlertConfig},
                        @Prioridad = {newNotificacion.Prioridad},
                        @Suscripcion = {newNotificacion.Suscripcion},
                        @CreadoPor = {newNotificacion.CreadoPor},
                        @UsuarioIds = {usuarioIds}
                ");

                // Set success response after the insert operation
                response.SetResponse(true, ExitCode.Success, "Notificación creada exitosamente.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the creation process
                response.SetResponse(false, ExitCode.ErrorServer, "Error creando la notificación.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // PUT: api/Notificacion/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult UpdateNotificacion(decimal id, [FromBody] NotificacionUpdateRequest updatedNotificacion)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the notification exists before updating
                var notificacionExists = _context.Tbammaenotificacions.Any(n => n.Id == id);
                if (!notificacionExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Notificación no encontrada.");
                    return NotFound(response);
                }

                // Convert the list of user IDs to a comma-separated string
                var usuarioIds = string.Empty; //string.Join(",", updatedNotificacion.UsuarioIds);

                // Execute the stored procedure to update the notification and its related users
                _context.Database.ExecuteSqlInterpolated($@"
            EXEC dbo.SPAMUPNotificacion 
                @Id = {id},
                @De = {updatedNotificacion.De},
                @Asunto = {updatedNotificacion.Asunto},
                @Mensaje = {updatedNotificacion.Mensaje},
                @FechaModif = {updatedNotificacion.FechaModif},
                @AlertConfig = {updatedNotificacion.AlertConfig},
                @Prioridad = {updatedNotificacion.Prioridad},
                @Suscripcion = {updatedNotificacion.Suscripcion},
                @ModificadoPor = {updatedNotificacion.ModificadoPor},
                @UsuarioIds = {usuarioIds}
        ");

                // Set success response after updating
                response.SetResponse(true, ExitCode.Success, "Notificación actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the update process
                response.SetResponse(false, ExitCode.ErrorServer, "Error actualizando la notificación.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // DELETE: api/Notificacion/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteNotificacion(decimal id)
        {
            var response = new ApiResponse();

            try
            {
                // Check if notification exists
                var notificacionExists = _context.Tbammaenotificacions.Any(n => n.Id == id);
                if (!notificacionExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Notificación no encontrada.");
                    return NotFound(response);
                }

                // Execute stored procedure to delete notification
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMDLNotificacion @Id = {id}
                ");

                // Set success response after deletion
                response.SetResponse(true, ExitCode.Success, "Notificación eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error eliminando la notificación.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // GET: api/Notificacion/userDropdown
        [HttpGet("userDropdown")]
        public IActionResult GetUserDropdown()
        {
            var response = new ApiResponse();

            try
            {
                // Retrieve all users for the dropdown
                var usuarios = _context.Tbammaeusuarios
                    .Select(u => new { u.Id, u.Username })
                    .ToList();

                response.Data.Add(new { Usuarios = usuarios });
                response.SetResponse(true, ExitCode.Success, "Usuarios recuperados exitosamente.");
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error recuperando los usuarios.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }
    }
}
