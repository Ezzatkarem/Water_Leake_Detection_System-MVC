using Microsoft.Extensions.DependencyInjection;
using Professonal.DAL.Repo.Implementation;
using Professonal.DAL.Repo.UnitOfWork;
using Professonal.DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professonal.DAL.Common
{
    public  static class ModularDataAccessLayer
    {
        public static IServiceCollection AddModularDataAccessLayer( this IServiceCollection services ) 
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILeakRequestRepo, LeakRequestRepo>();
            services.AddScoped<IcommentRepo, CommentRepo>();
            services.AddScoped<IAppUserRepo, AppuserRepo>();
            services.AddScoped<IMediaItemRepo, MediaItemRepo>();
            services.AddScoped<IVedioRepo, VedioRepo>();
            return services;
        }
    }
}
