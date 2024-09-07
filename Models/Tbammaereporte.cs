using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbammaereporte
    {
        public decimal ReporteId { get; set; }
        public decimal UsuarioId { get; set; }
        public string TipoReporte { get; set; } = null!;
        public DateTime FechaGeneracion { get; set; }
        public string? ParametrosSeleccionados { get; set; }
        public byte[]? ReporteGenerado { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Tbammaeusuario Usuario { get; set; } = null!;
    }
}
