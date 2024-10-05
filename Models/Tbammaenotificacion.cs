using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbammaenotificacion
    {
        public decimal Id { get; set; }
        public string De { get; set; } = null!;
        public string Asunto { get; set; } = null!;
        public string Mensaje { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string? AlertConfig { get; set; }
        public string? Prioridad { get; set; }
        public string? Suscripcion { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModif { get; set; }

        //public virtual Tbammaeusuario Usuario { get; set; } = null!;
    }
}
