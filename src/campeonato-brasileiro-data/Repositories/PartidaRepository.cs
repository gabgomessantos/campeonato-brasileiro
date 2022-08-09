using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using campeonato_brasileiro_data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace campeonato_brasileiro_data.Repositories
{
    public class PartidaRepository : Repository<Partida>, IPartidaRepository
    {
        public PartidaRepository(CampeonatoBrasileiroDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Partida>> ObterPartidasTorneioTime()
        {
            return await _context.Partidas.AsNoTracking()
                .Include(p => p.Torneio)
                .Include(p => p.TimeMandante)
                .Include(p => p.TimeVisitante)
                .ToListAsync();
        }

        public async Task<Partida> ObterPartidaTorneioTime(Guid id)
        {
            return await _context.Partidas.AsNoTracking()
                .Include(p => p.Torneio)
                .Include(p => p.TimeMandante)
                .Include(p => p.TimeVisitante)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Partida> ObterPartidaTorneioTimeEventos(Guid id)
        {
            return await _context.Partidas.AsNoTracking()
                .Include(p => p.Torneio)
                .Include(p => p.TimeMandante)
                .Include(p => p.TimeVisitante)
                .Include(p => p.Eventos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Partida>> ObterPartidasPorTorneio(Guid torneioId)
        {
            return await _context.Partidas.AsNoTracking()
                .Include(p => p.Torneio)
                .Include(p => p.TimeMandante)
                .Include(p => p.TimeVisitante)
                .Where(p => p.TorneioId == torneioId)
                .ToListAsync();
        }

        public async Task ExcluirMuitos(List<Partida> partidas)
        {
            _context.Partidas.RemoveRange(partidas);
            await SaveChanges();
        }
    }
}
