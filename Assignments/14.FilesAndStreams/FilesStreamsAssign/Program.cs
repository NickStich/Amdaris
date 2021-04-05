using System;
using System.IO;

namespace FilesStreamsAssign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert your 3 lines text to be written in the file:");
            string inputLine1 = Console.ReadLine();
            string inputLine2 = Console.ReadLine();
            string inputLine3 = Console.ReadLine();
            string[] inputs = { inputLine1, inputLine2, inputLine3 };

            string textFile = @"C:\Internship\Amdaris\Assignments\14.FilesAndStreams\FilesStreamsAssign\Insert.txt";

            File.WriteAllLines(textFile, inputs); //write all input in the file
            
            string[] lines = File.ReadAllLines(textFile); // read from the file
            Console.WriteLine($"Displaying {textFile} content");
            foreach (string line in lines)
                Console.WriteLine(line); //display each line
        }
    }
}
