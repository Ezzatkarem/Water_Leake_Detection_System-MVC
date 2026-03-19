using Professonal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professonal.DAL.Repo.Implementation
{
    public class CommentRepo : Reposatory<Comment>, IcommentRepo
    {
        public CommentRepo(ProfessionalDBContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Comment>> GetAllByuserAsync()
        {
            return await _dbset.Where(p=>p.isRead==true).ToListAsync();
        }

    }
}
