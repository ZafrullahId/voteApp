using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VoteApp.Data;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context;
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> Save()
        {
            var newSave = await _context.SaveChangesAsync();
            return newSave;
        }

        public T Update(T entity)
        {
             _context.Update(entity);
            return entity;
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> expression)
        {
            var newExpression = await _context.Set<T>().AnyAsync(expression);
            return newExpression;
        }
    }
}
