using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
       
        [Required]
        public DateTime DateCreated { get; set; }

    }
}
