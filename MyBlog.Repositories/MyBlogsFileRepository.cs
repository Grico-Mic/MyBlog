using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyBlog.Repositories
{
    public class MyBlogsFileRepository : IMyBlogsRepository
    {
        public MyBlogsFileRepository()
        {
            var path = "MyBlog.txt";

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }

            var result = File.ReadAllText(path);
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
    }
}
