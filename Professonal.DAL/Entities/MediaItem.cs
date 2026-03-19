using System;
using System.Collections.Generic;
using System.Text;

namespace Professonal.DAL.Entities
{
    public class MediaItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string FilePath { get; set; }

        public DateTime CreatedAt = DateTime.Now;
    }
}
