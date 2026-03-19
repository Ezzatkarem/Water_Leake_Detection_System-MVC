


using Profissonal.PPL.ModelVM;

namespace Profissonal.PPL.Service.Abstract
{
    public interface IAppUserService
    {
        Task<Response<AppUserVM>> GetByIdAsync(int id);
        Task<Response< IEnumerable<AppUserVM>>> GetAllAsync();
        Task<Response< IEnumerable<AppUserVM>>> FindAsync(Expression<Func<AppUserVM, bool>> expression);
        Task <Response<bool>> AddAsync(AppUserVM model);
        Task <Response<bool>> AddRangeAsync(IEnumerable<AppUserVM> model);
        Task<Response<bool>> UpdateAsync(AppUserVM model);
        Task<Response<bool>> DeleteAsync(AppUserVM model);
        Task <Response<bool>> DeleteRangeAsync(IEnumerable<AppUserVM> values);
    }
}
