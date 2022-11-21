using QualitaCorpWeb.Application.Contracts.Services;
using QualitaCorpWeb.Entities.Models;
using QualitaCorpWeb.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitaCorpWeb.Application.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IModelContext _context;

        public FacturaService(IModelContext context)
        {
            _context = context;
        }

        public async Task AddCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AddFactura(Factura factura)
        {
            await _context.Facturas.AddAsync(factura);
            await _context.SaveChangesAsync();
        }

        public async Task AddMesero(Mesero mesero)
        {
            await _context.Meseros.AddAsync(mesero);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Mesero> ListMeseros()
        {
            if (_context.Meseros.Count() > 0)
            {
                return _context.Meseros.ToList();
            }
            return null;
        }

        public IEnumerable<Cliente> ListClientes()
        {
            if (_context.Clientes.Count() > 0)
            {
                return _context.Clientes.ToList();
            }
            return null;
        }

        public async Task<Cliente> ClientesByID(decimal? id)
        {
            return await _context.Clientes.FindAsync(id);

        }
    }
}

