using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Base{
    public interface IBaseService<TEntity>
    {
        Task<TEntity> Add(TEntity model);
        Task<List<TEntity>> AddRange(List<TEntity> model);
        Task<TEntity> Update(TEntity model);
        Task<List<TEntity>> UpdateRange(List<TEntity> model);
        Task<List<TEntity>> GetAll();
        Task<TEntity> FindById(object id);
        Task<List<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Remove(object id);
        Task<List<TEntity>> RemoveRange(List<object> idList);
    }
}