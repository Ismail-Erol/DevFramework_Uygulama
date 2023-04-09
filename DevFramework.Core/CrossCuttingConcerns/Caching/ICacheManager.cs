using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching
{
    // her cach datası için benzersiz bir key oluşturmamız gerkiyor. 
    public interface ICacheManager
    {
        T Get<T>(string key);   // generic yapıyoruz çünkü çalışavcağımız tip değişiklik gösterebilir.
        void Add(string key, object data, int cachetime);
        bool IsAdd(string key); 
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear();

    }
}
