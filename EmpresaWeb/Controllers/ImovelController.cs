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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpresaWeb.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IConfiguration configuration;

        public ImovelController(IConfiguration config)
        {
            configuration = config;
        }
        public ActionResult Index()
        {
            List<ImovelModel> lista = new List<ImovelModel>();
            try
            {
                ImovelRepository repository = new ImovelRepository(configuration);
                foreach (var imovel in repository.ConsultarTodos())
                {
                    ImovelModel model = new ImovelModel();
                    model.IdImovel = imovel.IdImovel;
                    model.Tipo = imovel.Tipo;
                    model.Valor = imovel.Valor;
                    model.Descricao = imovel.Descricao;
                    lista.Add(model);
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }
            return View(lista);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImovelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImovelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImovelModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Imovel imovel = new Imovel();
                    imovel.Tipo = model.Tipo;
                    imovel.Valor = model.Valor;
                    imovel.Descricao = model.Descricao;
                    imovel.Ativo = model.Ativo;

                    ImovelRepository repository = new ImovelRepository(configuration);
                    repository.Inserir(imovel);



                }
                catch (Exception ex)
                {
                    TempData["Mensagem"] = ex.Message;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ImovelController/Edit/5
        public ActionResult Edit(int id)
        {
            ImovelModel model = new ImovelModel();
            try
            {
                ImovelRepository repository = new ImovelRepository(configuration);
                Imovel imovel = repository.ConsultarPorId(id);
                model.IdImovel = imovel.IdImovel;
                model.Tipo = imovel.Tipo;
                model.Valor = imovel.Valor;
                model.Descricao = imovel.Descricao;
                model.Ativo = imovel.Ativo;
                model.ListagemDeImoveis = GerarListagemDeImoveis();
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }
            return View(model);

        }

        // POST: ImovelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImovelModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Imovel imovel = new Imovel();
                    imovel.IdImovel = model.IdImovel;
                    imovel.Tipo = model.Tipo;
                    imovel.Valor = model.Valor;
                    imovel.Descricao = model.Descricao;
                    imovel.Ativo = model. Ativo;
                    ImovelRepository repository = new ImovelRepository(configuration);
                    repository.Atualizar(imovel);
                    TempData["Mensagem"] = $"Imovel {imovel.Descricao}atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }
            model.ListagemDeImoveis = GerarListagemDeImoveis();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {

            try
            {
                ImovelRepository repository = new ImovelRepository(configuration);
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



        // POST: ImovelController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImovelRepository repository = new ImovelRepository(configuration);
            repository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
        private List<SelectListItem> GerarListagemDeImoveis()
        {
            //declarando uma lista
            List<SelectListItem> lista = new List<SelectListItem>();
            try
            {
                //acessando o banco de dados para
                //fazer uma consulta de fornecedores
                ImovelRepository repository = new ImovelRepository(configuration);
                foreach (var imovel in repository.ConsultarTodos())
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = imovel.IdImovel.ToString();
                    item.Text = imovel.Descricao;
                    lista.Add(item); 
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }
            //retornando a lista
            return lista;
        }
        public ActionResult Consulta()
        {
            //criando uma lista da classe de modelo -> ProdutoConsultaModel
            List<ImovelModel> lista = new List<ImovelModel>();

            try
            {
                ImovelRepository repository = new ImovelRepository(configuration);
                foreach (var imovel in repository.ConsultarTodos())
                {
                    ImovelModel model = new ImovelModel();
                    model.IdImovel = imovel.IdImovel;
                    model.Tipo = imovel.Tipo;
                    model.Valor = imovel.Valor;
                    model.Descricao = imovel.Descricao;
                    model.Ativo = imovel.Ativo;


                    lista.Add(model); 
                }
            }
            catch (Exception e)
            {
                //mensagem de erro
                TempData["Mensagem"] = e.Message;
            }

            //enviando a lista para a página
            return View(lista);
        }
    }
}
