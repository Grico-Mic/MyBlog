using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class BaseRepository <T> where T : class
    {
     protected readonly MyBlogDbContext _context;
        public BaseRepository(MyBlogDbContext context)
        {
            _context = context;
        }
        public void Create(T newEntity)
        {
            _context.Add(newEntity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            
            return _context.Set<T>().ToList();
        }
        public T GetById(int entityId)
        {
           
            return _context.Set<T>().Find(entityId);
        }
    }
}
