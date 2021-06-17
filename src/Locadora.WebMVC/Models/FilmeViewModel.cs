using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.WebMVC.Models
{
    public class FilmeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} � obrigat�rio")]
        public string Nome { get; set; }

        public bool Inativo { get; set; }
        public string Obsercacao { get; set; }
    }
}
