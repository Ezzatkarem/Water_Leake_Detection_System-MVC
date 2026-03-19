using System;
using System.Collections.Generic;
using System.Text;

namespace Professonal.DAL.Entities
{
    public class LaekRequest
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ProplemType { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; } = "Pending";
        public string? ClientNote { get; set; } // ← ملاحظة العميل

        public DateTime CreatedAt { get; set; } = DateTime.Now;



    }
}
