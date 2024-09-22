using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetconsumible
    {
        public int ConsumibleId { get; set; }
        public decimal? SuministroId { get; set; }
        public string? TipoConsumible { get; set; }
        public string? Detalles { get; set; }

        public virtual Tbammaesuministro? Suministro { get; set; }
    }
}
