using System;

// Boxing & Unboxing
// Static Constructor
namespace BoxingAndUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // e) declaring a variable with value tipe
            int X = 123;
            
            Object o = X; // pass variable value to an object
            Console.WriteLine(o);
            Console.WriteLine(o.Equals(X)); // comparing variable type value with object value, the result must be True
            int Y = (int)o; // pass object value to a variable
            Console.WriteLine(Y);
            Console.WriteLine(X+Y); // check if the initial and final variables sum is an int

            // f.2) Display static variable message from the class with static constructor.
            // The message is : "The static constructor was called!"
            //                  "Hello from class Test"
            // The final message looks like that because a static constructor is first appealed member from a class.
            Console.WriteLine(Test.Hello);
        }


    }


    // f.1) checking to see how static constructor works
    class Test
    {
        static Test() // declaring a static constructor with a message
        {
            Console.WriteLine("The static constructor was called!");
        }

        public static string Hello = "Hello from class Test"; // declaring a static variable with a message
    }

}
