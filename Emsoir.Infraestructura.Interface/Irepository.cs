using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emsoir.Infraestructura.Interface
{
    public interface Irepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetList();
        bool Add(T entity);
        bool Update(T entity);
        bool  Delete(T entity);
    }
}
