using System;
using System.Collections.Generic;
using System.Text;

namespace Professonal.DAL.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string ContentEn { get; set; }
        public DateTime CreatedAT { get; set; }
        public bool isRead { get; set; } = false;

    }
}
