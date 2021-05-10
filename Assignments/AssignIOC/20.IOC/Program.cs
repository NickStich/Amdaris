using _20.IOC;
using System;

namespace IOC
{
    class Program
    {
        static Program()
        {
            ServiceLocator.RegisterAll();
        }
        static void Main(string[] args)
        {
            var vehicleService = ServiceLocator.Resolve<VehicleService>("Car");

            var vehicle = vehicleService.Start();
            Console.WriteLine(vehicle);
        }
    }
}
