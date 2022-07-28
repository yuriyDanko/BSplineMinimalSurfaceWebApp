using System.Collections.Generic;
using System.Linq;

namespace BSplineGridWebApp.Models.BusinessLogic.Helpers
{
    public class ImaginePartDeterminant
    {
        public static void DefineImaginePart(IList<global::BSplineGridWebApp.Models.BusinessLogic.Point.Point> points)
        {
            for (int i = 0; i <= points.Count - 2; i++)
            {
                points.ElementAt(i + 1).X.ImaginePart =
                    - points.ElementAt(i + 1).Y.RealPart + points.ElementAt(i).X.ImaginePart + points.ElementAt(i).Y.RealPart;

                points.ElementAt(i + 1).Y.ImaginePart =
                    points.ElementAt(i + 1).X.RealPart - points.ElementAt(i).X.RealPart
                    + points.ElementAt(i).Y.ImaginePart;
            }
        }
    }
}