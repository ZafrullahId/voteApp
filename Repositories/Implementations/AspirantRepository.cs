using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VoteApp.Data;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Repositories.Implementations
{
    public class AspirantRepository : BaseRepository<Aspirant>, IAspirantRepository
    {
        public AspirantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Aspirant> Get(string id)
        {
            var aspirant = await _context
                .Aspirants
                .Include(a => a.User)
                .Include(a => a.Position)
                .SingleOrDefaultAsync(a => a.Id == id);
            return aspirant;
        }

        public async Task<Aspirant> Get(Expression<Func<Aspirant, bool>> expression)
        {
            var newExpression = await _context
                .Aspirants
                .Include(n => n.User)
                .Include(n => n.Position)
                .SingleOrDefaultAsync(expression);
            return newExpression;
        }

        public async Task<ICollection<Aspirant>> GetAll()
        {
           var aspirant = await _context
                .Aspirants
                .Include(n => n.User)
                .Include(n => n.Position)
                .ToListAsync(); 
            return aspirant;
        }
    }
}
