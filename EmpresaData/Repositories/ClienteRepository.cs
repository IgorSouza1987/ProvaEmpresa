using EmpresaData.Contracts;
using EmpresaData.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EmpresaData.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string DefaultConnection;


        public ClienteRepository(IConfiguration configuration)
        {
           // DefaultConnection = ConfigurationManager.ConnectionStrings
           //["DefaultConnection"].ConnectionString;

            DefaultConnection = configuration.GetConnectionString("DefaultConnection");

        }

        public void Atualizar(Cliente cliente)
        {
            string query = "update Cliente set NomeCliente  = @NomeCliente , Email = @Email, CPF = @CPF , Ativo = @Ativo "
                                    + "where IdCliente = @IdCliente";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Execute(query, cliente);
            }

           
        }
        public Cliente ConsultarPorId(int IdCliente)
        {
            string query = "select * from Cliente where IdCliente = @IdCliente";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                return connection.Query<Cliente>(query, new { IdCliente = IdCliente }).SingleOrDefault();
            }
        }

        public List<Cliente> ConsultarTodos()
        {
            string query = "select * from Cliente";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                return connection.Query<Cliente>(query).ToList();
            }
        }

        public void Excluir(int IdCliente)
        {
            string query = "delete from Cliente where IdCliente = @IdCliente";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Execute(query, new { IdCliente = IdCliente });
            }
        }

        public void Inserir(Cliente cliente)
        {
            string query = "insert into Cliente(NomeCliente,Email,Cpf,Ativo) "
                                     + "values(@NomeCliente,@Email,@Cpf,@Ativo)";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Execute(query, cliente);
            }
        }
        public Cliente ConsultarPorCpf(string cpf)
        {
            string query = "select * from Cliente where Cpf = @Cpf";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                return connection.Query<Cliente>(query, new { Cpf = cpf })
                        .SingleOrDefault();
            }
        }
        public Cliente ConsultarPorEmail(string email)
        {
            string query = "select * from Cliente where Email = @Email";

            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                return connection.Query<Cliente>(query, new { Email = email })
                        .SingleOrDefault();
            }
        }
    }
}
