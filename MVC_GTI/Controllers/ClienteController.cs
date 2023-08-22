using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC_GTI.ViewModels;
using MVC_GTI.Models;
using System.Web.Http;
using MVC_GTI.Repository;

namespace MVC_GTI.Controllers
{
    public class ClienteController : ApiController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();

        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            var cliente = clienteRepository.GetAll();

            if (cliente.Count == 0)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetClienteById(int? id)
        {
            if (id == null)
                return BadRequest("O Id do Cliente é inválido");

            var cliente = clienteRepository.GetById(id.Value);

            //using (var ctx = new DbContext_GTI())
            //{
            //    cliente = ctx.Clientes.Include("Endereco").ToList()
            //             .Where(c => c.ClienteId == id)
            //             .Select(c => new Cliente()
            //             {
            //                 ClienteId = c.ClienteId,
            //                 Nome = c.Nome,
            //                 CPF = c.CPF,
            //                 RG = c.RG,
            //                 Endereco = c.Endereco == null ? null : new Endereco()
            //                 {
            //                     EnderecoId = c.Endereco.EnderecoId,
            //                     Logadouro = c.Endereco.Logadouro,
            //                     Cidade = c.Endereco.Cidade,
            //                     Uf = c.Endereco.Uf
            //                 }
            //             }).FirstOrDefault<Cliente>();
            //}

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult PostNovoContato(Cliente cliente)
        {
            if (!ModelState.IsValid || cliente == null)
                return BadRequest("Dados do contato inválidos.");

            clienteRepository.Save(cliente);

            return Ok(cliente);
        }
    }
}