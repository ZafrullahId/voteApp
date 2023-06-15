using VoteApp.Models.Entities;
using System.Linq.Expressions;
using VoteApp.Repositories.Interface;

namespace VoteApp.Repositories.Interface
{
    public interface IResultRepository :IBaseRepository<Result>
    {
        Task<Result> Get(int id);
        Task<Result> Get(Expression<Func<Result, bool>> expression);
        Task<ICollection<Result>> GetAll();
    }
}
