using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using campeonato_brasileiro_data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace campeonato_brasileiro_data.Repositories
{
    public class TransferenciaRepository : Repository<Transferencia>, ITransferenciaRepository
    {
        public TransferenciaRepository(CampeonatoBrasileiroDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Transferencia>> ObterTransferenciasJogadorTime()
        {
            return await _context.Transferencias.AsNoTracking()
                .Include(t => t.Jogador)
                .Include(t => t.TimeOrigem)
                .Include(t => t.TimeDestino)
                .ToListAsync();
        }

        public async Task<Transferencia> ObterTransferenciaJogadorTime(Guid id)
        {
            return await _context.Transferencias.AsNoTracking()
                .Include(t => t.Jogador)
                .Include(t => t.TimeOrigem)
                .Include(t => t.TimeDestino)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
