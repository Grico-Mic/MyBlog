using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyBlog.Repositories
{
    public class MyBlogsFileRepository : IMyBlogsRepository
    {
        const string Path = "MyBlog.txt";
        public MyBlogsFileRepository()
        {
            

            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var result = File.ReadAllText(Path);
            var deserialzedList = JsonConvert.DeserializeObject<List<Blog>>(result);
            Blogs = deserialzedList;
        }

        public List<Blog> Blogs { get; set; }
        public Blog GetById(int id)
        {
            return Blogs.FirstOrDefault(x => x.Id == id);
        }

        public List<Blog> GetAll()
        {
            return Blogs;
        }

        public void Create(Blog blog)
        {
            blog.Id = GenerateId();
            blog.DateCreated = DateTime.Now;
            Blogs.Add(blog);
            SaveChanges();
        }

        private int GenerateId()
        {
            var maxId = 0;

            if (Blogs.Any())
            {
                maxId = Blogs.Max(x => x.Id);

            }
            return maxId + 1;
        }
        private void SaveChanges()
        {
            var seriliazed = JsonConvert.SerializeObject(Blogs);
            File.WriteAllText(Path, seriliazed);
        }
    }
}
