namespace voteApp.Repositories.Implementations
{
    public class ResultRepository :BaseRepository<Result>,IResultRepository
    {
        public readonly ApplicationDbContext _context;
        public ResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       public async Task<Result> Get(int id)
       {
            var result = await _context.Results.Include(a => a.Id == id).SingleOrDefaultAsync();
            return result;
       } 
       public async Task<Result> Get(Expression<Func<Result, bool>> expression)
       {
        var result = await _context.Results.SingleOrDefaultAsync(expression);
        return result;
       }
       public async Task<ICollection<Result>> GetAll()
       {
         return await _context.Results.ToListAsync();
       }

    }
}