using Profissonal.PPL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profissonal.PPL.Service.Abstract
{
    public interface IMediaItemservice
    {
        Task<Response<IEnumerable<MediaItemVM>>> GetAllAsync();
        Task<Response<bool>> AddAsync(MediaItemVM model,string uploadspath);
        Task<Response<bool>> DeleteAsync( int id,string uploadspath);
    }
}
