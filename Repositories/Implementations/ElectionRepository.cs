using System.Linq.Expressions;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Repositories.Implementations
{
    public class ElectionRepository : BaseRepository<Election> , IElectionRepository
    {
        public ElectionRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        

        public async Task<Election> Get(int id)
        {
            var election = await _applicationDbContext.Elections.Include(a => a.Id).SingleOrDefaultAsync();
            return election;
        }

        public async Task<Election> Get(Expression<Func<Election, bool>> expression)
        {
            var election = await _applicationDbContext.Elections.SingleOrDefaultAsync();
            return election;
            
        }

        public async Task<Election> GetAll()
        {
            var elections = await _applicationDbContext.Elections.ToListAsync();
            return elections;
        }

        
    }
}