using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VoteApp.Data;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Repositories.Implementations
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Address> Get(string id)
        {
            var address = await _context
                .Addresses
                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.Id == id);
            return address;
        }

        public async Task<Address> Get(Expression<Func<Address, bool>> expression)
        {
            var newExpression = await _context
                .Addresses
                .Include(a => a.User)
                .SingleOrDefaultAsync(expression);
            return newExpression;
        }

        public async Task<ICollection<Address>> GetAll()
        {
           var address = await _context
                .Addresses
                .Include(a => a.User)
                .ToListAsync();
            return address;
        }
    }
}
