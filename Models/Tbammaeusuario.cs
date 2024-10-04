using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbammaeusuario
    {
        //public Tbammaeusuario()
        //{
        //    TbamcatalertasConfigs = new HashSet<TbamcatalertasConfig>();
        //    Tbammaenotificacions = new HashSet<Tbammaenotificacion>();
        //    Tbammaereportes = new HashSet<Tbammaereporte>();
        //    TbamrelsistUsuarios = new HashSet<TbamrelsistUsuario>();
        //}

        public decimal Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Idnumber { get; set; }
        public string? AccountStatus { get; set; }
        public decimal RolId { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModif { get; set; }

        //public virtual ICollection<TbamcatalertasConfig> TbamcatalertasConfigs { get; set; }
        //public virtual ICollection<Tbammaenotificacion> Tbammaenotificacions { get; set; }
        //public virtual ICollection<Tbammaereporte> Tbammaereportes { get; set; }
        //public virtual ICollection<TbamrelsistUsuario> TbamrelsistUsuarios { get; set; }
    }
}
