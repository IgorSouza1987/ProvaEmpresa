using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaData.Entities
{
   public class Imovel
    {
        public int IdImovel { get; set; }
        public string Tipo { get; set; }
        public float Valor { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public Cliente cliente { get; set; }
    }
}
