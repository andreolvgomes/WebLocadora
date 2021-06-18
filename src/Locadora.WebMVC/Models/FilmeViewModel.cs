using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.WebMVC.Models
{
    public class FilmeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        public bool Inativo { get; set; }
        public string Obsercacao { get; set; }
    }
}
