namespace PastoreoCACSC_API.Models
{
    public class NotificacionResult
    {
        public decimal Id { get; set; }          // The unique ID of the notification
        public string? De { get; set; }           // Who sent the notification (e.g., Admin)
        public string? Asunto { get; set; }       // The subject of the notification
        public string? Mensaje { get; set; }      // The body of the message
        public DateTime? Fecha { get; set; }      // The date of the notification
        public string? AlertConfig { get; set; }  // Alert configuration (e.g., "day", "week", "month")
        public string? Prioridad { get; set; }    // The priority of the notification (e.g., "alta", "media", "baja")
        public string? Suscripcion { get; set; }  // Subscription setting (e.g., "encender", "apagar")
        public string? CreadoPor { get; set; }    // Who created the notification
        public DateTime? FechaCreacion { get; set; } // When the notification was created

        // User-Notification relationship
        public List<UsuarioNotificationDetail>? Usuarios { get; set; } = new List<UsuarioNotificationDetail>(); 
    }

    public class UsuarioNotificationDetail
    {
        public decimal? UsuarioId { get; set; }   // The unique ID of the user
        public string? Username { get; set; }     // The username of the user receiving the notification
    }
}
