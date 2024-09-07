using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetsuministro
    {
        public decimal SuministroId { get; set; }
        public decimal? TipoPastoId { get; set; }
        public decimal? FertilizanteId { get; set; }
        public decimal? HerbicidaPesticidaId { get; set; }
        public decimal? AlimentoId { get; set; }
        public decimal? EquipoManejoId { get; set; }
        public decimal? MedicamentoId { get; set; }
        public decimal? VacunaId { get; set; }
        public decimal? HerramientaMantenimientoId { get; set; }
        public decimal? OtroTipoId { get; set; }
        public decimal? AguaId { get; set; }
        public decimal? EnergiaId { get; set; }
        public decimal Cantidad { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Tbamcatagua? Agua { get; set; }
        public virtual Tbamcatalimento? Alimento { get; set; }
        public virtual Tbamcatenergium? Energia { get; set; }
        public virtual TbamcatequipoManejo? EquipoManejo { get; set; }
        public virtual Tbamcatfertilizante? Fertilizante { get; set; }
        public virtual TbamcatherbicidaPesticidum? HerbicidaPesticida { get; set; }
        public virtual TbamcatherramientaMantenimiento? HerramientaMantenimiento { get; set; }
        public virtual Tbamcatmedicamento? Medicamento { get; set; }
        public virtual TbamcatotroTipo? OtroTipo { get; set; }
        public virtual TbamcattipoPasto? TipoPasto { get; set; }
        public virtual Tbamcatvacuna? Vacuna { get; set; }
    }
}
