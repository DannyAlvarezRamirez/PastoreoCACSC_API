using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetapartamento
    {
        public Tbamdetapartamento()
        {
            Tbamrelrotacions = new HashSet<Tbamrelrotacion>();
        }

        public decimal ApartamentoId { get; set; }
        public decimal? TamanoArea { get; set; }
        public decimal? TipoPastoId { get; set; }
        public decimal? TipoTierraId { get; set; }
        public decimal? CondicionDrenajeId { get; set; }
        public decimal? ExposicionLuzSolarId { get; set; }
        public decimal? CapacidadCargaId { get; set; }
        public decimal? FrecuenciaUsoId { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual TbamcatcapacidadCarga? CapacidadCarga { get; set; }
        public virtual TbamcatcondicionesDrenaje? CondicionDrenaje { get; set; }
        public virtual TbamcatexposicionLuzSolar? ExposicionLuzSolar { get; set; }
        public virtual TbamcatfrecuenciaUso? FrecuenciaUso { get; set; }
        public virtual TbamcattipoPasto? TipoPasto { get; set; }
        public virtual TbamcattipoTierra? TipoTierra { get; set; }
        public virtual ICollection<Tbamrelrotacion> Tbamrelrotacions { get; set; }
    }
}
