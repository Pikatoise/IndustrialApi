using System.Linq.Expressions;

namespace Loading.DAL.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity? GetById(int id);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);
    }
}