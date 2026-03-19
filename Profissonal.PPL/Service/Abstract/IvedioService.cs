using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profissonal.PPL.Service.Abstract
{
    public interface IvedioService
    {
        Task<Response<bool>> AddAsync(VedioVM vedio);
        Task<Response<IEnumerable<VedioVM>>> GetAllAsync();
        Task<Response<bool>> DeleteAsync(int id);

    }
}
