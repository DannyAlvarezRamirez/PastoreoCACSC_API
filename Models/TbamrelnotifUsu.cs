using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamrelnotifUsu
    {
        public decimal Id { get; set; }
        public decimal? NotificacionId { get; set; }
        public decimal? UsuarioId { get; set; }

        //public virtual Tbammaeapartamento Apartamento { get; set; } = null!;
    }
}
