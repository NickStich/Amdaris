using System;

namespace AssignTwo
{
    public class Circle : Shape
    {
        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius { get; }

        public override float GetShapeArea()
        {
            float area = Convert.ToSingle(Radius * Radius * Math.PI);

            return area;

        }
    }
}
