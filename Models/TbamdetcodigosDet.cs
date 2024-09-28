using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamdetcodigosDet
    {
        public decimal CodigoId { get; set; }
        public decimal CodigoDetId { get; set; }
        public string Descripcion { get; set; } = null!;
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModif { get; set; }

        public virtual Tbamcatcodigo Codigo { get; set; } = null!;
    }
}
