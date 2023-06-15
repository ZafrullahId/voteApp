
using System.Linq.Expressions;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace VoteApp.Repositories.Interface
{
    public interface IVotingRepository : IBaseRepository<Vote>
    {
        Task<Vote> Get(int id);
        Task<Vote> Get(Expression<Func<Vote, bool>> expression);
        Task<ICollection<Vote>> GetAll();

    }
}