using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbammaenotificacion
    {
        public decimal NotificacionId { get; set; }
        public decimal UsuarioId { get; set; }
        public string TipoNotificacion { get; set; } = null!;
        public string Mensaje { get; set; } = null!;
        public DateTime FechaEnvio { get; set; }
        public string? Prioridad { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModif { get; set; }

        public virtual Tbammaeusuario Usuario { get; set; } = null!;
    }
}
