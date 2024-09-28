namespace PastoreoCACSC_API.Models
{
    public class ReporteRequest
    {
        public string RegisterType { get; set; }  // "ganado", "suministro", or "departamento"
        public string ReportType { get; set; }    // "diario", "mensual", "anual"
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }    // If null, defaults to current date in SP
    }
}
