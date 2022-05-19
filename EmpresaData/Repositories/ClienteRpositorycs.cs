using EmpresaData.Contracts;
using EmpresaData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaData.Repositories
{
    public class ClienteRpositorycs : IClienteRpository
    {
        public void Atualizar(Imovel imovel)
        {
            string query = "update Imovel set Tipo = @Tipo, Valor = @Valor, Descricao = @Descricao , Ativo = @Ativo "
                                    + "where IdImovel = @IdImovel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, imovel);
            }

            public Imovel ConsultarPorId(int IdImovel)
            {
                string query = "select * from Imovel where IdImovel = @IdImovel";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Imovel>(query, new { IdImovel = IdImovel }).SingleOrDefault();
                }
            }

            public List<Imovel> ConsultarTodos()
            {
                string query = "select * from Imovel";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Imovel>(query).ToList();
                }
            }

            public void Excluir(int IdImovel)
            {
                string query = "delete from Imovel where IdImovel = @IdImovel";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Execute(query, new { IdImovel = IdImovel });
                }
            }

            public void Inserir(Imovel imovel)
            {
                string query = "insert into Imovel(Tipo,Valor,Descricao,Ativo) "
                                         + "values(@Tipo,@Valor,@Descricao,@Ativo)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Execute(query, imovel);
                }
            }
        }
    }
}
