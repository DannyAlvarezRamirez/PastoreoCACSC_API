using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamdettipoPasto
    {
        public TbamdettipoPasto()
        {
            Tbammaeapartamentos = new HashSet<Tbammaeapartamento>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal TipoPastoId { get; set; }

        public virtual ICollection<Tbammaeapartamento> Tbammaeapartamentos { get; set; }
    }
}
