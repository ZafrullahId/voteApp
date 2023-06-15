using VoteApp.Models.Entities;
using System.Linq.Expressions;
using VoteApp.Repositories.Interface;

namespace VoteApp.Repositories.Interface
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<Address> Get(int id);
        Task<Address> Get(Expression<Func<Address, bool>> expression);
        Task<ICollection<Address>> GetAll();
    }
}
