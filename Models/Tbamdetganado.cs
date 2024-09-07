using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetganado
    {
        public decimal GanadoId { get; set; }
        public decimal? RazaId { get; set; }
        public decimal? Peso { get; set; }
        public decimal? SexoId { get; set; }
        public int? Edad { get; set; }
        public decimal? EstadoSaludId { get; set; }
        public DateTime? FechaUltimoChequeo { get; set; }
        public decimal? ProductividadId { get; set; }
        public decimal? TratamientoId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? IdentificacionUnica { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual TbamcatestadoSalud? EstadoSalud { get; set; }
        public virtual Tbamcatproductividad? Productividad { get; set; }
        public virtual Tbamcatraza? Raza { get; set; }
        public virtual Tbamcatsexo? Sexo { get; set; }
        public virtual Tbamcattratamiento? Tratamiento { get; set; }
    }
}
