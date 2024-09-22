using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdettratamiento
    {
        public Tbamdettratamiento()
        {
            Tbammaeganados = new HashSet<Tbammaeganado>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal TratamientoId { get; set; }

        public virtual ICollection<Tbammaeganado> Tbammaeganados { get; set; }
    }
}
