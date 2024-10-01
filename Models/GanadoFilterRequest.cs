namespace PastoreoCACSC_API.Models
{
    public class GanadoFilterRequest
    {
        public decimal RazaId { get; set; }
        public decimal Peso { get; set; }
        public decimal SexoId { get; set; }
        public int Edad { get; set; }
        public decimal EstadoSaludId { get; set; }
        public DateTime FechaChequeo { get; set; }
        public decimal ProductividadId { get; set; }
        public decimal TratamientosId { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
