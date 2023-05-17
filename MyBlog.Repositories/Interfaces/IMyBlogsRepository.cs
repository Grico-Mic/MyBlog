using MyBlog.Models;
using System.Collections.Generic;


namespace MyBlog.Repositories.Interfaces
{
    public interface IMyBlogsRepository
    {
        public Blog GetById(int id);
        public List<Blog> GetAll();
        void Create(Blog blog);
    }
}
