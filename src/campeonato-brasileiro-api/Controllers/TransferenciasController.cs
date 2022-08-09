using AutoMapper;
using campeonato_brasileiro_api.ViewModels;
using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using Microsoft.AspNetCore.Mvc;

namespace campeonato_brasileiro_api.Controllers
{
    [Route("api/transferencias")]
    [ApiController]
    public class TransferenciasController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ITransferenciaService _transferenciaService;

        public TransferenciasController(INotificador notificador,
            IMapper mapper,
            ITransferenciaService transferenciaService
            ) : base(notificador)
        {
            _mapper = mapper;
            _transferenciaService = transferenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferenciaViewModel>>> ObterTodos()
        {
            return CustomResponse(_mapper.Map<IEnumerable<TransferenciaViewModel>>(
                await _transferenciaService.ObterTransferenciasJogadorTime())?.OrderBy(j => j.JogadorNome).ThenBy(j => j.TimeOrigemNome));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TransferenciaViewModel>> ObterPorId(Guid id)
        {
            return CustomResponse(_mapper.Map<TransferenciaViewModel>(await _transferenciaService.ObterTransferenciaJogadorTime(id)));
        }

        [HttpPost]
        public async Task<ActionResult<TransferenciaViewModel>> Incluir([FromBody] TransferenciaViewModel transferenciaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _transferenciaService.Incluir(_mapper.Map<Transferencia>(transferenciaViewModel));

            return CustomResponse(transferenciaViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TransferenciaViewModel>> Alterar(Guid id, [FromBody] TransferenciaViewModel transferenciaViewModel)
        {
            if (id != transferenciaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado no objeto.");
                return CustomResponse(transferenciaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _transferenciaService.Alterar(_mapper.Map<Transferencia>(transferenciaViewModel));

            return CustomResponse(transferenciaViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TransferenciaViewModel>> Excluir(Guid id)
        {
            var transferenciaViewModel = _mapper.Map<TransferenciaViewModel>(await _transferenciaService.ObterTransferenciaJogadorTime(id));

            if (transferenciaViewModel == null) return NotFound();

            await _transferenciaService.Excluir(id);

            return CustomResponse(transferenciaViewModel);
        }
    }
}
