namespace PastoreoCACSC_API.Models
{
    public class NotificacionCreateRequest
    {
        public string? De { get; set; }         // Who sends the notification (e.g., Admin)
        public string? Asunto { get; set; }     // The subject of the notification
        public string? Mensaje { get; set; }    // The body of the message
        public DateTime? Fecha { get; set; }    // The date of the notification
        public string? AlertConfig { get; set; } // Alert configuration (e.g., "day", "week", "month")
        public string? Prioridad { get; set; }  // The priority of the notification (e.g., "alta", "media", "baja")
        public string? Suscripcion { get; set; } // Subscription setting (e.g., "encender", "apagar")
        public DateTime? FechaCreacion { get; set; }    
        public string? CreadoPor { get; set; }  // Who created the notification

        // User-Notification relationship
        public List<UsuarioNotificationDetail>? Usuarios { get; set; } = new List<UsuarioNotificationDetail>();
    }
}
