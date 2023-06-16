using MyBlog.Common;
using MyBlog.Models;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Servises.DtoModels;
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
            blog.DateCreated = System.DateTime.Now;
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

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var blog = _myBlogsRepository.GetById(id);
            if (blog == null)
            {
                response.IsSuccessful = false;
                response.Message = "The blog that you you want to delete is no longer available.";      
            }
            else
            {
                _myBlogsRepository.Delete(blog);
                response.IsSuccessful = true;
            }
            return response;
        }

        public StatusModel Update(Blog blog)
        {
            var response = new StatusModel();
            var updatedBlog = _myBlogsRepository.GetById(blog.Id);
            if (updatedBlog != null)
            {
                updatedBlog.Title = blog.Title;
                updatedBlog.Description = blog.Description;
                updatedBlog.DateUpdated = blog.DateUpdated;

                _myBlogsRepository.Update(updatedBlog);
                response.IsSuccessful = true;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "The blog that you want to update was no found.";
            }
            return response;
        }
    }
}
