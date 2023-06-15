using VoteApp.Models.Entities;
using System.Linq.Expressions;

namespace VoteApp.Repositories.Interface
{
    public interface IAssociationRepository : IBaseRepository<Association>
    {
        Task<Association> Get(int id);
        Task<Association> Get(Expression<Func<Association, bool>> expression);
        Task<ICollection<Association>> GetAll();
    }
}
