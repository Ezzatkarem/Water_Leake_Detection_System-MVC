using Profissonal.PPL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profissonal.PPL.Service.Abstract
{
    public interface ILeakRequestService
    {
        Task<Response<LeakRequestVM>> GetByIdAsync(int id);
        Task<Response<IEnumerable<LeakRequestVM>>> GetAllAsync();
        Task<Response<IEnumerable<LeakRequestVM>>> FindAsync(Expression<Func<LeakRequestVM, bool>> expression);
        Task<int> AddAsync(LeakRequestVM model);
        Task<Response<bool>> AddRangeAsync(IEnumerable<LeakRequestVM> model);
        Task<Response<bool>> UpdateAsync(LeakRequestVM model);
        Task<Response<bool>> DeleteAsync(LeakRequestVM model);
        Task<Response<List<LeakRequestVM>>> GetLeakByPhoneAsync (string phone);
        Task<Response<bool>> DeleteRangeAsync(IEnumerable<LeakRequestVM> values);
        // ILeakRequestService.cs
        Task AddNoteAsync(int id, string note);
        Task<Response<bool>> UpdateStatusAsync(int id);
        Task<Response<List<LaekRequest>>> GetAllcompleteAsync(Expression<Func<LaekRequest, bool>> predicate);
        Task<Response<List<LaekRequest>>> GetAllPendingAsync(Expression<Func<LaekRequest, bool>> predicate);
        Task<Response<List<LaekRequest>>> GetAllinprogressAsync(Expression<Func<LaekRequest, bool>> predicate);

    }
}
