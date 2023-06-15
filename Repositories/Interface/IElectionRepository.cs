using VoteApp.Models.Entities;
using System.Linq.Expressions;
using VoteApp.Repositories.Interface;

namespace VoteApp.Repositories.Interface
{
    public interface IElectionRepository : IBaseRepository<Election>
    {
        Task<Election> Get(int id);
        Task<Election> Get(Expression<Func<Election, bool>> expression);
        Task<ICollection<Election>> GetAll();
    }
}
