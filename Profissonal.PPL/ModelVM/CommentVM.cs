

namespace Profissonal.PPL.ModelVM
{
    public class CommentVM
    {
        public int ID { get; set; }
        public string Content { get; set; }=string.Empty;
        public string? Author { get; set; }
        public string? ContentEn { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isread { get; set; }
    }
}
