using VoteApp.Models;
using VoteApp.Models.Entities;
using System.Linq.Expressions;

namespace VoteApp.Repositories.Interface
{
    public interface IUserRepository :IBaseRepository<User>
    {
            Task<User> Get(int id);
            Task<User> Get(Expression<Func<User, bool>> expression);
            Task<ICollection<User>> GetAll();
        
    }
}
