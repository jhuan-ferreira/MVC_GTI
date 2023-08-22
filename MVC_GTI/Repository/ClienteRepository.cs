using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_GTI.Models;
using MVC_GTI.IRepository;
using System.Data.Entity;

namespace MVC_GTI.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public virtual Cliente GetById(int id)
        {
            
            Cliente cliente = null;

            using (var ctx = new DbContext_GTI())
            {
                cliente = ctx.Clientes.Include("Endereco").ToList()
                         .Where(c => c.ClienteId == id)
                         .Select(c => new Cliente()
                         {
                             ClienteId = c.ClienteId,
                             Nome = c.Nome,
                             CPF = c.CPF,
                             RG = c.RG,
                             DataExpedicao = c.DataExpedicao,
                             OrgaoExpedicao = c.OrgaoExpedicao,
                             UF = c.UF,
                             DataNascimento = c.DataNascimento,
                             EstadoCivil = c.EstadoCivil,
                             Sexo = c.Sexo,
                             Endereco = c.Endereco == null ? null : new Endereco()
                             {
                                 EnderecoId = c.Endereco.EnderecoId,
                                 Logadouro = c.Endereco.Logadouro,
                                 Cep = c.Endereco.Cep,
                                 Cidade = c.Endereco.Cidade,
                                 Bairro = c.Endereco.Bairro,
                                 Complemento = c.Endereco.Complemento,
                                 Numero = c.Endereco.Numero,
                                 Uf = c.Endereco.Uf
                             }
                         }).FirstOrDefault<Cliente>();
            }

            return cliente;
        }
    }


}