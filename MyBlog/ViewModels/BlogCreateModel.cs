using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class BlogCreateModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 500, MinimumLength = 10)]
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
       
    }
}
