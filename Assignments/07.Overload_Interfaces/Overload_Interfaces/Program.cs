using System;

namespace Overload_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Angle a = new Angle(4, 27, 45);

            Angle b = new Angle(3, 36, 53);

            Angle c = a + b;

            Console.WriteLine(c.ToString());

            Angle d = a - b;
            Console.WriteLine(d.ToString());

            Console.WriteLine(a==b);
        }
    }

    
}
