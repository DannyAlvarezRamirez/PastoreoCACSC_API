using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamcatalertasConfiguracion
    {
        public decimal AlertaId { get; set; }
        public decimal UsuarioId { get; set; }
        public string TipoAlerta { get; set; } = null!;
        public string Configuracion { get; set; } = null!;
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Tbammaeusuario Usuario { get; set; } = null!;
    }
}
