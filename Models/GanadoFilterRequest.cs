namespace PastoreoCACSC_API.Models
{
    public class GanadoFilterRequest
    {
        public int? RazaId { get; set; }
        public decimal? Peso { get; set; }
        public int? SexoId { get; set; }
        public int? Edad { get; set; }
        public int? EstadoSaludId { get; set; }
        public DateTime? FechaChequeo { get; set; }
        public int? ProductividadId { get; set; }
        public int? TratamientosId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
