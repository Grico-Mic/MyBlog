using Microsoft.EntityFrameworkCore;
using MyBlog.Models;

namespace MyBlog.Repositories
{
    public class MyBlogDbContext : DbContext
    {
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options) : base(options)
        {

        }
        public DbSet<Blog> MyBlog { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
