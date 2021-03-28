using System;

namespace AssignmentArraysStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OneDimensionArrays.GetAverageOfAnArray(new int[]{1, 2, 3, 4}));

            Array.ForEach(OneDimensionArrays.RemoveNegative(new int[6] { 1, -3, 5, -9, -8, 8 }), Console.WriteLine);
        }
    }

    class OneDimensionArrays
    {
        public static double GetAverageOfAnArray( int[] arr) //a method with one-dimensional array that calculate its members average 
        {
            double avg = 0;
            int sum = 0;
            foreach(int a in arr)
            {
                sum += a;
            }
            return (double) sum / arr.Length;
        }

        public static int[] RemoveNegative(int[] arr) //a method with one-dimensional array that reemove negative members 
        {
            int newLength = 0;
            foreach(int a in arr)
            {
                if (a > 0)
                {
                    newLength++;
                }
            }

            int[] res = new int[newLength];
            int i = 0;
            foreach (int a in arr)
            {
                if (a > 0)
                {
                    res[i] = a;
                    i++;
                }
            }
            return res;
        }
    }
}
