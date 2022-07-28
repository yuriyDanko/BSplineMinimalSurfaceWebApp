using System.Collections.Generic;
using BSplineGridWebApp.Models.BusinessLogic.Abstractions;

namespace BSplineGridWebApp.Models.BusinessLogic.BSpline
{
    public class BSplineBuilder
    {
        public IBasicFunctionExecutor BasicFunctionExecutor { get; set; }
        public IEnumerable<global::BSplineGridWebApp.Models.BusinessLogic.Point.Point> ControlPoints { get; set; }
        public int Order { get; set; }
        public double[] NodalVector { get; set; }
        public global::BSplineGridWebApp.Models.BusinessLogic.Point.Point BSplinePoint { get; set; }


        public BSplineBuilder(IBasicFunctionExecutor basicFunctionExecutor, IEnumerable<global::BSplineGridWebApp.Models.BusinessLogic.Point.Point> controlPoints,
            int order, double[] nodalVector)
        {
            BasicFunctionExecutor = basicFunctionExecutor;
            ControlPoints = controlPoints;
            Order = order;
            NodalVector = nodalVector;
        }
        
        public global::BSplineGridWebApp.Models.BusinessLogic.Point.Point Execute(ComplexBaseArgument t)
        {
            BSplinePoint = new global::BSplineGridWebApp.Models.BusinessLogic.Point.Point(new ComplexBaseArgument(0,0), 
                new ComplexBaseArgument(0,0), 
                new ComplexBaseArgument(0,0));
            int indexOfBasicFunction = 0;
            foreach (var controlPoint in ControlPoints)
            {
                ComplexBaseArgument valueOfBasicFunc =
                    BasicFunctionExecutor.GetValueOfBasicFunc(Order, indexOfBasicFunction, NodalVector, t);
                BSplinePoint.X += controlPoint.X * valueOfBasicFunc;
                BSplinePoint.Y += controlPoint.Y * valueOfBasicFunc;
                BSplinePoint.Z += controlPoint.Z * valueOfBasicFunc;
                indexOfBasicFunction++;
            }
            
            return BSplinePoint;
        }
    }
}