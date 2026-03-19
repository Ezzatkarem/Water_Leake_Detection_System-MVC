

namespace Professonal.DAL.Repo.Implementation
{
    public class MediaItemRepo : Reposatory<MediaItem>, IMediaItemRepo
    {
        public MediaItemRepo(ProfessionalDBContext context) : base(context)
        {
        }
    }
}
