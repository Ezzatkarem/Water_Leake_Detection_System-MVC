

using Professonal.DAL.Entities;

namespace Professonal.DAL.Repo.Apstraction
{
    public interface ILeakRequestRepo :IRepostory<LaekRequest>
    {
        Task<List<LaekRequest>> GetByPhoneNumber(string phoneNumber);
        Task<List<LaekRequest>> GetAllcAsync(Expression<Func<LaekRequest, bool>> predicate);
    }
}
