using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locabora.Application.Commands
{
    public class RemoverFilmeCommand : IRequest<bool>
    {
        public Guid Id { get; private set; }

        public RemoverFilmeCommand(Guid id)
        {
            Id = id;
        }
    }
}
