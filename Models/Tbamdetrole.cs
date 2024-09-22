using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamdetrole
    {
        public Tbamdetrole()
        {
            TbamrelsistUsuarios = new HashSet<TbamrelsistUsuario>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal RolId { get; set; }

        public virtual ICollection<TbamrelsistUsuario> TbamrelsistUsuarios { get; set; }
    }
}
