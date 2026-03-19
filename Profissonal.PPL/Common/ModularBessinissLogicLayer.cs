

using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Profissonal.PPL.Service.Implement;

namespace Profissonal.PPL.Common
{
    public static class ModularBessinissLogicLayer
    {
        public static IServiceCollection AddModularBessinissLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<IAppUserService, AppuserService>();
            services.AddScoped<IMediaItemservice, MediaItemService>();
            services.AddScoped<ILeakRequestService, LeakRequestService>();
            services.AddScoped<ICommentSrevice, CommentService>();
            services.AddScoped<IAcountService, AccountService>();
            services.AddScoped<IvedioService, VedioService>();
            return services;
        }
    }
}
