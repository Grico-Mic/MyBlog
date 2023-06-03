using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class BlogsRepository : IMyBlogsRepository
    {
        private MyBlogDbContext _context { get; set; }
        public BlogsRepository(MyBlogDbContext context)
        {
            _context = context;
        }

        public void Create(Blog blog)
        {
            _context.Add(blog);
            _context.SaveChanges();
        }
        public void Delete(Blog blog)
        {
            _context.Remove(blog);
            _context.SaveChanges();
        }
        public void Update(Blog blog)
        {
            _context.Update(blog);
            _context.SaveChanges();
        }

        public List<Blog> GetAll()
        {
            var blogs = _context.MyBlog.ToList();
            return blogs;
        }

        public List<Blog> GetBlogByTitle(string title)
        {
            var blogs = _context.MyBlog.Where(x => x.Title.Contains(title)).ToList();
            return blogs;
        }

        public Blog GetById(int id)
        {
            var blogs = _context.MyBlog.FirstOrDefault(x => x.Id == id);
            return blogs;
        }
    }
}
