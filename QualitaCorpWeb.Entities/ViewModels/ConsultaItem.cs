using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace QualitaCorpWeb.Entities.ViewModels
{
    public class ConsultaItem
    {
        public string dateIni { get; set; }
        public string dateFin { get; set; }
        public string valor { get; set; }
        public List<SelectListItem> ListFecha { get; set; }
    }
}
