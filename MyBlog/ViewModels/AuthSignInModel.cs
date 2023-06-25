using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels
{
    public class AuthSignInModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
