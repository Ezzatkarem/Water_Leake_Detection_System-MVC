


namespace Professonal.DAL.Repo.Apstraction
{
    public interface IRepostory <T> where T : class
    {
        Task<T> GetByIdAsync(int  id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync (Expression <Func<T,bool>> expression);
        Task AddAsync(T item);
        Task AddRangeAsync(IEnumerable< T> item);
        Task UpdateAsync (T item);
        Task DeleteAsync (T entity);
        Task DeleteRangeAsync (IEnumerable <T> values);


    }
}
