using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profissonal.PPL.ModelVM
{
    public class RegisterVM
    {
        [Required (ErrorMessage ="Add Your Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "add Your Emil")]
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "add Your Password")]
        [DataType(DataType.Password)]
        [MaxLength(8, ErrorMessage = "Min 8 char")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Your Password")]
        [Compare("Password",ErrorMessage ="password not the same")]
        [DataType(DataType.Password)]
        [MaxLength(8, ErrorMessage = "Min 8 char")]
        public string ConfirmPassword { get; set; }
    }
}
