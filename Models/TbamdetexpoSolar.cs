using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamdetexpoSolar
    {
        public TbamdetexpoSolar()
        {
            Tbammaeapartamentos = new HashSet<Tbammaeapartamento>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal ExpoSolarId { get; set; }

        public virtual ICollection<Tbammaeapartamento> Tbammaeapartamentos { get; set; }
    }
}
