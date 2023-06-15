using VoteApp.Models.Entities;
using System.Linq.Expressions;

namespace VoteApp.Repositories.Interface
{
    public interface IPositionRepository : IBaseRepository<Position>
    {
        Task<Position> Get(int id);
        Task<Position> Get(Expression<Func<Position, bool>> expression);
        Task<ICollection<Position>> GetAll();
    }
}
