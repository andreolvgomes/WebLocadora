using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Filme
{
    [Key]
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public bool Inativo { get; set; }
    public string Obsercacao { get; set; }
}
