using AutoMapper;
using campeonato_brasileiro_api.ViewModels;
using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using Microsoft.AspNetCore.Mvc;

namespace campeonato_brasileiro_api.Controllers
{
    [Route("api/times")]
    [ApiController]
    public class TimesController : MainController
    {
        private readonly ITimeService _timeService;
        private readonly ITorneioService _torneioService;
        private readonly IMapper _mapper;

        public TimesController(
            INotificador notificador,
            IMapper mapper,
            ITimeService timeService,
            ITorneioService torneioService
            ) : base(notificador)
        {
            _mapper = mapper;
            _timeService = timeService;
            _torneioService = torneioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeViewModel>>> ObterTodos()
        {
            return CustomResponse(_mapper.Map<List<TimeViewModel>>(
                await _timeService.ObterTodos())?.OrderBy(j => j.Nome));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TimeViewModel>> ObterTimeJogadores(Guid id)
        {
            return CustomResponse(_mapper.Map<TimeViewModel>(await _timeService.ObterTimeJogadores(id)));
        }

        [HttpPost]
        public async Task<ActionResult<TimeViewModel>> Incluir([FromBody] TimeViewModel timeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _timeService.Incluir(_mapper.Map<Time>(timeViewModel));

            return CustomResponse(timeViewModel);
        }

        [HttpPost("pre-definidos")]
        public async Task<ActionResult<TimeViewModel>> IncluirPreDefinido(bool incluirAutomatico)
        {
            if (incluirAutomatico)
            {
                foreach (var time in TimesPredefinidos().Result)
                {
                    await _timeService.Incluir(time);
                }
            }
            
            return CustomResponse();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeViewModel>> Alterar(Guid id, [FromBody] TimeViewModel timeViewModel)
        {
            if (id != timeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado no objeto.");
                return CustomResponse(timeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _timeService.Alterar(_mapper.Map<Time>(timeViewModel));

            return CustomResponse(timeViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeViewModel>> Excluir(Guid id)
        {
            var timeViewModel = _mapper.Map<TorneioViewModel>(await _timeService.ObterPorId(id));

            if (timeViewModel == null) return NotFound();

            await _timeService.Excluir(id);

            return CustomResponse(timeViewModel);
        }

        private async Task<List<Time>> TimesPredefinidos()
        {
            var torneioA = await _torneioService.ObterPorNome("Brasileirão 2022 Série A");
            var torneioB = await _torneioService.ObterPorNome("Brasileirão 2022 Série B");
            var times = new List<Time>();
            var torneiosA = new List<Torneio>();
            var torneiosB = new List<Torneio>();

            if (torneioA == null)
            {
                torneioA = new Torneio { Nome = "Brasileirão 2022 Série A" };
                await _torneioService.Incluir(torneioA);
            }
            if (torneioB == null)
            {
                torneioB = new Torneio { Nome = "Brasileirão 2022 Série B" };
                await _torneioService.Incluir(torneioB);
            }

            torneiosA.Add(torneioA);
            torneiosB.Add(torneioB);
            //série A
            times.Add(new Time { Nome = "América-MG", Localidade = "Minas Gerais", Torneios = torneiosA });
            times.Add(new Time { Nome = "Athletico-PR", Localidade = "Paraná", Torneios = torneiosA });
            times.Add(new Time { Nome = "Atlético-GO", Localidade = "Goiás", Torneios = torneiosA });
            times.Add(new Time { Nome = "Atlético-MG", Localidade = "Minas Gerais", Torneios = torneiosA });
            times.Add(new Time { Nome = "Avaí", Localidade = "Santa Catarina", Torneios = torneiosA });
            times.Add(new Time { Nome = "Botafogo", Localidade = "Rio de Janeiro", Torneios = torneiosA });
            times.Add(new Time { Nome = "Bragantino", Localidade = "São Paulo", Torneios = torneiosA });
            times.Add(new Time { Nome = "Ceará", Localidade = "Ceará", Torneios = torneiosA });
            times.Add(new Time { Nome = "Corinthians", Localidade = "São Paulo", Torneios = torneiosA });
            times.Add(new Time { Nome = "Coritiba", Localidade = "Curitiba", Torneios = torneiosA });
            times.Add(new Time { Nome = "Cuiabá", Localidade = "Mato Grosso", Torneios = torneiosA });
            times.Add(new Time { Nome = "Flamengo", Localidade = "Rio de Janeiro", Torneios = torneiosA });
            times.Add(new Time { Nome = "Fluminense", Localidade = "Rio de Janeiro", Torneios = torneiosA });
            times.Add(new Time { Nome = "Fortaleza", Localidade = "Ceará", Torneios = torneiosA });
            times.Add(new Time { Nome = "Goiás", Localidade = "Goiás", Torneios = torneiosA });
            times.Add(new Time { Nome = "Internacional", Localidade = "Rio Grande do Sul", Torneios = torneiosA });
            times.Add(new Time { Nome = "Juventude", Localidade = "Rio Grande do Sul", Torneios = torneiosA });
            times.Add(new Time { Nome = "Palmeiras", Localidade = "São Paulo", Torneios = torneiosA });
            times.Add(new Time { Nome = "Santos", Localidade = "São Paulo", Torneios = torneiosA });
            times.Add(new Time { Nome = "São Paulo", Localidade = "São Paulo", Torneios = torneiosA });

            //série B
            times.Add(new Time { Nome = "Bahia", Localidade = "Bahia", Torneios = torneiosB });
            times.Add(new Time { Nome = "Brusque", Localidade = "Santa Catarina", Torneios = torneiosB });
            times.Add(new Time { Nome = "Chapecoense", Localidade = "Santa Catarina", Torneios = torneiosB });
            times.Add(new Time { Nome = "CRB", Localidade = "Alagoas", Torneios = torneiosB });
            times.Add(new Time { Nome = "Criciúma", Localidade = "Santa Catarina", Torneios = torneiosB });
            times.Add(new Time { Nome = "Cruzeiro", Localidade = "Minas Gerais", Torneios = torneiosB });
            times.Add(new Time { Nome = "CSA", Localidade = "Alagoas", Torneios = torneiosB });
            times.Add(new Time { Nome = "Grêmio", Localidade = "Rio Grande do Sul", Torneios = torneiosB });
            times.Add(new Time { Nome = "Guarani", Localidade = "São Paulo", Torneios = torneiosB });
            times.Add(new Time { Nome = "Ituano", Localidade = "São Paulo", Torneios = torneiosB });
            times.Add(new Time { Nome = "Londrina", Localidade = "Paraná", Torneios = torneiosB });
            times.Add(new Time { Nome = "Náutico", Localidade = "Pernambuco", Torneios = torneiosB });
            times.Add(new Time { Nome = "Novorizontino", Localidade = "São Paulo", Torneios = torneiosB });
            times.Add(new Time { Nome = "Operário-PR", Localidade = "Paraná", Torneios = torneiosB });
            times.Add(new Time { Nome = "Ponte Preta", Localidade = "São Paulo", Torneios = torneiosB });
            times.Add(new Time { Nome = "Sampaio Corrêa", Localidade = "Maranhão", Torneios = torneiosB });
            times.Add(new Time { Nome = "Sport", Localidade = "Pernambuco", Torneios = torneiosB });
            times.Add(new Time { Nome = "Tombense", Localidade = "Minas Gerais", Torneios = torneiosB });
            times.Add(new Time { Nome = "Vasco", Localidade = "Rio de Janeiro", Torneios = torneiosB });
            times.Add(new Time { Nome = "Vila Nova", Localidade = "Goiás", Torneios = torneiosB });

            return times;
        }
    }
}
