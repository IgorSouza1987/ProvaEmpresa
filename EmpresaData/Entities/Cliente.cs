using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("IdImovel")]
        public virtual Imovel IdImovelNavigation { get; set; }
        public int? IdImovel { get; set; }
    }
}
