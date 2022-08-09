using AutoMapper;
using campeonato_brasileiro_api.ViewModels;
using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Time, TimeViewModel>().ReverseMap();
            CreateMap<Torneio, TorneioViewModel>().ReverseMap();
            CreateMap<Evento, EventoViewModel>().ReverseMap();

            CreateMap<PartidaViewModel, Partida>();
            CreateMap<Partida, PartidaViewModel>()
                .ForMember(dest => dest.TorneioNome, opt => opt.MapFrom(src => src.Torneio.Nome))
                .ForMember(dest => dest.TimeMandanteNome, opt => opt.MapFrom(src => src.TimeMandante.Nome))
                .ForMember(dest => dest.TimeVisitanteNome, opt => opt.MapFrom(src => src.TimeVisitante.Nome));

            CreateMap<JogadorViewModel, Jogador>();
            CreateMap<Jogador, JogadorViewModel>()
                .ForMember(dest => dest.TimeNome, opt => opt.MapFrom(src => src.Time.Nome));

            CreateMap<TransferenciaViewModel, Transferencia>();
            CreateMap<Transferencia, TransferenciaViewModel>()
                .ForMember(dest => dest.JogadorNome, opt => opt.MapFrom(src => src.Jogador.Nome))
                .ForMember(dest => dest.TimeOrigemNome, opt => opt.MapFrom(src => src.TimeOrigem.Nome))
                .ForMember(dest => dest.TimeDestinoNome, opt => opt.MapFrom(src => src.TimeDestino.Nome));
        }
    }
}
