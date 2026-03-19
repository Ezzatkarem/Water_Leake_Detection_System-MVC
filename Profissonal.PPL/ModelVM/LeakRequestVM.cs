

using System.ComponentModel.DataAnnotations;

namespace Profissonal.PPL.ModelVM
{
    public class LeakRequestVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="أكتب اسمك")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = " اختار نوع المشكله")]
        public string ProplemType { get; set; }
        [Required(ErrorMessage = " اوصف المشكله")]

        public string Description { get; set; }
        [Required(ErrorMessage = "رقم تلفونك  ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = " العنوان  ")]

        public string Address { get; set; }
        // LeakRequestVM.cs
        public string? ClientNote { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt = DateTime.Now;
    }
}
