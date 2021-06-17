using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locabora.Application.Commands
{
    public class CriarFilmeCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public bool Inativo { get; set; }
        public string Obsercacao { get; set; }
    }
}