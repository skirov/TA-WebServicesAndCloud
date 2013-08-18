using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Delete(int id);
        IEnumerable<T> All();
        T Get(int id);
        void Update(int id, T item);
    }
}
