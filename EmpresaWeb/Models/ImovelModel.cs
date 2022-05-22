using EmpresaData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaWeb.Models
{
    public class ImovelModel
    {
        [Display(Name = "Id do Imovel")]
        public int IdImovel { get; set; }
        public string Tipo { get; set; }
        public float Valor { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public List<SelectListItem> ListagemDeImoveis { get; set; }
        public Cliente cliente { get; set; }

    }
}
