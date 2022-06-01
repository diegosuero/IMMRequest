using System;
using System.Collections.Generic;

namespace IMMRequest.BusinessLogic.Interface
{
    public interface ISession<T>
    {
        int Login(string email, string password);
        IEnumerable<T> GetAll();
        bool estaLogueado(int token);
    }
}

