namespace PastoreoCACSC_API.Models
{
    public class ApartamentosReport
    {
        public decimal ApartamentoId { get; set; }
        public decimal? TamanoArea { get; set; }
        public decimal? TipoPastoId { get; set; }
        public decimal? TipoTierraId { get; set; }
        public decimal? DrenajeId { get; set; }
        public decimal? ExpoSolarId { get; set; }
        public decimal? CapaCargaId { get; set; }
        public decimal? FrecuenciaUsoId { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
