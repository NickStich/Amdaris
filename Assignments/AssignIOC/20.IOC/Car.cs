using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public class Car : ICar
    {
        private string _type;
        public Car(string vehicleType)
        {
            _type = vehicleType;
        }
        public string Start()
        {
            GetCarStartMethod();
            return $"{this.GetType().Name} successful started";
        }

        private void GetCarStartMethod()
        {
            Console.WriteLine($"The car is starting with key rotation");
        }
    }
}
