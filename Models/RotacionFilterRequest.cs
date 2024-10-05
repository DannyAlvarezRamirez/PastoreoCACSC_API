namespace PastoreoCACSC_API.Models
{
    public class RotacionFilterRequest
    {
        public decimal? ApartamentoId { get; set; }
        public DateTime? TiempoInicio { get; set; }
        public DateTime? TiempoFin { get; set; }
        public string? Temporada { get; set; }
        public decimal? TipoGanadoId { get; set; }
    }
}
