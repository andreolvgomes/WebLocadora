using Locadora.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Filme : Entity
{
    public string Nome { get; set; }
    public bool Inativo { get; set; }
    public string Obsercacao { get; set; }
}
