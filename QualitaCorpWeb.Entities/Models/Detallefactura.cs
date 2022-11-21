using System;
using System.Collections.Generic;

namespace QualitaCorpWeb.Entities.Models
{
    public partial class Detallefactura
    {
        public decimal Iddetallefactura { get; set; }
        public decimal Idfactura { get; set; }
        public decimal Idsupervisor { get; set; }
        public string Plato { get; set; } = null!;
        public decimal Valor { get; set; }

        public virtual Factura IdfacturaNavigation { get; set; } = null!;
        public virtual Supervisor IdsupervisorNavigation { get; set; } = null!;
    }
}
