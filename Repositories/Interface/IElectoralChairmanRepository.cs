using VoteApp.Models.Entities;
using System.Linq.Expressions;

namespace VoteApp.Repositories.Interface
{
    public interface IElectoralChairmanRepository : IBaseRepository<ElectoralChairman>
    {
        Task<ElectoralChairman> Get(int id);
        Task<ElectoralChairman> Get(Expression<Func<ElectoralChairman, bool>> expression); 
        Task<ICollection<ElectoralChairman>> GetAll();
    }
}
