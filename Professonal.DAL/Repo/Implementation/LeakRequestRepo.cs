   

namespace Professonal.DAL.Repo.Implementation
{
    public class LeakRequestRepo : Reposatory<LaekRequest>, ILeakRequestRepo
    {
        public LeakRequestRepo(ProfessionalDBContext context) : base(context)
        {
        }

        public async Task<List<LaekRequest>> GetByPhoneNumber(string phoneNumber)
        {
            return await _dbset.Where(p => p.Phone == phoneNumber).ToListAsync();
        }
        public async Task<List<LaekRequest>> GetAllcAsync(Expression<Func<LaekRequest, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

    }
}
