namespace PastoreoCACSC_API.Models
{
    public class ApartamentosCreateRequest
    {
        public decimal TamanoArea { get; set; }
        public string Descripcion { get; set; }
        public decimal TipoPastoId { get; set; }
        public decimal TipoTierraId { get; set; }
        public decimal DrenajeId { get; set; }
        public decimal ExpoSolarId { get; set; }
        public decimal CapaCargaId { get; set; }
        public decimal FrecuenciaUsoId { get; set; }
        public string CreadoPor { get; set; }  // The user who creates the record
    }
}
