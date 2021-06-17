using AutoMapper;
using Locabora.Application.Commands;
using Locadora.Api.ViewModel;

namespace Locadora.Api.Controllers
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Filme, FilmeViewModel>().ReverseMap();
            CreateMap<FilmeViewModel, CreateFilmeCommand>().ReverseMap();
            CreateMap<FilmeViewModel, EditarFilmeCommand>().ReverseMap();
        }
    }
}