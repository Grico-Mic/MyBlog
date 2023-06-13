using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels
{
    public class BlogUpdateModel
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
        public DateTime? DateUpdated { get; set; }
    }
}
