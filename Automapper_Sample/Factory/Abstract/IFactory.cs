using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automapper_Sample.Models.ViewModels;

namespace Automapper_Sample.Factory.Abstract
{
    interface IFactory<T>
    {
        T AddItem(T person);
        List<T> GetItems();
        T GetItem(Guid id);
        T UpdateItem(T item);
    }
}
