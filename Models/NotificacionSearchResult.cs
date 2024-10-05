namespace PastoreoCACSC_API.Models
{
    public class NotificacionSearchResult
    {
        public decimal Id { get; set; }          // Notification ID
        public string? De { get; set; }           // Sender of the notification (e.g., Admin)
        public string? Asunto { get; set; }       // Subject of the notification
        public string? Mensaje { get; set; }      // Notification message
        public DateTime? Fecha { get; set; }      // Date of the notification
        public string? AlertConfig { get; set; }  // Alert configuration (e.g., daily, weekly, monthly)
        public string? Prioridad { get; set; }    // Priority (e.g., alta, media, baja)
        public string? Suscripcion { get; set; }  // Subscription status (e.g., encender, apagar)
        public string? CreadoPor { get; set; }    // Created by user
        public DateTime? FechaCreacion { get; set; } // Creation date of the notification
    }
}
