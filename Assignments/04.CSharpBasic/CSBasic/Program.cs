using System;


// The parameter modifier
namespace CSBasic
{

    public class Cell
    {
        public int Column;
        public int Line;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int value = 100;
            Cell oldCell = new Cell { Column = 6, Line = 4 };

            //d.1) no param modifier
            InsertAValueOnCell( value, oldCell);
            Console.WriteLine(value);
            Console.WriteLine(oldCell.Column+" "+oldCell.Line);

            //d.2) ref param modifier
            RefInsertAValueOnCell(ref value, ref oldCell);
            Console.WriteLine(value);
            Console.WriteLine(oldCell.Column + " " + oldCell.Line);

            //d.3) out param modifier
            OutInsertAValueOnCell(out value, out oldCell);
            Console.WriteLine(value);
            Console.WriteLine(oldCell.Column + " " + oldCell.Line);
        }

        public static void InsertAValueOnCell(int value , Cell cell)
        {
            value = value * 2;
            cell = new Cell { Column = 1, Line = 1 };
        }

        public static void RefInsertAValueOnCell( ref int value, ref Cell cell)
        {
            value = value * 4;
            cell = new Cell { Column = 2, Line = 2 };
        }

        public static void OutInsertAValueOnCell(out int value, out Cell cell)
        {
            value = 800;
            cell = new Cell { Column = 3, Line = 3 };
        }
    }



    
}
