using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;
using campeonato_brasileiro_data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace campeonato_brasileiro_data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly CampeonatoBrasileiroDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(CampeonatoBrasileiroDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task Incluir(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task IncluirMuitos(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            await SaveChanges();
        }

        public async Task Alterar(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Excluir(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
