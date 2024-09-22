using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetequipo
    {
        public int EquipoId { get; set; }
        public decimal? SuministroId { get; set; }
        public string? TipoEquipo { get; set; }
        public string? Marca { get; set; }
        public string? Estado { get; set; }

        public virtual Tbammaesuministro? Suministro { get; set; }
    }
}
