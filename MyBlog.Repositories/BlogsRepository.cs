using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class BlogsRepository : BaseRepository<Blog>, IMyBlogsRepository
    {
     
        public BlogsRepository(MyBlogDbContext context) : base(context)
        {
            
        }
        public List<Blog> GetBlogByTitle(string title)
        {
            return _context.MyBlog.Where(x => x.Title.Contains(title)).ToList();
        }

       
    }
}
