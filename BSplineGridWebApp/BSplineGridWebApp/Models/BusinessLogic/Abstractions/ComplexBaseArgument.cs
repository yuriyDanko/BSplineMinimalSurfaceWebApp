using System;

namespace BSplineGridWebApp.Models.BusinessLogic.Abstractions
{
    public class ComplexBaseArgument
    {
        public double RealPart { get; set; }
        
        public double ImaginePart { get; set; }

        public ComplexBaseArgument(double realPart, double imaginePart)
        {
            RealPart = realPart;
            ImaginePart = imaginePart;
        }

        public static bool operator >(ComplexBaseArgument complexArg, double second)
        {
            return complexArg.RealPart > second;
        }
        
        public static bool operator <(ComplexBaseArgument complexArg, double second)
        {
            return complexArg.RealPart < second;
        }
        
        public static bool operator >= (ComplexBaseArgument complexArg, double second)
        {
            return complexArg.RealPart >= second;
        }
        
        public static bool operator <= (ComplexBaseArgument complexArg, double second)
        {
            return complexArg.RealPart <= second;
        }
        
        public static bool operator >(double second, ComplexBaseArgument complexArg)
        {
            return second > complexArg.RealPart;
        }
        
        public static bool operator <(double second, ComplexBaseArgument complexArg)
        {
            return second < complexArg.RealPart;
        }
        
        public static bool operator >= (double second, ComplexBaseArgument complexArg)
        {
            return second >= complexArg.RealPart;
        }
        
        public static bool operator <= (double second, ComplexBaseArgument complexArg)
        {
            return second <= complexArg.RealPart;
        }

        public static ComplexBaseArgument operator +(ComplexBaseArgument first, ComplexBaseArgument second)
        {
            return new ComplexBaseArgument(realPart: first.RealPart + second.RealPart,
                imaginePart: first.ImaginePart + second.ImaginePart);
        }
        
        public static ComplexBaseArgument operator -(ComplexBaseArgument first, ComplexBaseArgument second)
        {
            return new ComplexBaseArgument(realPart: first.RealPart - second.RealPart,
                imaginePart: first.ImaginePart - second.ImaginePart);
        }

        public static ComplexBaseArgument operator -(ComplexBaseArgument complexArg)
        {
            return new ComplexBaseArgument(0.0-complexArg.RealPart, 0.0-complexArg.ImaginePart);
        }
        
        public static ComplexBaseArgument operator *(ComplexBaseArgument first, ComplexBaseArgument second )
        {
            return new ComplexBaseArgument(
                first.RealPart * second.RealPart - first.ImaginePart * second.ImaginePart,
                first.RealPart * second.ImaginePart + first.ImaginePart * second.RealPart);
        }

        public static ComplexBaseArgument operator *(double doubleArg, ComplexBaseArgument complexArg)
        {
            return new ComplexBaseArgument(complexArg.RealPart * doubleArg, complexArg.ImaginePart * doubleArg);
        }
        
        public static ComplexBaseArgument operator *(ComplexBaseArgument complexArg, double doubleArg)
        {
            return new ComplexBaseArgument(complexArg.RealPart * doubleArg, complexArg.ImaginePart * doubleArg);
        }

        public static ComplexBaseArgument operator -(double doubleArg, ComplexBaseArgument complexArg)
        {
            return new ComplexBaseArgument(doubleArg - complexArg.RealPart, -complexArg.ImaginePart);
        }
        
        public static ComplexBaseArgument operator -(ComplexBaseArgument complexArg, double doubleArg)
        {
            return new ComplexBaseArgument(complexArg.RealPart - doubleArg, complexArg.ImaginePart);
        }
        
        public static ComplexBaseArgument operator +(double doubleArg, ComplexBaseArgument complexArg)
        {
            return new ComplexBaseArgument(doubleArg + complexArg.RealPart, complexArg.ImaginePart);
        }
        
        public static ComplexBaseArgument operator +(ComplexBaseArgument complexArg, double doubleArg)
        {
            return new ComplexBaseArgument(complexArg.RealPart + doubleArg, complexArg.ImaginePart);
        }

        public static ComplexBaseArgument operator ^(ComplexBaseArgument complexArg, int power)
        {
            double moduleComplexNumber = Math.Sqrt(complexArg.RealPart * complexArg.RealPart
                                                   + complexArg.ImaginePart * complexArg.ImaginePart);
            
            double angle = Math.Atan(complexArg.ImaginePart / complexArg.RealPart);
            
            
            return (Math.Pow(moduleComplexNumber, power))*(new ComplexBaseArgument( Math.Cos(power * angle), Math.Sin(power * angle)));
        }

        public static ComplexBaseArgument operator /(ComplexBaseArgument complexArg, double doubleArg)
        {
            return new ComplexBaseArgument((complexArg.RealPart*doubleArg)/(Math.Pow(doubleArg,2)),
                (complexArg.ImaginePart * doubleArg)/(Math.Pow(doubleArg, 2)));
        }

        public static ComplexBaseArgument operator /(ComplexBaseArgument first, ComplexBaseArgument second)
        {
            return new ComplexBaseArgument(0,0)
            {
                RealPart = (first.RealPart*second.RealPart + first.ImaginePart*second.ImaginePart)/(Math.Pow(second.RealPart, 2) + Math.Pow(second.ImaginePart, 2)),
                ImaginePart = (first.ImaginePart*second.RealPart - first.RealPart*second.ImaginePart)/(Math.Pow(second.RealPart, 2) + Math.Pow(second.ImaginePart, 2))
            };
        }
        
        public override string ToString() {
            return $"{RealPart} + {ImaginePart} * i";
        }
    }
}