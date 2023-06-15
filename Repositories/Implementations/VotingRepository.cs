namespace voteApp.Repositories.Implementations
{
    public class VotingRepository : BaseRepository<Voting>, IVotingRepository
    {
        public readonly ApplicationDbContext _context;
        public VotingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Voting> Get(int id)
       {
            var voting = await _context.Votings.Include(a => a.Id == id).SingleOrDefaultAsync();
            return voting;
       } 
       public async Task<Voting> Get(Expression<Func<Voting, bool>> expression)
       {
        var voting = await _context.Votings.SingleOrDefaultAsync(expression);
        return voting;
       }
       public async Task<ICollection<Voting>> GetAll()
       {
          return await _context.Votings.ToListAsync();
       }
    }
}