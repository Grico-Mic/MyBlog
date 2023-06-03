using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBlog.Models
{
   public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
