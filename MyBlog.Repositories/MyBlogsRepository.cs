using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Repositories
{
    public class MyBlogsRepository
    {
        public List<Blog> Blogs { get; set; }
        public MyBlogsRepository()
        {
            var myBlog1 = new Blog();
            myBlog1.Id = 1;
            myBlog1.Title = "Hello from me";
            myBlog1.Description = "This is some description";
            myBlog1.DateCreated = DateTime.Now;

            var myBlog2 = new Blog();
            myBlog2.Id = 2;
            myBlog2.Title = "Hello from the other side";
            myBlog2.Description = "This is some description number 2.";
            myBlog2.DateCreated = DateTime.Now;

            Blogs = new List<Blog> { myBlog1, myBlog2 };
        }

        public Blog GetById(int id)
        {
            return Blogs.FirstOrDefault(x => x.Id == id);
        }

        public List<Blog> GetAll()
        {
            return Blogs;
        }


    }
}
