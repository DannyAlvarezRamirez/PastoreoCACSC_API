using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetproductividad
    {
        public Tbamdetproductividad()
        {
            Tbammaeganados = new HashSet<Tbammaeganado>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal ProductividadId { get; set; }

        public virtual ICollection<Tbammaeganado> Tbammaeganados { get; set; }
    }
}
