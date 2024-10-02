namespace PastoreoCACSC_API.Models
{
    public class GanadoSearchResult
    {
        public decimal GanadoId { get; set; }
        public decimal RazaId { get; set; }
        public decimal? Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal TratamientoId { get; set; }
        public decimal ProductividadId { get; set; }
        public DateTime UltimoChequeo { get; set; }
        public decimal EstadoSaludId { get; set; }
        public int? Edad { get; set; }
        public decimal SexoId { get; set; }
    }
}
