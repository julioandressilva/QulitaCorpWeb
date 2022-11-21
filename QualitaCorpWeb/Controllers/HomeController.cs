using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using QualitaCorpWeb.Application.Contracts.Services;
using QualitaCorpWeb.Entities.Models;
using QualitaCorpWeb.Entities.ViewModels;
using QualitaCorpWeb.Models;
using System.Diagnostics;
using System.Text;

namespace QualitaCorpWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConsultaService _consultasService;

        public HomeController(ILogger<HomeController> logger, IConsultaService consultasService)
        {
            _logger = logger;
            _consultasService = consultasService;
        }

        public IActionResult Index()
        {
            ConsultaItem? consultaItem = new ConsultaItem();
            var list = GetAllMonths();
            List<SelectListItem> items = list.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            }
                );
            items.Insert(0, new SelectListItem("--Seleccione Mes--", "0"));
            consultaItem.ListFecha = items;
            

            return View(consultaItem);
        }
        [HttpPost]
        public async Task<IActionResult> ReporteMesero(ConsultaItem consult)
        {
            HttpResponseMessage response = null;
            IEnumerable<MeseroConsult> list;

            list = _consultasService.ConsultaMeseros(int.Parse(consult.dateIni), int.Parse(consult.dateFin));
            
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(list);

                using StringContent jsonContent = new(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync("http://quaitaapi.somee.com//api/Values/Get/Meseros", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachmen");
                    response.Content.Headers.ContentDisposition.FileName = @"reporte.pdf";
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

                    /*var output = await response.Content.ReadAsByteArrayAsync();
                    var path = @"testpdf.pdf";
                    System.IO.File.WriteAllBytes(path, output);*/
                }

            }
            return File(await response.Content.ReadAsByteArrayAsync(), "application/pdf"); ;
        }

        [HttpPost]
        public async Task<IActionResult> ReporteCliente(ConsultaItem consult)
        {
            HttpResponseMessage response = null;
            IEnumerable<ClienteConsult> list;

            list = _consultasService.ConsultaClientes(int.Parse(consult.dateIni), int.Parse(consult.dateFin), int.Parse(consult.valor));

            var res =list.Where(x => x.Total <= int.Parse(consult.valor));

            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(res);

                using StringContent jsonContent = new(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync("http://quaitaapi.somee.com//api/Values/Get/Clientes", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachmen");
                    response.Content.Headers.ContentDisposition.FileName = @"reporte.pdf";
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

                    /*var output = await response.Content.ReadAsByteArrayAsync();
                    var path = @"testpdf.pdf";
                    System.IO.File.WriteAllBytes(path, output);*/
                }

            }
            return File(await response.Content.ReadAsByteArrayAsync(), "application/pdf"); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Item> GetAllMonths()
        {
            return new List<Item>
            {
                new Item(){Id = "1",Nombre="Enero"},
                new Item(){Id = "2",Nombre="Febrero"},
                new Item(){Id = "3",Nombre="Marzo"},
                new Item(){Id = "4",Nombre="Abril"},
                new Item(){Id = "5",Nombre="Mayo"},
                new Item(){Id = "6",Nombre="Junio"},
                new Item(){Id = "7",Nombre="Julio"},
                new Item(){Id = "8",Nombre="Agosto"},
                new Item(){Id = "9",Nombre="Septiembre"},
                new Item(){Id = "10",Nombre="Octubre"},
                new Item(){Id = "11",Nombre="Noviembre"},
                new Item(){Id = "12",Nombre="Diciembre"},

            };
        }

    }

}