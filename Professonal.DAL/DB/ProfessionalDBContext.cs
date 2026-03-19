using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Professonal.DAL.Entities;

namespace Professonal.DAL.DB
{
    public class ProfessionalDBContext : IdentityDbContext<AppUser>
    {
        public ProfessionalDBContext(DbContextOptions<ProfessionalDBContext> options)
            : base(options)
        {
        }

        public DbSet<LaekRequest> LaekRequests { get; set; }  // PascalCase للممتلكات
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<Vedio> vedios { get; set; }



    }
}