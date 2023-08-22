using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_GTI.Models
{
    public class DbContext_GTI : DbContext
    {
        public DbContext_GTI() : base("GtiContext")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}