using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EmpresaData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpresaWeb.Models
{
    public class ClienteModel
    {
        [Display(Name = "ID")]
        public int IdCliente { get; set; }
        
        [Display(Name = "Nome")]
        public string NomeCliente { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
       
        [ForeignKey("IdImovel")]
        public virtual Imovel IdImovelNavigation { get; set; }
        public int? IdImovel { get; set; }
    }
}
