using VoteApp.Models.Entities;
using System.Linq.Expressions;
using VoteApp.Repositories.Interface;

namespace VoteApp.Repositories.Interface
{
    public interface IAspirantRepository : IBaseRepository<Aspirant>
    {
        Task<Aspirant> Get(string id);
        Task<Aspirant> Get(Expression<Func<Aspirant, bool>> expression);
        Task<ICollection<Aspirant>> GetAll();
    }
}
