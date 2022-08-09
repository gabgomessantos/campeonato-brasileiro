using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using campeonato_brasileiro_data.Contexts;

namespace campeonato_brasileiro_data.Repositories
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(CampeonatoBrasileiroDbContext context) : base(context)
        {
        }
    }
}
