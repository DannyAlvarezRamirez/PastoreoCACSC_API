using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetquimico
    {
        public int QuimicoId { get; set; }
        public decimal? SuministroId { get; set; }
        public string? TipoQuimico { get; set; }
        public string? Aplicacion { get; set; }

        public virtual Tbammaesuministro? Suministro { get; set; }
    }
}
