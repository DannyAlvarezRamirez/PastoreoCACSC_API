using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetraza
    {
        public Tbamdetraza()
        {
            Tbammaeganados = new HashSet<Tbammaeganado>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal RazaId { get; set; }

        public virtual ICollection<Tbammaeganado> Tbammaeganados { get; set; }
    }
}
