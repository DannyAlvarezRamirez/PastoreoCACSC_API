namespace PastoreoCACSC_API.Models
{
    public class RotacionSearchResult
    {
        public decimal? Id { get; set; }  // Primary key
        public decimal? ApartamentoId { get; set; }  // Apartment or grazing area
        public DateTime? TiempoInicio { get; set; }  // Start time of the rotation
        public DateTime? TiempoFin { get; set; }  // End time of the rotation
        public string? Temporada { get; set; }  // Season or rotation period
        public int? CantGanadoAct { get; set; }  // Current number of cattle
        public int? CantMaxRec { get; set; }  // Maximum cattle capacity
        public decimal? TipoGanadoId { get; set; }  // Type of livestock (ID)
        public string? RegistroEventos { get; set; }  // Log of events
        public decimal? EficPast { get; set; }  // Efficiency of pasturing
        public string? Observaciones { get; set; }  // Observations or comments
    }
}
