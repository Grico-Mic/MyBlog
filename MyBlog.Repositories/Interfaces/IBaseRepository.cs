using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
         List<T> GetAll();
        public T GetById(int entityId);
        void Create(T newEntity);
        void Update(T entity);
        void Delete(T entity);
    }
}
