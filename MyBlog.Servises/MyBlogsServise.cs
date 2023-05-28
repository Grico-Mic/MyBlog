using MyBlog.Models;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Servises.Interfaces;
using System.Collections.Generic;

namespace MyBlog.Servises
{
    public class MyBlogsServise : IMyBlogsServise
    {
        private IMyBlogsRepository _myBlogsRepository { get; set; }

        public MyBlogsServise(IMyBlogsRepository myBlogsRepository)
        {
            _myBlogsRepository = myBlogsRepository;
        }

        public List<Blog> GetAll()
        {
            return _myBlogsRepository.GetAll();
        }

        public Blog GetById(int id)
        {
            return _myBlogsRepository.GetById(id);

        }

        public void Create(Blog blog)
        {
            _myBlogsRepository.Create(blog);
        }

        public List<Blog> GetBlogByTitle(string title)
        {
            if (title == null)
            {
                return _myBlogsRepository.GetAll();
            }
            else
            {
                return _myBlogsRepository.GetBlogByTitle(title);
            }
        }
    }
}
