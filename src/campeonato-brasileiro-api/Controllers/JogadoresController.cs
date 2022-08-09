using AutoMapper;
using campeonato_brasileiro_api.ViewModels;
using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using Microsoft.AspNetCore.Mvc;

namespace campeonato_brasileiro_api.Controllers
{
    [Route("api/jogadores")]
    [ApiController]
    public class JogadoresController : MainController
    {
        private readonly IJogadorService _jogadorService;
        private readonly IMapper _mapper;

        public JogadoresController(INotificador notificador,
            IJogadorService jogadorService,
            IMapper mapper
            ) : base(notificador)
        {
            _jogadorService = jogadorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<JogadorViewModel>>> ObterTodos()
        {
            return CustomResponse(
                _mapper.Map<List<JogadorViewModel>>(
                    await _jogadorService.ObterJogadoresTime())?.OrderBy(j => j.TimeNome).ThenBy(j => j.Nome));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<JogadorViewModel>> ObterPorId(Guid id)
        {
            return CustomResponse(_mapper.Map<JogadorViewModel>(await _jogadorService.ObterJogadorTimeTransferencias(id)));
        }

        [HttpPost]
        public async Task<ActionResult<JogadorViewModel>> Incluir([FromBody] JogadorViewModel jogadorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _jogadorService.Incluir(_mapper.Map<Jogador>(jogadorViewModel));

            return CustomResponse(jogadorViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<JogadorViewModel>> Alterar(Guid id, [FromBody] JogadorViewModel jogadorViewModel)
        {
            if (id != jogadorViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado no objeto.");
                return CustomResponse(jogadorViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _jogadorService.Alterar(_mapper.Map<Jogador>(jogadorViewModel));

            return CustomResponse(jogadorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<JogadorViewModel>> Excluir(Guid id)
        {
            var jogadorViewModel = _mapper.Map<JogadorViewModel>(await _jogadorService.ObterJogadorTimeTransferencias(id));

            if (jogadorViewModel == null) return NotFound();

            await _jogadorService.Excluir(id);

            return CustomResponse(jogadorViewModel);
        }
    }
}
