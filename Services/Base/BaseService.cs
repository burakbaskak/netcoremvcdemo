using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data;
using Data.Base;
using Microsoft.EntityFrameworkCore;

namespace Services.Base{

    public abstract class BaseService<TEntity> : IBaseService<TEntity> 
        where TEntity: class, IBaseEntity {
            
        public BaseService(DemoDbContext context)
        {
            _context = context;
        }

        private DemoDbContext _context;

        public DbSet<TEntity> EntitySet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public async Task<TEntity> Add(TEntity model)
        {
             await EntitySet.AddAsync(model);
             await _context.SaveChangesAsync();

             return model;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> model)
        {
             await EntitySet.AddRangeAsync(model);
             await _context.SaveChangesAsync();

             return model;
        }

        public async Task<TEntity> Update(TEntity model)
        {
            EntitySet.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> model)
        {
            EntitySet.UpdateRange(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<List<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return await EntitySet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FindById(object id)
        {
            return await this.EntitySet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<TEntity> Remove(object id)
        {
            var entity = FindById(id);
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            await _context.SaveChangesAsync();

            return await entity;
        }
        
        public async Task<List<TEntity>> RemoveRange(List<object> idList)
        {
            var entity = Filter(a => idList.Contains(a.Id));
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            await _context.SaveChangesAsync();

            return await entity;
        }
    }
}