using VoteApp.Models.Entities;
using System.Linq.Expressions;
using VoteApp.Repositories.Interface;

namespace VoteApp.Repositories.Interface
{
    public interface IAssociationRepository : IBaseRepository<Association>
    {
        Task<Association> Get(string id);
        Task<Association> Get(Expression<Func<Association, bool>> expression);
        Task<ICollection<Association>> GetAll();
    }
}
