using System;

namespace TwoDimensionArraysDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(TwoDimensionArray.SumMainDiagonal(new int[3,3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }));

            Console.WriteLine(TwoDimensionArray.SmallestNumberFromMatrix(new int[3, 3] { { 6, 3, 9 }, { 4, -8, 2 }, { 4, 7, 1 } }));
        }
    }

    class TwoDimensionArray
    {
        public static int SumMainDiagonal(int[,] mx) //method that calculate sum of elements of main diagonal from a given matrix
        {
            int result = 0;
            for (int i = 0; i < mx.GetLength(0); i++)
            {
                for (int j = 0; j < mx.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        result += mx[i, j];
                    }
                }
            }
            return result;
        }


        public static int SmallestNumberFromMatrix(int[,] matrix)// method that return smallest number from a matrix
        {
            int min = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j]<min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            return min;
        }


    }
}
