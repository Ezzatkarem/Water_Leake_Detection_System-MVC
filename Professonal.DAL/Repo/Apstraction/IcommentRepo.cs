using Professonal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professonal.DAL.Repo.Apstraction
{
    public interface IcommentRepo : IRepostory<Comment>
    {
         Task<IEnumerable<Comment>> GetAllByuserAsync();
    }

}
