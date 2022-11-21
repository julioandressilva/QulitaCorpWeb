using Microsoft.EntityFrameworkCore;
using QualitaCorpWeb.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitaCorpWeb.Repository.Contracts
{
    public interface IModelContext
    {
        public  DbSet<Cliente> Clientes { get; set; } 
        public  DbSet<Detallefactura> Detallefacturas { get; set; }
        public  DbSet<Factura> Facturas { get; set; }
        public  DbSet<Mesa> Mesas { get; set; }
        public  DbSet<Mesero> Meseros { get; set; } 
        public  DbSet<Supervisor> Supervisors { get; set; } 
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
