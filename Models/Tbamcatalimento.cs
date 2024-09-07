using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamcatalimento
    {
        public Tbamcatalimento()
        {
            Tbamdetsuministros = new HashSet<Tbamdetsuministro>();
        }

        public decimal AlimentoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Notas { get; set; }
        public decimal? Cantidad { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Tbamdetsuministro> Tbamdetsuministros { get; set; }
    }
}
