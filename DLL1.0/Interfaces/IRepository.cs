using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL1._0.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Find(T id);
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item, T item2);
        void Delete(T id);
        int GetId(T item);
    }
}
