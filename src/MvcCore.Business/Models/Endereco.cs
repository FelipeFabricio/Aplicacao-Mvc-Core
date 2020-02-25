using System;
using System.Collections.Generic;
using System.Text;

namespace MvcCore.Business.Models
{
    public class Endereco : Entity
    {
        public Guid FornecedorId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        /* Entity Framework Relation */
        public Fornecedor Fornecedor { get; set; }

    }
}
