using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbammaeapartamento
    {
        public Tbammaeapartamento()
        {
            Tbamrelrotacions = new HashSet<Tbamrelrotacion>();
        }

        public decimal ApartamentoId { get; set; }
        public decimal? TamanoArea { get; set; }
        public decimal? TipoPastoId { get; set; }
        public decimal? TipoTierraId { get; set; }
        public decimal? DrenajeId { get; set; }
        public decimal? ExpoSolarId { get; set; }
        public decimal? CapaCargaId { get; set; }
        public decimal? FrecuenciaUsoId { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual TbamdetcapaCarga? CapaCarga { get; set; }
        public virtual Tbamdetdrenaje? Drenaje { get; set; }
        public virtual TbamdetexpoSolar? ExpoSolar { get; set; }
        public virtual TbamdetfrecuenciaUso? FrecuenciaUso { get; set; }
        public virtual TbamdettipoPasto? TipoPasto { get; set; }
        public virtual TbamdettipoTierra? TipoTierra { get; set; }
        public virtual ICollection<Tbamrelrotacion> Tbamrelrotacions { get; set; }
    }
}
