using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class TbamcatcapacidadCarga
    {
        public TbamcatcapacidadCarga()
        {
            Tbamdetapartamentos = new HashSet<Tbamdetapartamento>();
        }

        public decimal CapacidadCargaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Tbamdetapartamento> Tbamdetapartamentos { get; set; }
    }
}
