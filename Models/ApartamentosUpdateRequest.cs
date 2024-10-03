namespace PastoreoCACSC_API.Models
{
    public class ApartamentosUpdateRequest
    {
        public decimal? TamanoArea { get; set; }
        public decimal? TipoPastoId { get; set; }
        public decimal? TipoTierraId { get; set; }
        public decimal? DrenajeId { get; set; }
        public decimal? ExpoSolarId { get; set; }
        public decimal? CapaCargaId { get; set; }
        public decimal? FrecuenciaUsoId { get; set; }
        public string ModificadoPor { get; set; }  // The user who modifies the record
    }
}
