using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamrelrotacion
    {
        public decimal RotacionId { get; set; }
        public decimal ApartamentoId { get; set; }
        public DateTime TiempoInicio { get; set; }
        public DateTime? TiempoFin { get; set; }
        public string? Temporada { get; set; }
        public int? CantidadGanadoActual { get; set; }
        public int? CantidadMaximaRecomendada { get; set; }
        public string? TipoGanado { get; set; }
        public string? RegistroEventos { get; set; }
        public decimal? EficPast { get; set; }
        public string? Observaciones { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModif { get; set; }

        public virtual Tbammaeapartamento Apartamento { get; set; } = null!;
    }
}
