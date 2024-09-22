using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetsexo
    {
        public Tbamdetsexo()
        {
            Tbammaeganados = new HashSet<Tbammaeganado>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal SexoId { get; set; }

        public virtual ICollection<Tbammaeganado> Tbammaeganados { get; set; }
    }
}
