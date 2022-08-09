using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using campeonato_brasileiro_data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace campeonato_brasileiro_data.Repositories
{
    public class JogadorRepository : Repository<Jogador>, IJogadorRepository
    {
        public JogadorRepository(CampeonatoBrasileiroDbContext context) : base(context)
        {
        }

        public async Task<List<Jogador>> ObterJogadoresTime()
        {
            return await _context.Jogadores.AsNoTracking()
                .Include(j => j.Time)
                .ToListAsync();
        }

        public async Task<Jogador> ObterJogadorTimeTransferencias(Guid id)
        {
            return await _context.Jogadores.AsNoTracking()
                .Include(j => j.Time)
                .Include(j => j.Transferencias)
                .FirstOrDefaultAsync(j => j.Id == id);
        }
    }
}
