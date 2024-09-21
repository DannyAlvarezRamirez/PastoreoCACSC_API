namespace PastoreoCACSC_API.Models
{
    public class GanadoFilterRequest
    {
        public string? Nombre { get; set; }
        public string? Raza { get; set; }
        public decimal? Peso { get; set; }
        public string? Sexo { get; set; }
        public int? Edad { get; set; }
        public string? EstadoSalud { get; set; }
        public DateTime? FechaChequeo { get; set; }
        public string Productividad { get; set; }
        public string? Tratamientos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
