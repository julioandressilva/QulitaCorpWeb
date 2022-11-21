using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QualitaCoprWeb.Repository.Models;
using QualitaCorpWeb.Entities.Models;
using QualitaCorpWeb.Entities.ViewModels;

namespace QualitaCorpWeb.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ModelContext _context;

        public FacturasController(ModelContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Facturas.Include(f => f.IdclienteNavigation).Include(f => f.IdmesaNavigation).Include(f => f.IdmeseroNavigation);
            return View(await modelContext.ToListAsync());
        }

        [HttpPost]
        public IActionResult Index([FromBody] FacturaItem oFacturaItem )
        {
            Factura oFactura = oFacturaItem.oFactura;
            oFactura.Detallefacturas = oFacturaItem.oDetallefactura;

            _context.Facturas.Add(oFactura);
            _context.SaveChanges();

            return Json(new { respuesta = true });
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.IdclienteNavigation)
                .Include(f => f.IdmesaNavigation)
                .Include(f => f.IdmeseroNavigation)
                .FirstOrDefaultAsync(m => m.Idfactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Nombres");
            ViewData["Idmesa"] = new SelectList(_context.Mesas, "Idmesa", "Nombre");
            ViewData["Idmesero"] = new SelectList(_context.Meseros, "Idmesero", "Nombres");
            ViewData["IdSupervisor"] = new SelectList(_context.Supervisors, "IdSupervisor", "Nombres");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfactura,Idcliente,Idmesa,Idmesero,Fecha")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Idcliente", factura.Idcliente);
            ViewData["Idmesa"] = new SelectList(_context.Mesas, "Idmesa", "Idmesa", factura.Idmesa);
            ViewData["Idmesero"] = new SelectList(_context.Meseros, "Idmesero", "Idmesero", factura.Idmesero);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Idcliente", factura.Idcliente);
            ViewData["Idmesa"] = new SelectList(_context.Mesas, "Idmesa", "Idmesa", factura.Idmesa);
            ViewData["Idmesero"] = new SelectList(_context.Meseros, "Idmesero", "Idmesero", factura.Idmesero);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Idfactura,Idcliente,Idmesa,Idmesero,Fecha")] Factura factura)
        {
            if (id != factura.Idfactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.Idfactura))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Idcliente", factura.Idcliente);
            ViewData["Idmesa"] = new SelectList(_context.Mesas, "Idmesa", "Idmesa", factura.Idmesa);
            ViewData["Idmesero"] = new SelectList(_context.Meseros, "Idmesero", "Idmesero", factura.Idmesero);
            return View(factura);
        }

        private bool FacturaExists(decimal id)
        {
          return _context.Facturas.Any(e => e.Idfactura == id);
        }
    }
}
