
namespace Profissonal.PPL.Service.Abstract
{
    public interface IAcountService
    {
        Task<Response<string>> LoginAsync(LoginVM login);
        Task<Response<string>> RegisterAdminAsync(RegisterVM model);
        Task<Response<List<AdminVM>>> GetAllAdminAsync();
        Task LogOutAsync();
        Task<Response<bool>> DeleteAdminAsync(string id);

    }
}
