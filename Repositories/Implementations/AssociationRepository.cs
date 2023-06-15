using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VoteApp.Data;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Repositories.Implementations
{
    public class AssociationRepository : BaseRepository<Association>, IAssociationRepository
    {
        public AssociationRepository(ApplicationDbContext content)
        {
            _context = content;
        }

        public async Task<Association> Get(string id)
        {
            var association = await _context
                .Associations
                .Include(a => a.AssociationMembers)
                .ThenInclude(a => a.Member)
                .Include(a => a.User)
                .Include(a => a.Elections)
                .SingleOrDefaultAsync(a => a.Id == id);
            return association;
        }

        public async Task<Association> Get(Expression<Func<Association, bool>> expression)
        {
            var newExpression = await _context
                 .Associations
                 .Include(a => a.AssociationMembers)
                 .ThenInclude(a => a.Member)
                 .Include(a => a.User)
                 .Include(a => a.Elections)
                 .SingleOrDefaultAsync(expression);
            return newExpression;
        }

        public async Task<ICollection<Association>> GetAll()
        {
            var association = await _context
                 .Associations
                 .Include(a => a.AssociationMembers)
                 .ThenInclude(a => a.Member)
                 .Include(a => a.User)
                 .Include(a => a.Elections)
                 .ToListAsync();
            return association;
        }
    }
}
