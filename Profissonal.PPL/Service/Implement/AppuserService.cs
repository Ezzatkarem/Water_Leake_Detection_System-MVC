
namespace Profissonal.PPL.Service.Implement
{
    public class AppuserService : IAppUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public AppuserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<Response<bool>> AddAsync(AppUserVM model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> AddRangeAsync(IEnumerable<AppUserVM> model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteAsync(AppUserVM model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteRangeAsync(IEnumerable<AppUserVM> values)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<AppUserVM>>> FindAsync(Expression<Func<AppUserVM, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<AppUserVM>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<AppUserVM>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateAsync(AppUserVM model)
        {
            throw new NotImplementedException();
        }
    }
}
