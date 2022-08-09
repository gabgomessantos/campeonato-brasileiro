using AutoMapper;
using campeonato_brasileiro_api.ViewModels;
using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using Microsoft.AspNetCore.Mvc;

namespace campeonato_brasileiro_api.Controllers
{
    [Route("api/partidas")]
    [ApiController]
    public class PartidasController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IPartidaService _partidaService;
        private readonly ITorneioService _torneioService;

        public PartidasController(INotificador notificador,
            IMapper mapper,
            IPartidaService partidaService,
            ITorneioService torneioService
            ) : base(notificador)
        {
            _mapper = mapper;
            _partidaService = partidaService;
            _torneioService = torneioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartidaViewModel>>> ObterTodos()
        {
            return CustomResponse(_mapper.Map<IEnumerable<PartidaViewModel>>(
                await _partidaService.ObterPartidasTorneioTime())?.OrderBy(j => j.TorneioNome).ThenBy(j => j.TimeMandanteNome));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PartidaViewModel>> ObterPorId(Guid id)
        {
            var partidaViewModel = _mapper.Map<PartidaViewModel>(await _partidaService.ObterPartidaTorneioTimeEventos(id));

            partidaViewModel.Eventos = partidaViewModel.Eventos?.OrderBy(e => e.Data);

            return CustomResponse(partidaViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<PartidaViewModel>> Incluir([FromBody] PartidaViewModel partidaViewModel)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            await _partidaService.Incluir(_mapper.Map<Partida>(partidaViewModel));

            return CustomResponse(partidaViewModel);
        }

        [HttpPost("pre-definidos")]
        public async Task<ActionResult<TimeViewModel>> IncluirPreDefinido(bool incluirAutomatico)
        {
            if (incluirAutomatico)
            {
                foreach (var partida in PartidasPredefinidas().Result)
                {
                    await _partidaService.Incluir(partida);
                }
            }

            return CustomResponse();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PartidaViewModel>> Alterar(Guid id, [FromBody] PartidaViewModel partidaViewModel)
        {
            if (id != partidaViewModel.Id)
            {
                NotificarErro("O Id informado está incorreto");
                return CustomResponse(partidaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _partidaService.Alterar(_mapper.Map<Partida>(partidaViewModel));

            return CustomResponse(partidaViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PartidaViewModel>> Excluir(Guid id)
        {
            var partidaViewModel = _mapper.Map<TransferenciaViewModel>(await _partidaService.ObterPartidaTorneioTime(id));

            if (partidaViewModel == null) return NotFound();

            await _partidaService.Excluir(id);

            return CustomResponse(partidaViewModel);
        }

        private async Task<List<Partida>> PartidasPredefinidas()
        {
            var partidas = new List<Partida>();

            var torneios = await _torneioService.ObterTodos();

            foreach (var torneio in torneios)
            {
                var torneioTimes = await _torneioService.ObterTorneioTimes(torneio.Id);

                if (torneioTimes == null || torneioTimes.Times == null) return partidas;

                foreach (var timeMandante in torneioTimes.Times.OrderBy(t => t.Nome))
                {
                    foreach (var timeVisitante in torneioTimes.Times.Where(t => t.Id != timeMandante.Id)?.OrderBy(t => t.Nome))
                    {
                        partidas.Add(new Partida { TorneioId = torneioTimes.Id, TimeMandanteId = timeMandante.Id, TimeVisitanteId = timeVisitante.Id });
                    }
                }
            }

            return partidas;
        }
    }
}
