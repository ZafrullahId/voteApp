namespace voteApp.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
           __context = context; 
        }
         public async Task<User> Get(int id)
       {
            var user = await _context.Users
            .Include(c => c.UserRoles)
            .ThenInclude(c => c.Role)
            .Include(x => x.Address)
            .SingleOrDefaultAsync(c => c.Id == id);
            return user;
       } 
       public async Task<User> Get(Expression<Func<User, bool>> expression)
       {
         var user = await _context.Users
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.Role)
                .Include(c =>c.Address)
                .SingleOrDefaultAsync(expression);
            return user;
       }
       public async Task<ICollection<User>> GetAll()
       {
           return await _context.Users
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.Role)
                .Include(c => c.Address)
                .ToListAsync();
       }
    }
}