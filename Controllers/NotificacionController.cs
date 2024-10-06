using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PastoreoCACSC_API.Models;
using PastoreoCACSC_API.Classes;
using System.Data;
using Microsoft.Data.SqlClient;

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
                // Convert the list of user IDs to a DataTable for the TVP
                var usuarioIdsTable = new DataTable();
                usuarioIdsTable.Columns.Add("UsuarioId", typeof(int));

                // Add values to the table
                if (newNotificacion.UsuarioIds != null)
                {
                    foreach (var usuarioDetail in newNotificacion.UsuarioIds)
                    {
                        if (usuarioDetail.UsuarioId.HasValue) // Ensure UsuarioId is not null
                        {
                            usuarioIdsTable.Rows.Add((int)usuarioDetail.UsuarioId.Value);
                        }
                    }
                }

                // Define parameters including the table-valued parameter for UsuarioIds
                var parameters = new[]
                {
                    new SqlParameter("@De", SqlDbType.NVarChar) { Value = newNotificacion.De },
                    new SqlParameter("@Asunto", SqlDbType.NVarChar) { Value = newNotificacion.Asunto },
                    new SqlParameter("@Mensaje", SqlDbType.NVarChar) { Value = newNotificacion.Mensaje },
                    new SqlParameter("@FechaCreacion", SqlDbType.DateTime2) { Value = newNotificacion.FechaCreacion ?? DateTime.Now },
                    new SqlParameter("@AlertConfig", SqlDbType.NVarChar) { Value = newNotificacion.AlertConfig },
                    new SqlParameter("@Prioridad", SqlDbType.NVarChar) { Value = newNotificacion.Prioridad },
                    new SqlParameter("@Suscripcion", SqlDbType.NVarChar) { Value = newNotificacion.Suscripcion },
                    new SqlParameter("@CreadoPor", SqlDbType.NVarChar) { Value = newNotificacion.CreadoPor },
                    new SqlParameter
                    {
                        ParameterName = "@UsuarioIds",
                        SqlDbType = SqlDbType.Structured,
                        TypeName = "dbo.UsuarioIdTable",  // Use the table-valued parameter type
                        Value = usuarioIdsTable
                    }
                };

                // Execute the stored procedure to insert the notification and its recipients
                _context.Database.ExecuteSqlRaw("EXEC SPAMINNotificacion @De, @Asunto, @Mensaje, @FechaCreacion, @AlertConfig, @Prioridad, @Suscripcion, @CreadoPor, @UsuarioIds", parameters);

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

                var usuarioIdsTable = new DataTable();
                usuarioIdsTable.Columns.Add("UsuarioId", typeof(int));

                // Add values to the table
                if (updatedNotificacion.UsuarioIds != null)
                {
                    foreach (var usuarioDetail in updatedNotificacion.UsuarioIds)
                    {
                        if (usuarioDetail.UsuarioId.HasValue) // Ensure UsuarioId is not null
                        {
                            usuarioIdsTable.Rows.Add((int)usuarioDetail.UsuarioId.Value);
                        }
                    }
                }

                // Pass the table-valued parameter
                var parameters = new[]
                {
                    new SqlParameter("@Id", SqlDbType.Decimal) { Value = id },
                    new SqlParameter("@De", SqlDbType.NVarChar) { Value = updatedNotificacion.De },
                    new SqlParameter("@Asunto", SqlDbType.NVarChar) { Value = updatedNotificacion.Asunto },
                    new SqlParameter("@Mensaje", SqlDbType.NVarChar) { Value = updatedNotificacion.Mensaje },
                    new SqlParameter("@FechaModif", SqlDbType.DateTime2) { Value = updatedNotificacion.FechaModif ?? DateTime.Now },
                    new SqlParameter("@AlertConfig", SqlDbType.NVarChar) { Value = updatedNotificacion.AlertConfig },
                    new SqlParameter("@Prioridad", SqlDbType.NVarChar) { Value = updatedNotificacion.Prioridad },
                    new SqlParameter("@Suscripcion", SqlDbType.NVarChar) { Value = updatedNotificacion.Suscripcion },
                    new SqlParameter("@ModificadoPor", SqlDbType.NVarChar) { Value = updatedNotificacion.ModificadoPor },
                    new SqlParameter
                    {
                        ParameterName = "@UsuarioIds",
                        SqlDbType = SqlDbType.Structured,
                        TypeName = "dbo.UsuarioIdTable",
                        Value = usuarioIdsTable
                    }
                };

                // Execute the stored procedure
                _context.Database.ExecuteSqlRaw("EXEC SPAMUPNotificacion @Id, @De, @Asunto, @Mensaje, @FechaModif, @AlertConfig, @Prioridad, @Suscripcion, @ModificadoPor, @UsuarioIds", parameters);

                // Retrieve the updated notification details
                var updatedNotification = _context.Tbammaenotificacions.FirstOrDefault(n => n.Id == id);

                // Manually retrieve the related users
                var relatedUsers = _context.TbamrelnotifUsus
                    .Where(nu => nu.NotificacionId == id)
                    .Select(nu => nu.UsuarioId)
                    .ToList();

                // Add both notification and related users to the response
                response.Data.Add(new
                {
                    UpdatedNotification = updatedNotification,
                    RelatedUsers = relatedUsers
                });

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
