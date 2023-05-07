using MyBlog.Models;
using System.Collections.Generic;

namespace MyBlog.Servises.Interfaces
{
    public interface IMyBlogsServise
    {
        public List<Blog> GetAll();
        public Blog GetById(int id);

    }
}
