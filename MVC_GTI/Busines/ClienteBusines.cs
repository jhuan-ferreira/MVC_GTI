using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_GTI.Repository;
using MVC_GTI.Models;

namespace MVC_GTI.Busines
{
    public class ClienteBusines
    {
        #region Instâncias Repositorys
        private ClienteRepository clienteRepository = new ClienteRepository();
        #endregion

        #region Funções
        public List<Cliente> GetAll()
        {
           return clienteRepository.GetAll().ToList();
        }

        #endregion

    }
}