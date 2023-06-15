using System.Linq.Expressions;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Repositories.Implementations
{
    public class MemeberRepository : BaseRepository<Memeber> , IMemberRepository
    {
        public MemberRespository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;   
        }

        
        public async Task<Member> Get(int id)
        {
            var member = await _applicationDbContext.Members.Include(m => m.Id).SingleOrDefaultAsync();
            return member;
        }

        public async Task<Member> Get(Expression<Func<Member, bool>> expression)
        {
            var member = await _applicationDbContext.Members.SingleOrDefaultAsync();
            return member; 
        }

        public async async <ICollection<Member>> GetAll()
        {
            var members = await _applicationDbContext.Members.ToListAsync();
            return members;
        }

        
    }
}