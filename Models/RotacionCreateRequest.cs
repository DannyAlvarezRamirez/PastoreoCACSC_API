namespace PastoreoCACSC_API.Models
{
    public class RotacionCreateRequest
    {
        public decimal? ApartamentoId { get; set; }
        public DateTime? TiempoInicio { get; set; }
        public DateTime? TiempoFin { get; set; }
        public string? Temporada { get; set; }
        public int? CantGanadoAct { get; set; }
        public int? CantMaxRec { get; set; }
        public decimal? TipoGanadoId { get; set; }
        public string? RegistroEventos { get; set; }
        public decimal? EficPast { get; set; }
        public string? Observaciones { get; set; }
        public string? CreadoPor { get; set; }
    }
}
