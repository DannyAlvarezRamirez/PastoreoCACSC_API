using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamdetcapaCarga
    {
        public TbamdetcapaCarga()
        {
            Tbammaeapartamentos = new HashSet<Tbammaeapartamento>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal CapaCargaId { get; set; }

        public virtual ICollection<Tbammaeapartamento> Tbammaeapartamentos { get; set; }
    }
}
