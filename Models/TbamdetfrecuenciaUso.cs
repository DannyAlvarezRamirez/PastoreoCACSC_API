using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamdetfrecuenciaUso
    {
        public TbamdetfrecuenciaUso()
        {
            Tbammaeapartamentos = new HashSet<Tbammaeapartamento>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal FrecuenciaUsoId { get; set; }

        public virtual ICollection<Tbammaeapartamento> Tbammaeapartamentos { get; set; }
    }
}
