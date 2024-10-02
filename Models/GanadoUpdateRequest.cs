namespace PastoreoCACSC_API.Models
{
    public class GanadoUpdateRequest
    {
        public decimal? RazaId { get; set; }
        public decimal? Peso { get; set; }
        public decimal? SexoId { get; set; }
        public int? Edad { get; set; }
        public decimal? EstadoSaludId { get; set; }
        public DateTime? UltimoChequeo { get; set; }
        public decimal? ProductividadId { get; set; }
        public decimal? TratamientoId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? ModificadoPor { get; set; }  // Required field for logging the user who modified the record
    }
}
