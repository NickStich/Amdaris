using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public interface ICar  //adding a flexibility with an interface that will be implemented by 2 types of vehicles
    {
        string Start();
    }
}
