using System.Linq.Expressions;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Repositories.Implementations
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {

        public PositionRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        

        public async Task<Position> Get(int id)
        {
           var position = await _applicationDbContext.Positions.Include(x => x.PositionId).SingleOrDefaultAsync();
           return position;
        }

        public async Task<Position> Get(Expression<Func<Position, bool>> expression)
        {
           var position = await _applicationDbContext.Positions.SingleOrDefaultAsync();
           return position;
        }

        public async async <ICollection<Position>> GetAll()
        {
            var positions = await _applicationDbContext.Positions.ToListAsync();
            return positions;
        }

        
    }
}