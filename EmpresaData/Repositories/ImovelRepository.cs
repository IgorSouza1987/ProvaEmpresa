using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmpresaData.Contracts;
using System.Threading.Tasks;
using EmpresaData.Entities;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EmpresaData.Repositories
{
    public class ImovelRepository : IImovelRepository
    {
        private string DefaultConnection;


        public ImovelRepository(IConfiguration configuration)
        {
            // DefaultConnection = ConfigurationManager.ConnectionStrings
            //["DefaultConnection"].ConnectionString;

            DefaultConnection = configuration.GetConnectionString("DefaultConnection");

        }
        public void Atualizar(Imovel imovel)
        {
            string query = "update Imovel set Tipo = @Tipo, Valor = @Valor, Descricao = @Descricao , Ativo = @Ativo "
                                    + "where IdImovel = @IdImovel";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Execute(query, imovel);
            }
            
        }
        public Imovel ConsultarPorId(int IdImovel)
        {
            string query = "select * from Imovel where IdImovel = @IdImovel";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                return connection.Query<Imovel>(query, new { IdImovel = IdImovel }).SingleOrDefault();
            }
        }

        public List<Imovel> ConsultarTodos()
        {
            string query = "select * from Imovel";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                return connection.Query<Imovel>(query).ToList();
            }
        }

        public void Excluir(int IdImovel)
        {
            string query = "delete from Imovel where IdImovel = @IdImovel";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Execute(query, new { IdImovel = IdImovel });
            }
        }

        public void Inserir(Imovel imovel)
        {
            string query = "insert into Imovel(Tipo,Valor,Descricao,Ativo) "
                                     + "values(@Tipo,@Valor,@Descricao,@Ativo)";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Execute(query, imovel);
            }
        }
    }
}
