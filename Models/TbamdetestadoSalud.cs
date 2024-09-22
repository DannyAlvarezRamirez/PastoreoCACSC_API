using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamdetestadoSalud
    {
        public TbamdetestadoSalud()
        {
            Tbammaeganados = new HashSet<Tbammaeganado>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal EstadoSaludId { get; set; }

        public virtual ICollection<Tbammaeganado> Tbammaeganados { get; set; }
    }
}
