using VoteApp.Models.Entities
using System.Linq.Expressions;
namespace VoteApp.Repositories.Interface
{
    public interface IVotingRepository : IBaseRepository<Voting>
    {
          Task<Voting> Get(int id);
            Task<Voting> Get(Expression<Func<Voting, bool>> expression);
            Task<ICollection<Voting>> GetAll();
        
    }
}