using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User.Application.Contracts.Persistence;
using User.Domain.Common;
using User.Infrastructure.Persistence.Context;

namespace User.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly UserContext _ctx;
        private readonly DbSet<T> _query;

        public RepositoryBase(UserContext ctx)
        {
            _ctx = ctx;
            _query = _ctx.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _query.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _query.AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _query.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
