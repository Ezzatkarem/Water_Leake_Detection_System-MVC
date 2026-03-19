using Profissonal.PPL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profissonal.PPL.Service.Abstract
{
    public interface ICommentSrevice
    {
        Task<Response<IEnumerable<CommentVM>>> GetAllAsync();
        Task<Response<IEnumerable<CommentVM>>> GetAllByuserAsync();
        Task<Response<bool>> AddAsync(CommentVM model);
        Task<Response<bool>> DeleteAsync(CommentVM model);
        
        // ICommentSrevice.cs
        Task SetVisibilityAsync(int id, bool isVisible);

    }
}
