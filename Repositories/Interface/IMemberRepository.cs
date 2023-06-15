using VoteApp.Models.Entities;
using System.Linq.Expressions;

namespace VoteApp.Repositories.Interface
{
    public interface IMemberRepository :IBaseRepository<Member>
    {
        Task<Member> Get(int id);
        Task<Member> Get(Expression<Func<Member, bool>> expression);
        Task<ICollection<Member>> GetAll();
    }
}
