using System;
using System.Text;

namespace StringsManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Strings.WelcomeMe("Stici");

            Strings.StringBuilding();
        }
    }

    class Strings
    {
        public static void WelcomeMe(string yourName) 
        {
            string display = $"Hi " + yourName + ", welcome to my project!!!";
            Console.WriteLine(display); // display a welcome mesage with a given name 

            string[] splitedDisplay = display.Split(' ');
            Array.ForEach(splitedDisplay, Console.WriteLine); // display string from new line divided by one space

            Console.WriteLine( String.Join(" ", splitedDisplay)); //rebuilding a string from an array early divided by a space

            Console.WriteLine(display.Replace(' ','_')); // replacing spaces with _
            Console.WriteLine(display.ToUpper()); // message to upper case
        }

        public static void StringBuilding()
        {
            StringBuilder stringBuilder = new StringBuilder("Hello", 100); //create a new stringbuilder object that can hold 100 characters.

            stringBuilder.Append(" StringBuilder"); // appending to the initial value of stringbuilder object a new string.
            Console.WriteLine(stringBuilder);

            stringBuilder.Replace("l", "L");
            Console.WriteLine(stringBuilder); // replacing a given char with other

            Console.WriteLine("{0} chars: {1}", stringBuilder.Length, stringBuilder.ToString()); //displaying the number of chars and the contain of it.

            stringBuilder.Insert(stringBuilder.ToString().IndexOf(" ") + 1, "my "); //inserting after the space, given word
            Console.WriteLine(stringBuilder);

        }
    }

   
}
