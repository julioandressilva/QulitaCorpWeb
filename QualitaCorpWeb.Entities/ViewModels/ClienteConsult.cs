using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitaCorpWeb.Entities.ViewModels
{
    public class ClienteConsult
    {
        public decimal Idcliente { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
