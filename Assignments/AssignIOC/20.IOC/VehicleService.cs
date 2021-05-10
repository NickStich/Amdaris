using _20.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public class VehicleService  // invertion of control using dependency injection
    {
        private readonly ICar _car;

        public VehicleService(ICar car) //constructor injection
        {
            _car = car;
        }

        public string Start()
        {
            return _car.Start();
        }
    }
}
