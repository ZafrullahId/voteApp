using VoteApp.Models.Entities;
using System.Linq.Expressions;

namespace VoteApp.Repositories.Interface
{
    public interface IElectionRepository : IBaseRepository<Election>
    {
        Task<Electionr> Get(int id);
        Task<Election> Get(Expression<Func<Election, bool>> expression);
        Task<ICollection<Election>> GetAll();
    }
}
