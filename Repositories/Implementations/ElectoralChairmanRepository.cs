using System.Linq.Expressions;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Repositories.Implementations
{
    public class ElectoralChairmanRepository : BaseRepository<ElectoralChairmanRepository>, IElectoralChairmanRepository
    {
       
        public ElectoralChairmanRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        
        public async Task<ElectoralChairman> Get(int id)
        {
            var electoralChairman = await _applicationDbContext.ElectoralChairmans.Include(e => e.ChairmanId).SingleOrDefaultAsync();   
            return electoralChairman;
        }

        public async Task<ElectoralChairman> Get(Expression<Func<ElectoralChairman, bool>> expression)
        {
           var electoralChairman = await _applicationDbContext.ElectoralChairmans.SingleOrDefaultAsync();
           return electoralChairman; 
        }

        public async Task<ICollection<ElectoralChairman>> GetAll()
        {
            var electoralChairmans = await _applicationDbContext.ElectoralChairmans.ToListAsync();
            return electoralChairmans;
        }

        
    }
}