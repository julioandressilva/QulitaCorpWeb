using System;
using System.Collections.Generic;

namespace QualitaCorpWeb.Entities.Models
{
    public partial class Mesero
    {
        public Mesero()
        {
            Facturas = new HashSet<Factura>();
        }

        public decimal Idmesero { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public decimal? Edad { get; set; }
        public decimal? Antiguedad { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
