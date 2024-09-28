using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbammaeganado
    {
        public decimal GanadoId { get; set; }
        public decimal? RazaId { get; set; }
        public decimal? Peso { get; set; }
        public decimal? SexoId { get; set; }
        public int? Edad { get; set; }
        public decimal? EstadoSaludId { get; set; }
        public DateTime? UltimoChequeo { get; set; }
        public decimal? ProductividadId { get; set; }
        public decimal? TratamientoId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModif { get; set; }

        public virtual TbamdetestadoSalud? EstadoSalud { get; set; }
        public virtual Tbamdetproductividad? Productividad { get; set; }
        public virtual Tbamdetraza? Raza { get; set; }
        public virtual Tbamdetsexo? Sexo { get; set; }
        public virtual Tbamdettratamiento? Tratamiento { get; set; }
    }
}
