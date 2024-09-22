using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetrecurso
    {
        public int RecursoId { get; set; }
        public decimal? SuministroId { get; set; }
        public string? TipoRecurso { get; set; }
        public string? Detalles { get; set; }
        public decimal? Cantidad { get; set; }

        public virtual Tbammaesuministro? Suministro { get; set; }
    }
}
