using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamcatcodigo
    {
        public Tbamcatcodigo()
        {
            TbamdetcodigosDets = new HashSet<TbamdetcodigosDet>();
        }

        public decimal CodigoId { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<TbamdetcodigosDet> TbamdetcodigosDets { get; set; }
    }
}
