namespace voteApp.Repositories.Implementations
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public  readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
         public async Task<Role> Get(int id)
       {
            var role = _context.Roles
                .Include(c=> c.UserRoles)
                .ThenInclude(c => c.User)
                .SingleOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);
            return role;
       } 
       public async Task<Role> Get(Expression<Func<Role, bool>> expression)
       {
             var role = _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                 .Where(c => c.IsDeleted == false)
                .SingleOrDefaultAsync(expression);
            return role;
       }
       public async Task<ICollection<Role>> GetAll()
       {
         return await _context.Roles.ToListAsync();
       }
        
    }
}