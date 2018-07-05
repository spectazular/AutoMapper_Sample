using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automapper_Sample.Repository.Abstract
{
    public interface IRepository<T>
    {
        T Add(T item);
        T Get(Guid id);
        List<T> Get();
        T Update(T item);
        bool Delete(Guid id);
    }
}
