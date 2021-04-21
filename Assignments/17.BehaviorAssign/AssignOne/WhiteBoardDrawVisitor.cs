using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignOne
{
    public class WhiteBoardDrawVisitor : IVisitor
    {
        public void Visit(Shape shape)
        {

            string result = shape switch
            {
                Circle c =>  $"Drawing circle with radius {c.Radius} on whiteBoard",
                Square s =>  $"Drawing circle with radius {s.Length} on whiteBoard",
                _ => "Inexisting shape"
            };
            Console.WriteLine(result);
            
        }
    }
}

