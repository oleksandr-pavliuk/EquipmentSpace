using EquipmentSpace.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace EquipmentSpace.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await _dbSet.AsNoTracking().ToListAsync();

        public T Read(Func<T, bool> predicate) =>           //read entity
            _dbSet.AsNoTracking().Where<T>(predicate).FirstOrDefault();
        
        public async Task CreateAsync(T entity)          //create entity
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
