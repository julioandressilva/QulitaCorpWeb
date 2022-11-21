using QualitaCorpWeb.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitaCorpWeb.Application.Contracts.Services
{
    public interface IFacturaService
    {
        Task AddFactura(Factura factura);
        Task AddMesero(Mesero mesero);
        Task AddCliente(Cliente cliente);
        IEnumerable<Mesero> ListMeseros();
        IEnumerable<Cliente> ListClientes();
        Task<Cliente> ClientesByID(decimal? id);
    }
}
