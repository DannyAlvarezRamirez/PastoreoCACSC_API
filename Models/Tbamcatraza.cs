﻿using System;
using System.Collections.Generic;

namespace PastoreoCACSC_API.Models
{
    public partial class Tbamcatraza
    {
        public Tbamcatraza()
        {
            Tbamdetganados = new HashSet<Tbamdetganado>();
        }

        public decimal RazaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public string CreadoPor { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Tbamdetganado> Tbamdetganados { get; set; }
    }
}
