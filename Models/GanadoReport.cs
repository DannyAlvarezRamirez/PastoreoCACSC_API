namespace PastoreoCACSC_API.Models
{
    public class GanadoReport
    {
        public int GanadoId { get; set; }
        public int RazaId { get; set; }
        public decimal Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TratamientoId { get; set; }
        public int ProductividadId { get; set; }
        public DateTime UltimoChequeo { get; set; }
        public int EstadoSaludId { get; set; }
        public int Edad { get; set; }
        public int SexoId { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
