using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professonal.DAL.Repo.Implementation
{
    public class VedioRepo : Reposatory<Vedio>, IVedioRepo
    {
        public VedioRepo(ProfessionalDBContext context) : base(context)
        {
        }
    }
}
