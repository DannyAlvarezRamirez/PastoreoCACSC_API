using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetdrenaje
    {
        public Tbamdetdrenaje()
        {
            Tbammaeapartamentos = new HashSet<Tbammaeapartamento>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal DrenajeId { get; set; }

        public virtual ICollection<Tbammaeapartamento> Tbammaeapartamentos { get; set; }
    }
}
