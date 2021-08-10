using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Contract
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();
        void Save(T entity);
        T GetById(int Id);
        void Update(T entity);
        void DeleteByClass<T>();
    }
}
