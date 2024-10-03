﻿namespace PastoreoCACSC_API.Models
{
    public class SuministrosReport
    {
        public decimal Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Descripcion { get; set; }
        public decimal TipoSuministroId { get; set; }
        public decimal SuministroId { get; set; }
    }
}
