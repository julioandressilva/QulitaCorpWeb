using System;
using System.Collections.Generic;

namespace QualitaCorpWeb.Entities.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public decimal Idfactura { get; set; }
        public decimal Idcliente { get; set; }
        public decimal Idmesa { get; set; }
        public decimal Idmesero { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; } = null!;
        public virtual Mesa IdmesaNavigation { get; set; } = null!;
        public virtual Mesero IdmeseroNavigation { get; set; } = null!;
        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
