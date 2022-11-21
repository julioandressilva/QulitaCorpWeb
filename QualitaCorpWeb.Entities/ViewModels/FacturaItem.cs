using QualitaCorpWeb.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitaCorpWeb.Entities.ViewModels
{
    public class FacturaItem
    {
        public Factura oFactura { get; set; }
        public List<Detallefactura> oDetallefactura { get; set; }
    }
}
