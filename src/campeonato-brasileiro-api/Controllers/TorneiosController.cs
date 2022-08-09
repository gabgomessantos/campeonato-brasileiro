using AutoMapper;
using campeonato_brasileiro_api.ViewModels;
using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using Microsoft.AspNetCore.Mvc;

namespace campeonato_brasileiro_api.Controllers
{
    [Route("api/torneios")]
    [ApiController]
    public class TorneiosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ITorneioService _torneioService;
        private readonly IPartidaService _partidaService;

        public TorneiosController(INotificador notificador,
            IMapper mapper,
            ITorneioService torneioService,
            IPartidaService partidaService
            ) : base(notificador)
        {
            _mapper = mapper;
            _torneioService = torneioService;
            _partidaService = partidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TorneioViewModel>>> ObterTodos()
        {
            return CustomResponse(_mapper.Map<IEnumerable<TorneioViewModel>>(
                await _torneioService.ObterTodos())?.OrderBy(j => j.Nome));
        }

        [HttpGet("{id:guid}/times")]
        public async Task<ActionResult<TorneioViewModel>> ObterTorneioTimes(Guid id)
        {
            var torneio = await _torneioService.ObterTorneioTimes(id);

            if (torneio == null) return NotFound();

            return CustomResponse(_mapper.Map<TorneioViewModel>(torneio));
        }
        
        [HttpGet("{id:guid}/times/partidas")]
        public async Task<ActionResult<TorneioViewModel>> ObterTorneioTimesPartidas(Guid id)
        {
            var torneio = await _torneioService.ObterTorneioTimesPartidas(id);
            
            if (torneio == null) return NotFound();

            return CustomResponse(_mapper.Map<TorneioViewModel>(torneio));
        }
        
        [HttpPost]
        public async Task<ActionResult<TorneioViewModel>> Incluir([FromBody] TorneioViewModel torneioViewModel)
        {
            if (!ModelState.IsValid) CustomResponse(ModelState);

            await _torneioService.Incluir(_mapper.Map<Torneio>(torneioViewModel));

            return CustomResponse(torneioViewModel);
        }

        [HttpPost("{torneioId:guid}/partidas/{partidaId:guid}/eventos/inicio")]
        public async Task<ActionResult<EventoViewModel>> IncluirEventoInicio(Guid torneioId, Guid partidaId)
        {
            var partidaEventos = _partidaService.ObterPartidaTorneioTimeEventos(partidaId).Result.Eventos?.Where(e => e.TipoEvento == TipoEvento.Inicio);
            if (partidaEventos.Any())
            {
                NotificarErro("O evento já está cadastrado.");
                return CustomResponse(_mapper.Map<EventoViewModel>(partidaEventos.FirstOrDefault()));
            }
            var evento = new Evento { TipoEvento = TipoEvento.Inicio, PartidaId = partidaId, Data = DateTime.Now };
            await _partidaService.IncluirEvento(evento);

            return CustomResponse(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPost("{torneioId:guid}/partidas/{partidaId:guid}/eventos/gol-mandante")]
        public async Task<ActionResult<EventoViewModel>> IncluirEventoGolMandante(Guid torneioId, Guid partidaId)
        {
            var evento = new Evento { TipoEvento = TipoEvento.GolMandante, PartidaId = partidaId, Data = DateTime.Now };
            await _partidaService.IncluirEvento(evento);

            return CustomResponse(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPost("{torneioId:guid}/partidas/{partidaId:guid}/eventos/gol-visitante")]
        public async Task<ActionResult<EventoViewModel>> IncluirEventoGolVisitante(Guid torneioId, Guid partidaId)
        {
            var evento = new Evento { TipoEvento = TipoEvento.GolVisitante, PartidaId = partidaId, Data = DateTime.Now };
            await _partidaService.IncluirEvento(evento);

            return CustomResponse(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPost("{torneioId:guid}/partidas/{partidaId:guid}/eventos/intervalo")]
        public async Task<ActionResult<EventoViewModel>> IncluirEventoIntervalo(Guid torneioId, Guid partidaId)
        {
            var partidaEventos = _partidaService.ObterPartidaTorneioTimeEventos(partidaId).Result.Eventos?.Where(e => e.TipoEvento == TipoEvento.Intervalo);
            if (partidaEventos.Any())
            {
                NotificarErro("O evento já está cadastrado.");
                return CustomResponse(_mapper.Map<EventoViewModel>(partidaEventos.FirstOrDefault()));
            }
            var evento = new Evento { TipoEvento = TipoEvento.Intervalo, PartidaId = partidaId, Data = DateTime.Now };
            await _partidaService.IncluirEvento(evento);

            return CustomResponse(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPost("{torneioId:guid}/partidas/{partidaId:guid}/eventos/acrescimo")]
        public async Task<ActionResult<EventoViewModel>> IncluirEventoAcrescimo(Guid torneioId, Guid partidaId)
        {
            var partidaEventos = _partidaService.ObterPartidaTorneioTimeEventos(partidaId).Result.Eventos?.Where(e => e.TipoEvento == TipoEvento.Acrescimo);
            if (partidaEventos.Any())
            {
                NotificarErro("O evento já está cadastrado.");
                return CustomResponse(_mapper.Map<EventoViewModel>(partidaEventos.FirstOrDefault()));
            }
            var evento = new Evento { TipoEvento = TipoEvento.Acrescimo, PartidaId = partidaId, Data = DateTime.Now };
            await _partidaService.IncluirEvento(evento);

            return CustomResponse(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPost("{torneioId:guid}/partidas/{partidaId:guid}/eventos/substituicao")]
        public async Task<ActionResult<EventoViewModel>> IncluirEventoSubstituicao(Guid torneioId, Guid partidaId)
        {
            var evento = new Evento { TipoEvento = TipoEvento.Substituicao, PartidaId = partidaId, Data = DateTime.Now };
            await _partidaService.IncluirEvento(evento);

            return CustomResponse(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPost("{torneioId:guid}/partidas/{partidaId:guid}/eventos/advertencia")]
        public async Task<ActionResult<EventoViewModel>> IncluirEventoAdvertencia(Guid torneioId, Guid partidaId)
        {
            var evento = new Evento { TipoEvento = TipoEvento.Advertencia, PartidaId = partidaId, Data = DateTime.Now };
            await _partidaService.IncluirEvento(evento);

            return CustomResponse(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPost("{torneioId:guid}/partidas/{partidaId:guid}/eventos/fim")]
        public async Task<ActionResult<EventoViewModel>> IncluirEventoFim(Guid torneioId, Guid partidaId)
        {
            var partidaEventos = _partidaService.ObterPartidaTorneioTimeEventos(partidaId).Result.Eventos?.Where(e => e.TipoEvento == TipoEvento.Fim);
            if (partidaEventos.Any())
            {
                NotificarErro("O evento já está cadastrado.");
                return CustomResponse(_mapper.Map<EventoViewModel>(partidaEventos.FirstOrDefault()));
            }
            var evento = new Evento { TipoEvento = TipoEvento.Fim, PartidaId = partidaId, Data = DateTime.Now };
            await _partidaService.IncluirEvento(evento);

            return CustomResponse(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TorneioViewModel>> Alterar(Guid id, [FromBody] TorneioViewModel torneioViewModel)
        {
            if (id != torneioViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado no objeto.");
                return CustomResponse(torneioViewModel);
            }

            if (!ModelState.IsValid) CustomResponse(ModelState);

            await _torneioService.Alterar(_mapper.Map<Torneio>(torneioViewModel));

            return CustomResponse(torneioViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TorneioViewModel>> Excluir(Guid id)
        {
            var torneioViewModel = _mapper.Map<TorneioViewModel>(await _torneioService.ObterPorId(id));

            if (torneioViewModel == null) return NotFound();

            await _torneioService.Excluir(id);

            return CustomResponse(torneioViewModel);
        }
    }
}
