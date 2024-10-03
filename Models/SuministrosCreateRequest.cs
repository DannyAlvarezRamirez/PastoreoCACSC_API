namespace PastoreoCACSC_API.Models
{
    public class SuministrosCreateRequest
    {
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal TipoSuministroId { get; set; }
        public string CreadoPor { get; set; }  // The user who creates the record
    }
}
