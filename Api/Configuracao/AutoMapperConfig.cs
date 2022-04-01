using Api.ViewModels;
using AutoMapper;
using Domain.Entidades;

namespace Api.Configuracao
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Leiturista, LeituristaViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Ocorrencia, OcorrenciaViewModel>().ReverseMap();
            CreateMap<Leitura, LeituraViewModel>().ReverseMap();
            CreateMap<Leitura, AdicionaLeituraViewModel>().ReverseMap();
        }
    }
}