namespace BSplineGridWebApp.Models.BusinessLogic.Abstractions
{
    public interface IBasicFunctionExecutor
    {
        public ComplexBaseArgument GetValueOfBasicFunc(int order, int indexOfBasicFunction, double[] nodalVector,
            ComplexBaseArgument x);
    }
}