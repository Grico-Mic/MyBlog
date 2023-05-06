using MyBlog.Models;
using MyBlog.Repositories;
using System;
using System.Collections.Generic;

namespace MyBlog.Servises
{
    public class MyBlogsServise
    {
        private MyBlogsRepository _myBlogsRepository { get; set; }

        public MyBlogsServise()
        {
            _myBlogsRepository = new MyBlogsRepository();
        }

        public List<Blog> GetAll()
        {
            return _myBlogsRepository.GetAll();
        }

        public Blog GetById(int id)
        {
            return _myBlogsRepository.GetById(id);

        }
             
    }
}
