using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using campeonato_brasileiro_data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campeonato_brasileiro_data.Repositories
{
    public class TimeRepository : Repository<Time>, ITimeRepository
    {
        public TimeRepository(CampeonatoBrasileiroDbContext context) : base(context)
        {
        }

        public async Task<Time> ObterTimeJogadores(Guid id)
        {
            return await _context.Times.AsNoTracking()
                .Include(t => t.Jogadores)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Time> ObterTimeJogadoresTorneios(Guid id)
        {
            return await _context.Times.AsNoTracking()
                .Include(t => t.Jogadores)
                .Include(t => t.Torneios)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
