using campeonato_brasileiro_business.Models;
using System.Linq.Expressions;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<List<TEntity>> ObterTodos();

        Task<TEntity> ObterPorId(Guid id);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task Incluir(TEntity entity);

        Task IncluirMuitos(List<TEntity> entities);

        Task Alterar(TEntity entity);

        Task Excluir(Guid id);

        Task<int> SaveChanges();
    }
}
