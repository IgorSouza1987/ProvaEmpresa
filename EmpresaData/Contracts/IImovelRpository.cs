using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpresaData.Entities;


namespace EmpresaData.Contracts
{
   public interface IImovelRpository
    {
        void Inserir(Imovel imovel);
        void Atualizar(Imovel imovel);
        void Excluir(int IdImovel);

        List<Imovel> ConsultarTodos();
        Imovel ConsultarPorId(int IdImovel);
    }
}
