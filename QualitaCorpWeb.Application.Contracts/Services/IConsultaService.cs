using QualitaCorpWeb.Entities.Models;
using QualitaCorpWeb.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitaCorpWeb.Application.Contracts.Services
{
    public interface IConsultaService
    {
        IEnumerable<MeseroConsult> ConsultaMeseros(int mesIni, int merFin);
        IEnumerable<ClienteConsult> ConsultaClientes(int mesIni, int merFin, int valor);
    }
}
