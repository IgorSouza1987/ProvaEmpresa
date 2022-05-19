using EmpresaData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaData.Contracts
{
   public interface IClienteRpository
    {
        void Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int IdCliente);

        List<Cliente> ConsultarTodos();
        Cliente ConsultarPorId(int IdCliente);
    }
}
