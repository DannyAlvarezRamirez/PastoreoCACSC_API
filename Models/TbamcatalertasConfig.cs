using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamcatalertasConfig
    {
        public decimal AlertaId { get; set; }
        public decimal UsuarioId { get; set; }
        public string TipoAlerta { get; set; } = null!;
        public string Configuracion { get; set; } = null!;

        //public virtual Tbammaeusuario Usuario { get; set; } = null!;
    }
}
