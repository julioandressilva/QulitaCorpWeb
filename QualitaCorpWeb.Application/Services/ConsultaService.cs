using QualitaCorpWeb.Application.Contracts.Services;
using QualitaCorpWeb.Entities.Models;
using QualitaCorpWeb.Entities.ViewModels;
using QualitaCorpWeb.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitaCorpWeb.Application.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IModelContext _context;
        public ConsultaService(IModelContext context)
        {
            _context = context;
        }
        public IEnumerable<MeseroConsult> ConsultaMeseros(int mesIni , int merFin)
        {
            
            var result = from factura in _context.Facturas
                         join detalle in _context.Detallefacturas on factura.Idfactura equals detalle.Idfactura
                         join mese in _context.Meseros on factura.Idmesero equals mese.Idmesero
                         where factura.Fecha.Month>= mesIni && factura.Fecha.Month<= merFin
                         group detalle by new { mese.Idmesero, mese.Nombres, mese.Apellidos} into meseroGroup
                         select new MeseroConsult
                         {
                             Idmesero= meseroGroup.Key.Idmesero,
                             Nombres= meseroGroup.Key.Nombres,
                             Apellidos= meseroGroup.Key.Apellidos,
                             Total = meseroGroup.Sum(x=>x.Valor)
                         };

            return (IEnumerable<MeseroConsult>) result.ToList();
        }

        public IEnumerable<ClienteConsult> ConsultaClientes(int mesIni, int merFin, int valor)
        {

            var result = from factura in _context.Facturas
                         join detalle in _context.Detallefacturas on factura.Idfactura equals detalle.Idfactura
                         join cliente in _context.Clientes on factura.Idcliente equals cliente.Idcliente
                         where factura.Fecha.Month >= mesIni && factura.Fecha.Month <= merFin
                         group detalle by new { cliente.Idcliente, cliente.Nombres, cliente.Apellidos } into clienteGroup
                         select new ClienteConsult
                         {
                             Idcliente = clienteGroup.Key.Idcliente,
                             Nombres = clienteGroup.Key.Nombres,
                             Apellidos = clienteGroup.Key.Apellidos,
                             Total = clienteGroup.Sum(x => x.Valor)
                         };

            return (IEnumerable<ClienteConsult>)result.ToList();
        }
    }
}
