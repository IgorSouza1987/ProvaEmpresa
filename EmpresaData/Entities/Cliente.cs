using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaData.Entities
{
   public class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
    }
}
