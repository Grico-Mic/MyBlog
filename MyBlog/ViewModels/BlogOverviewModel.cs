using System;

namespace MyBlog.ViewModels
{
    public class BlogOverviewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
       
    }
}
