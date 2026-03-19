

namespace Professonal.DAL.Repo.Implementation
{
    public class Reposatory<T> : IRepostory<T> where T : class
    {
        private readonly ProfessionalDBContext _context;
        protected readonly DbSet<T> _dbset;  //改了: camelCase

        // Constructor واحد بس بياخد context
        public Reposatory(ProfessionalDBContext context)
        {
            _context = context;
            _dbset = context.Set<T>();  // جيب الـ DbSet من الـ context
        }

        public async Task AddAsync(T item)
        {
            await _dbset.AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<T> items)  //改了: items مش item
        {
            await _dbset.AddRangeAsync(items);
        }

        public Task DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
            return Task.CompletedTask;
        }

        public Task DeleteRangeAsync(IEnumerable<T> values)
        {
            _dbset.RemoveRange(values);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public Task UpdateAsync(T item)
        {
            _dbset.Update(item);
            return Task.CompletedTask;
        }
    }
}