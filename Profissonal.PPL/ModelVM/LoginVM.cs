

namespace Profissonal.PPL.ModelVM
{
    public class LoginVM
    {
        [Required (ErrorMessage ="add Your Emil")]
        [EmailAddress(ErrorMessage ="Email not valid")]
        public  string Email { get; set; }
        [Required(ErrorMessage = "add Your Password")]
        [DataType(DataType.Password )]
        public string Password { get; set; }
        public bool rememberme { get; set; }
    }
}
