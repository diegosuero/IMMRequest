using System;
using System.Collections.Generic;

namespace IMMRequest.BusinessLogic.Interface
{
    public interface ILogic<T>
    {
        T Create(T entity);
        T Get(int id);
        T GetByString(String stringg);
        IEnumerable<T> GetAll();
        T Update(int id, T entity);      
        void Remove(int id);
    }
}
