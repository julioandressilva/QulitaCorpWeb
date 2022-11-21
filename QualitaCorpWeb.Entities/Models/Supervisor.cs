using System;
using System.Collections.Generic;

namespace QualitaCorpWeb.Entities.Models
{
    public partial class Supervisor
    {
        public Supervisor()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public decimal Idsupervisor { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public decimal? Edad { get; set; }
        public decimal? Antiguedad { get; set; }

        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
