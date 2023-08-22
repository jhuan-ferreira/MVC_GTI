using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ClienteViewModels> cliente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64416/api/");

                var responseTask = client.GetAsync("cliente");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ClienteViewModels>>();
                    readTask.Wait();

                    cliente = readTask.Result;
                }
                else
                {
                    cliente = Enumerable.Empty<ClienteViewModels>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(cliente);
            }
        }

        [HttpGet]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteViewModels cliente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64416/api/cliente");

                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClienteViewModels>();
                    readTask.Wait();

                    cliente = readTask.Result;
                }

            }

            return View(cliente);
        }
    }
}