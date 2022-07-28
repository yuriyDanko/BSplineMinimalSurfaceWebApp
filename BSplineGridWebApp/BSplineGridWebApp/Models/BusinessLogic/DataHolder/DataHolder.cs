using System.Collections.Generic;

namespace BSplineGridWebApp.Models.BusinessLogic.DataHolder
{
    public class DataHolder
    {
        public int Degree { get; set; }
        public List<double> RealPartXOfControlPoints { get; set; }
        public List<double> RealPartYOfControlPoints { get; set; }
        
        public List<double> RealPartZOfControlPoints { get; set; }
        
        public List<double> ImaginePartZOfControlPoints { get; set; }
        public double ImaginePartOfFirstX { get; set; }
        public double ImaginePartOfFirstY { get; set; }
        public double[] NodalVector { get; set; }
    }
}