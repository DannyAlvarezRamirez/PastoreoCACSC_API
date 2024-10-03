namespace PastoreoCACSC_API.Models
{
    public class SuministrosUpdateRequest
    {
        public decimal? Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal TipoSuministroId { get; set; }
        public string ModificadoPor { get; set; }  // The user who modifies the record
    }
}
