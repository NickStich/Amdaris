using System;

namespace OverloadingAssign
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new MarksAVGCalculator();
            Console.WriteLine(calculator.calculateAverageOfMarks( 8, 7, 6)); // will display message from Calculator class method

            MarksAVGCalculator marksCalculator = new MarksAVGCalculator();
            Console.WriteLine(marksCalculator.calculateAverageOfMarks(6,7,9)); // will display message from MarksAVGCalculator class method

        }
    }

    // e) A class that contain example of overloading, methods with a same name but different signature and a method that might be overriden.

    class Calculator
    {
        public virtual double calculateAverageOfMarks(int a, int b, int c)
        {
            Console.WriteLine("Method from Calculator");
            return (double)(a + b + c) / 3;
        }
    }
    class MarksAVGCalculator : Calculator
    {
       public  double calculateAverageOfMarks(int a)
        {
            return a;
        }

        public  double calculateAverageOfMarks(int a, int b)
        {
            return (double)(a+b)/2;
        }

        public  double calculateAverageOfMarks(int a,int b, int c)
        {
            Console.WriteLine("Method from MarksAVGCalculator");
            return (double)(a+b+c)/3;
        }

        public  double calculateAverageOfMarks(params int[] a)
        {
            int sum = 0;
            foreach(int mark in a){
                sum += mark;
            }
            return (double) sum / a.Length;
        }
    }
}
 