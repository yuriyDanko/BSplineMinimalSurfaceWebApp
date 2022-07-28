using BSplineGridWebApp.Models.BusinessLogic.Abstractions;

namespace BSplineGridWebApp.Models.BusinessLogic.Point
{
    public class Point
    {
        public ComplexBaseArgument X { get; set; }
        
        public ComplexBaseArgument Y { get; set; }
        
        public ComplexBaseArgument Z { get; set; }

        public Point(ComplexBaseArgument x, ComplexBaseArgument y, ComplexBaseArgument z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}