

using Microsoft.AspNetCore.Http;

namespace Profissonal.PPL.ModelVM
{
    public class MediaItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string? FilePath { get; set; }
        public IFormFile? ImageFile { get; set; }


        public DateTime CreatedAt = DateTime.Now;
    }
}
