using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamrelsistUsuario
    {
        public int SystemId { get; set; }
        public decimal UsuarioId { get; set; }
        public decimal EstadoId { get; set; }
        public decimal RolId { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Tbamdetrole Rol { get; set; } = null!;
        public virtual Tbammaeusuario Usuario { get; set; } = null!;
    }
}
