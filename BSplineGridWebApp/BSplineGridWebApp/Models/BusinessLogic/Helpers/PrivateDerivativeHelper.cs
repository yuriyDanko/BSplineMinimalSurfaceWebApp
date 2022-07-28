using System.Collections.Generic;
using BSplineGridWebApp.Models.BusinessLogic.Abstractions;

namespace BSplineGridWebApp.Models.BusinessLogic.Helpers
{
    public class PrivateDerivativeHelper
    {
        public static List<double> ExecuteDerivativeXByU(ComplexBaseArgument[,] arguments, global::BSplineGridWebApp.Models.BusinessLogic.Point.Point[,] valueOfFunc, double step)
        {
            List<double> result = new List<double>();

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    result.Add((valueOfFunc[i+1,j].X.RealPart - valueOfFunc[i,j].X.RealPart) / step);
                }
            }

            for (int i = 1; i < arguments.GetLength(0) - 2; i++)
            {
                for (int j = 1; j < arguments.GetLength(1) - 2; j++)
                {
                    result.Add((valueOfFunc[i+1,j].X.RealPart - valueOfFunc[i - 1,j].X.RealPart) / (2*step));
                }
            }
            
            return result;
        }
        
        public static List<double> ExecuteDerivativeXByV(ComplexBaseArgument[,] arguments, global::BSplineGridWebApp.Models.BusinessLogic.Point.Point[,] valueOfFunc, double step)
        {
            List<double> result = new List<double>();
            
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    result.Add((valueOfFunc[i, j + 1].X.RealPart - valueOfFunc[i,j].X.RealPart) / step);
                }
            }

            for (int i = 1; i < arguments.GetLength(0) - 2; i++)
            {
                for (int j = 1; j < arguments.GetLength(1) - 2; j++)
                {
                    result.Add((valueOfFunc[i, j + 1].X.RealPart - valueOfFunc[i,j - 1].X.RealPart) / (2*step));
                }
            }
            
            return result;
        }
        
        public static List<double> ExecuteDerivativeYByU(ComplexBaseArgument[,] arguments, global::BSplineGridWebApp.Models.BusinessLogic.Point.Point[,] valueOfFunc, double step)
        {
            List<double> result = new List<double>();
            
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    result.Add((valueOfFunc[i+1,j].Y.RealPart - valueOfFunc[i,j].Y.RealPart) / step);
                }
            }

            for (int i = 1; i < arguments.GetLength(0) - 2; i++)
            {
                for (int j = 1; j < arguments.GetLength(1) - 2; j++)
                {
                    result.Add((valueOfFunc[i + 1, j].Y.RealPart - valueOfFunc[i - 1,j].Y.RealPart) / (2*step));
                }
            }
            
            return result;
        }
        
        public static List<double> ExecuteDerivativeYByV(ComplexBaseArgument[,] arguments, global::BSplineGridWebApp.Models.BusinessLogic.Point.Point[,] valueOfFunc, double step)
        {
            List<double> result = new List<double>();
            
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    result.Add((valueOfFunc[i, j + 1].Y.RealPart - valueOfFunc[i,j].Y.RealPart) / step);
                }
            }

            for (int i = 1; i < arguments.GetLength(0) - 2; i++)
            {
                for (int j = 1; j < arguments.GetLength(1) - 2; j++)
                {
                    result.Add((valueOfFunc[i, j + 1].Y.RealPart - valueOfFunc[i,j - 1].Y.RealPart) / (2*step));
                }
            }
            
            return result;
        }
        
        public static List<double> ExecuteDerivativeZByU(ComplexBaseArgument[,] arguments, global::BSplineGridWebApp.Models.BusinessLogic.Point.Point[,] valueOfFunc, double step)
        {
            List<double> result = new List<double>();
            
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    result.Add((valueOfFunc[i+1,j].Z.RealPart - valueOfFunc[i,j].Z.RealPart) / step);
                }
            }

            for (int i = 1; i < arguments.GetLength(0) - 2; i++)
            {
                for (int j = 1; j < arguments.GetLength(1) - 2; j++)
                {
                    result.Add((valueOfFunc[i+1,j].Z.RealPart - valueOfFunc[i - 1,j].Z.RealPart) / (2*step));
                }
            }
            
            return result;
        }
        
        public static List<double> ExecuteDerivativeZByV(ComplexBaseArgument[,] arguments, global::BSplineGridWebApp.Models.BusinessLogic.Point.Point[,] valueOfFunc, double step)
        {
            List<double> result = new List<double>();
            
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    result.Add((valueOfFunc[i, j + 1].Z.RealPart - valueOfFunc[i,j].Z.RealPart) / step);
                }
            }

            for (int i = 1; i < arguments.GetLength(0) - 2; i++)
            {
                for (int j = 1; j < arguments.GetLength(1) - 2; j++)
                {
                    result.Add((valueOfFunc[i, j + 1].Z.RealPart - valueOfFunc[i,j - 1].Z.RealPart) / (2*step));
                }
            }
            
            return result;
        }
    }
}