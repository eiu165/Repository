using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Framework.Common
{
    public interface ICachable
    {
        T Get<T>(string key);
        object Get(string key);       
        void Add(string key, object obj, DateTime expireDate);

        IEnumerable<string> GetKeys();
    }


}
