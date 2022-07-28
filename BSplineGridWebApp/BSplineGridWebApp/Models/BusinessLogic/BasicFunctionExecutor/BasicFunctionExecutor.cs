using System;
using System.Linq;
using BSplineGridWebApp.Models.BusinessLogic.Abstractions;

namespace BSplineGridWebApp.Models.BusinessLogic.BasicFunctionExecutor
{
    public class BasicFunctionExecutor : IBasicFunctionExecutor
    {
        public ComplexBaseArgument GetValueOfBasicFunc (int order, int indexOfBasicFunction, double[] nodalVector,
            ComplexBaseArgument x)
        {
            ComplexBaseArgument result;
            
            if (order == 0)
            {
                if (x >= nodalVector.ElementAt(indexOfBasicFunction) &&
                    x < nodalVector.ElementAt(indexOfBasicFunction + 1))
                {
                    result = new ComplexBaseArgument(1,0);
                }

                else
                {
                    result =  new ComplexBaseArgument(0,0);
                }
                
            }

            else
            {
                double firstDenominator, secondDenominator;
                ComplexBaseArgument firstMultiplier, secondMultiplier;

                firstDenominator = nodalVector[indexOfBasicFunction + order] - nodalVector[indexOfBasicFunction];
                secondDenominator = nodalVector[indexOfBasicFunction + order + 1] -
                                    nodalVector[indexOfBasicFunction + 1];

                if (Math.Abs(firstDenominator) < 0.0000001)
                {
                    firstMultiplier = new ComplexBaseArgument(0,0);
                }
                else
                {
                    firstMultiplier = (x - nodalVector[indexOfBasicFunction]) / firstDenominator;
                }

                if (Math.Abs(secondDenominator) < 0.0000001)
                {
                    secondMultiplier = new ComplexBaseArgument(0,0);
                }
                else
                {
                    secondMultiplier = (nodalVector[indexOfBasicFunction + order + 1] - x) / secondDenominator;
                }

                result = firstMultiplier * GetValueOfBasicFunc(order - 1, indexOfBasicFunction, nodalVector, x)
                         + secondMultiplier * GetValueOfBasicFunc(order - 1, indexOfBasicFunction + 1, nodalVector, x);
            }

            return result;
        }
    }
}
