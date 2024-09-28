using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbammaesuministro
    {
        public Tbammaesuministro()
        {
            Tbamdetconsumibles = new HashSet<Tbamdetconsumible>();
            Tbamdetequipos = new HashSet<Tbamdetequipo>();
            Tbamdetquimicos = new HashSet<Tbamdetquimico>();
            Tbamdetrecursos = new HashSet<Tbamdetrecurso>();
        }

        public decimal Cantidad { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModif { get; set; }
        public string? Descripcion { get; set; }
        public string? TipoSuministro { get; set; }
        public decimal SuministroId { get; set; }

        public virtual ICollection<Tbamdetconsumible> Tbamdetconsumibles { get; set; }
        public virtual ICollection<Tbamdetequipo> Tbamdetequipos { get; set; }
        public virtual ICollection<Tbamdetquimico> Tbamdetquimicos { get; set; }
        public virtual ICollection<Tbamdetrecurso> Tbamdetrecursos { get; set; }
    }
}
