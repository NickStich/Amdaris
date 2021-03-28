using System;

// Hello World
// Reference type and value type
// Static method
namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // a) Hello World program task that display in console "Hello World" message.
            Console.WriteLine("Hello World!");


            // b.1) A instance of a value type struct that display in console given struct point coordinates.
            XYZPoint v = new XYZPoint { x = 5, y = 4, z = 3 };
            Console.WriteLine("The struct point coordonates are: "+v.x+ ", "+v.y+", "+v.z+".");

            // b.2) XYZClass object with reference type
            XYZClass r = new XYZClass { X = 10, Y = -9, Z = 8 };
            Console.WriteLine("The class point coordonates are: " + r.X + ", " + r.Y + ", " + r.Z + ".");

            // c) Static method which display an oposite of the given point. The method can be accessed without class instatiation.
            XYZClass.ShowReflectionOfThePoint(r);
        }

       
    }
    struct XYZPoint
    {
        public int x;
        public int y;
        public int z;
    }

    class XYZClass
    {
        public int X;
        public int Y;
        public int Z;

       public static void ShowReflectionOfThePoint(XYZClass point)
        {
            XYZClass oposite = new XYZClass { X = (0 - point.X), Y = (0 - point.Y), Z = (0 - point.Z) };
            Console.WriteLine("The point reflection coordonates are: " + oposite.X + ", " + oposite.Y + ", " + oposite.Z + ".");
        }
    }
}
