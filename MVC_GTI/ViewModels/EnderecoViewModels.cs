using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_GTI.ViewModels
{
    public class EnderecoViewModels
    {
        public int EnderecoId { get; set; }
        public string Cep { get; set; }
        public string Logadouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}