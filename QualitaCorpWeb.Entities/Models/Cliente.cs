using System;
using System.Collections.Generic;

namespace QualitaCorpWeb.Entities.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public decimal Idcliente { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public decimal? Telefono { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
