using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbammaeusuario
    {
        public Tbammaeusuario()
        {
            TbamcatalertasConfiguracions = new HashSet<TbamcatalertasConfiguracion>();
            Tbammaenotificaciones = new HashSet<Tbammaenotificacione>();
            Tbammaereportes = new HashSet<Tbammaereporte>();
            TbamrelsistUsuarios = new HashSet<TbamrelsistUsuario>();
        }

        public decimal Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Idnumber { get; set; }
        public string? Role { get; set; }
        public DateTime? LastAccess { get; set; }
        public string? AccountStatus { get; set; }
        public decimal RolId { get; set; }
        public decimal Estado { get; set; }
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<TbamcatalertasConfiguracion> TbamcatalertasConfiguracions { get; set; }
        public virtual ICollection<Tbammaenotificacione> Tbammaenotificaciones { get; set; }
        public virtual ICollection<Tbammaereporte> Tbammaereportes { get; set; }
        public virtual ICollection<TbamrelsistUsuario> TbamrelsistUsuarios { get; set; }
    }
}
