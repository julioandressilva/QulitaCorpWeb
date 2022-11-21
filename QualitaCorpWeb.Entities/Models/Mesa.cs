using System;
using System.Collections.Generic;

namespace QualitaCorpWeb.Entities.Models
{
    public partial class Mesa
    {
        public Mesa()
        {
            Facturas = new HashSet<Factura>();
        }

        public decimal Idmesa { get; set; }
        public string? Nombre { get; set; }
        public decimal? Reservada { get; set; }
        public string? Puestos { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
