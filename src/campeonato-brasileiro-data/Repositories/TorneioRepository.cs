using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using campeonato_brasileiro_data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace campeonato_brasileiro_data.Repositories
{
    public class TorneioRepository : Repository<Torneio>, ITorneioRepository
    {
        public TorneioRepository(CampeonatoBrasileiroDbContext context) : base(context)
        {
        }

        public async Task<Torneio> ObterTorneioTimes(Guid id)
        {
            return await _context.Torneios.AsNoTracking()
                .Include(t => t.Times)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Torneio> ObterTorneioTimesPartidas(Guid id)
        {
            return await _context.Torneios.AsNoTracking()
                .Include(t => t.Times)
                .Include(t => t.Partidas)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
