using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaWeb.Models;
using EmpresaData.Entities;
using EmpresaData.Repositories;
using Microsoft.Extensions.Configuration;

namespace EmpresaWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IConfiguration configuration;

        public ClienteController(IConfiguration config)
        {
            configuration = config;
        }
        // GET: ClienteController
        public ActionResult Index()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            try
            {
                ClienteRepository repository = new ClienteRepository(configuration);
                foreach (var cliente in repository.ConsultarTodos())
                {
                    ClienteModel model = new ClienteModel();
                    model.IdCliente = cliente.IdCliente;
                    model.NomeCliente = cliente.NomeCliente;
                    model.Email = cliente.Email;
                    model.Cpf = cliente.Cpf;
                    model.Ativo = cliente.Ativo;
                    lista.Add(model);
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }
            return View(lista);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    ClienteRepository repository = new ClienteRepository(configuration);

                    if ((repository.ConsultarPorCpf(model.Cpf) != null) || ((repository.ConsultarPorEmail(model.Email) != null)))
                    {
                        return View();
                    }
                    else
                    {

                        Cliente cliente = new Cliente();
                        cliente.NomeCliente = model.NomeCliente;
                        cliente.Email = model.Email;
                        cliente.Cpf = model.Cpf;
                        cliente.Ativo = model.Ativo;

                        repository.Inserir(cliente);
                        ModelState.Clear();

                    }
                }
                catch (Exception ex)
                {
                    return Content("Existe Cpf/Email cadastrado na base de dados existente");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            ClienteModel model = new ClienteModel();
            try
            {
                ClienteRepository repository = new ClienteRepository(configuration);
                Cliente cliente = repository.ConsultarPorId(id);
                model.IdCliente = cliente.IdCliente;
                model.NomeCliente = cliente.NomeCliente;
                model.Email = cliente.Email;
                model.Cpf = cliente.Cpf;
                model.Ativo = cliente.Ativo;
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }
            return View(model);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = model.IdCliente;
                    cliente.NomeCliente = model.NomeCliente;
                    cliente.Email = model.Email;
                    cliente.Cpf = model.Cpf;
                    cliente.Ativo = model.Ativo;
                    ClienteRepository repository = new ClienteRepository(configuration);
                    repository.Atualizar(cliente);
                    TempData["Mensagem"] = $"Imovel {cliente.NomeCliente}atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ClienteRepository repository = new ClienteRepository(configuration);
                repository.Excluir(id);
                TempData["Mensagem"] = "Imóvel excluído com sucesso.";
            }
            catch (Exception e)
            {
                //mensagem de erro
                TempData["Mensagem"] = e.Message;
            }
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
