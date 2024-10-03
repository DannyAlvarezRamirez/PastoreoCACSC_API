﻿namespace PastoreoCACSC_API.Models
{
    public class TbamdettipoSuministro
    {
        public TbamdettipoSuministro()
        {
            Tbammaesuministro = new HashSet<Tbammaesuministro>();
        }

        public string Descripcion { get; set; } = null!;
        public decimal TipoSuministroId { get; set; }

        public virtual ICollection<Tbammaesuministro> Tbammaesuministro { get; set; }
    }
}
