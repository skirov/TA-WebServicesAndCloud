using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        T GetById(int id);
        IQueryable<T> GetAll();
    }
}
