using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyBlog.Repositories
{
    public class MyBlogsSqlRepository : IMyBlogsRepository
    {
        //public void Create(Blog blog)
        //{
        //    using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyBlog;Trusted_Connection=true;"))
        //    {
        //        cnn.Open();
        //        var query = @"insert into MyBlogs (Title,Description,DateCreated)
        //                          values(@Title,@Description,@DateCreated)";
        //        var cmd = new SqlCommand(query, cnn);
        //        cmd.Parameters.AddWithValue("@Title", blog.Title);
        //        cmd.Parameters.AddWithValue("@Description", blog.Description);
        //        cmd.Parameters.AddWithValue("@DateCreated", DateTime.UtcNow);

        //        cmd.ExecuteNonQuery();
        //    }
        //}
        public void Create(Blog blog)
        {

            using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyBlog;Trusted_Connection=true;"))
            {
                cnn.Open();

                var cmd = new SqlCommand("CreateBlog", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", blog.Title);
                cmd.Parameters.AddWithValue("@Description", blog.Description);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.UtcNow);

                cmd.ExecuteNonQuery();
            }
        }
        public List<Blog> GetAll()
        {
            var result = new List<Blog>();
            using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyBlog;Trusted_Connection=true;"))
            {
                cnn.Open();
                var query = "select * from MyBlogs";

                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var blog = new Blog();

                    blog.Id = reader.GetInt32(0);
                    blog.Title = reader.GetString(1);
                    blog.Description = reader.GetString(2);
                    DateTime dateTime = reader.GetDateTime(3);
                    blog.DateCreated = dateTime;
                    result.Add(blog);
                }

            }
            return result;
        }
        public Blog GetByTitle(string title)
        {
            Blog result = null;
            using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyBlog;Trusted_Connection=true;"))
            {
                cnn.Open();
                var query = $"select* from MyBlogs where Title = @Title";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", title);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Blog();
                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.Description = reader.GetString(2);
                    result.DateCreated = reader.GetDateTime(3);
                }

            }
            return result;
        }

        public Blog GetById(int id)
        {
            Blog result = null;
            using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyBlog;Trusted_Connection=true;"))
            {
                cnn.Open();
                var query = $"select* from MyBlogs where id = @id ";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Blog();
                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.Description = reader.GetString(2);
                    result.DateCreated = reader.GetDateTime(3);
                }

            }
            return result;
        }
    }
}
