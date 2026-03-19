using Professonal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professonal.DAL.Repo.Implementation
{
    public class AppuserRepo : Reposatory<AppUser> ,IAppUserRepo
    {
        public AppuserRepo (ProfessionalDBContext context):base(context) { }
    }
}
