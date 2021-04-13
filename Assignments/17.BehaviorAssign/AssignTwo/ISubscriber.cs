using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignTwo.Observer
{
    public interface ISubscriber<T>
    {
        void Notify(T item);
    }
}
