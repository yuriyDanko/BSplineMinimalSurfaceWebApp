using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BSplineGridWebApp.Models.BusinessLogic.Abstractions;
using BSplineGridWebApp.Models.BusinessLogic.BasicFunctionExecutor;
using BSplineGridWebApp.Models.BusinessLogic.BSpline;
using BSplineGridWebApp.Models.BusinessLogic.DataHolder;
using BSplineGridWebApp.Models.BusinessLogic.Helpers;
using BSplineGridWebApp.Models.BusinessLogic.Point;
using BSplineGridWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace BSplineGridWebApp.Controllers
{
    public class GridController : Controller
    {
        private IWebHostEnvironment _env;

        private readonly List<double> _realPartX;
        private readonly List<double> _realPartY;
        private readonly List<double> _realPartZ;

        private readonly List<double> _valuesOfF;
        private readonly List<double> _e;
        private readonly List<double> _g;
        
        private Point[,] _points;
        private readonly List<Point> _controlPoints;

        private readonly int _k;

        private string _error;


        public GridController(IWebHostEnvironment env)
        {
            _env = env;
            
            _realPartX = new List<double>();
            _realPartY = new List<double>();
            _realPartZ = new List<double>();
            
            _valuesOfF = new List<double>();
            _e = new List<double>();
            _g = new List<double>();
            _controlPoints = new List<Point>();

            _k = 3;

            _error = string.Empty;

        }

        public async Task<IActionResult> Grid(FileViewModel fileViewModel)
        {
            if (!ModelState.IsValid)
            {
                _error = ModelState.Values.ElementAt(0).Errors.ElementAt(0).ErrorMessage;
                ViewData["error"] = _error;
                return View("grid", fileViewModel);
            }

            if (fileViewModel.File == null || fileViewModel.File.Length == 0)
            {
                ViewData["error"] = "File is empty or does not exist";
                return View("grid", fileViewModel);
            }

            await SaveFileOnServer(fileViewModel);
            

            DataHolder holder = JsonConvert.DeserializeObject<DataHolder>(GetDataFromJsonFile());

            var error = ValidateDataHolder(holder);
            
            if (error != string.Empty)
            {
                ViewData["error"] = error;
                return View("grid", fileViewModel);
            }

            {

                CreateControlPoints(holder);

                BasicFunctionExecutor basicFunctionExecutor = new BasicFunctionExecutor();


                BSplineBuilder bSplineBuilder = new BSplineBuilder(basicFunctionExecutor, _controlPoints,
                    holder.Degree, holder.NodalVector);

                List<double> u = new List<double>();
                List<double> v = new List<double>();

                double step = 0.01;

                for (double i = 0; i <= 1; i += step)
                {
                    u.Add(i);
                    v.Add(i);
                }


                ComplexBaseArgument[,] complexArgs = new ComplexBaseArgument[u.Count, v.Count];

                for (int j = 0; j < u.Count; j++)
                {
                    for (int k = 0; k < v.Count; k++)
                    {
                        complexArgs[j, k] = new ComplexBaseArgument(u.ElementAt(j), _k*v.ElementAt(k));
                    }
                }


                _points = new Point[u.Count, v.Count];

                for (int i = 0; i < u.Count; i++)
                {
                    for (int j = 0; j < v.Count; j++)
                    {
                        _points[i, j] = bSplineBuilder.Execute(complexArgs[i, j]);


                        Console.WriteLine(_points[i, j].X.RealPart);
                        PrintX(complexArgs[i, j].RealPart, complexArgs[i, j].ImaginePart);


                        if (i == u.Count - 1 || j == v.Count - 1) continue;

                        _realPartX.Add(_points[i, j].X.RealPart);
                        _realPartY.Add(_points[i, j].Y.RealPart);
                        _realPartZ.Add(_points[i, j].Z.RealPart);
                    }
                }

                CalculateMainSurfaceCharacteristics(complexArgs, step);

            }





            ViewData["error"] = _error;

            ViewData["degree"] = holder.Degree.ToString();
            ViewData["nodalVector"] = string.Join(",", holder.NodalVector.ToArray());
            ViewData["realPartXOfControlPointsString"] = string.Join(",", holder.RealPartXOfControlPoints);
            ViewData["realPartYOfControlPointsString"] = string.Join(",", holder.RealPartYOfControlPoints);
            ViewData["realPartZOfControlPointsString"] = string.Join(",", holder.RealPartZOfControlPoints);

            ViewData["imaginePartOfFirstX"] = holder.ImaginePartOfFirstX.ToString(CultureInfo.InvariantCulture);
            ViewData["imaginePartOfFirstY"] = holder.ImaginePartOfFirstY.ToString(CultureInfo.InvariantCulture);

            ViewData["imaginePartsOfControlPointsString"] = GetStringWithImaginePartsOfControlPoints();


            ViewData["realPartX"] = _realPartX.ToArray();
            ViewData["realPartY"] = _realPartY.ToArray();
            ViewData["realPartZ"] = _realPartZ.ToArray();
            ViewData["informationAboutGrid"] = GetReportAboutSurface();
            ViewData["realPartXOfControlPoints"] = holder.RealPartXOfControlPoints;
            ViewData["realPartYOfControlPoints"] = holder.RealPartYOfControlPoints;
            ViewData["realPartZOfControlPoints"] = holder.RealPartZOfControlPoints;

            return View("grid", fileViewModel);
        }


        private void CreateControlPoints(DataHolder holder)
        {
            for (int i = 0; i < holder.RealPartXOfControlPoints.Count; i++)
            {
                _controlPoints.Add(new Point(new ComplexBaseArgument(holder.RealPartXOfControlPoints.ElementAt(i), 0), 
                    new ComplexBaseArgument(holder.RealPartYOfControlPoints.ElementAt(i), 0),
                    new ComplexBaseArgument(holder.RealPartZOfControlPoints.ElementAt(i),
                        holder.ImaginePartZOfControlPoints.ElementAt(i))));
            }

            _controlPoints.ElementAt(0).X.ImaginePart = holder.ImaginePartOfFirstX;
            _controlPoints.ElementAt(0).Y.ImaginePart = holder.ImaginePartOfFirstY;
                
            ImaginePartDeterminant.DefineImaginePart(_controlPoints);

                
            var x1SubtractX0 = _controlPoints.ElementAt(1).X - _controlPoints.ElementAt(0).X;
            var y1SubtractY0 = _controlPoints.ElementAt(1).Y - _controlPoints.ElementAt(0).Y;
            var y2SubtractY1 = _controlPoints.ElementAt(2).Y - _controlPoints.ElementAt(1).Y;
            var z2SubtractZ1 = _controlPoints.ElementAt(2).Z - _controlPoints.ElementAt(1).Z;
                
                
            _controlPoints.ElementAt(3).Z = 2*(y2SubtractY1 * z2SubtractZ1) / y1SubtractY0 + _controlPoints.ElementAt(2).Z;

            _controlPoints.ElementAt(3).X = ((-(z2SubtractZ1^2)) - (y2SubtractY1^2)) / (x1SubtractX0) + _controlPoints.ElementAt(2).X;
                
            ComplexBaseArgument x3SubtractX2 = _controlPoints.ElementAt(3).X - _controlPoints.ElementAt(2).X;

            _controlPoints.ElementAt(3).Y = ((-2 * (z2SubtractZ1 ^ 2)) - (x1SubtractX0 * x3SubtractX2)) / y1SubtractY0 +
                                            _controlPoints.ElementAt(2).Y;
            

            holder.RealPartXOfControlPoints[3] = _controlPoints.ElementAt(3).X.RealPart;
            holder.RealPartYOfControlPoints[3] = _controlPoints.ElementAt(3).Y.RealPart;
            holder.RealPartZOfControlPoints[3] = _controlPoints.ElementAt(3).Z.RealPart;
            
        }

        private IList<string> GetReportAboutSurface()
        {
            IList<string> informationAboutGrid = new List<string>();

           
            
            for (int i = 0; i < _valuesOfF.Count; i++)
            {
                informationAboutGrid.Add("X: " + $"{_realPartX.ElementAt(i),10:0.00000}  " +
                                         "Y: " + $"{_realPartY.ElementAt(i),10:0.00000}  " +
                                         "Z: " + $"{_realPartZ.ElementAt(i),10:0.00000}  " +
                                         "F: " + $"{_valuesOfF.ElementAt(i),10:0.00000}  " +
                                         "G: " + $"{_g.ElementAt(i),10:0.00000}  " +
                                         "E: " + $"{_e.ElementAt(i),10:0.00000}  " );
                
            }

            return informationAboutGrid;
        }

        private void CalculateMainSurfaceCharacteristics(ComplexBaseArgument[,] complexArgs, double step)
        {
            List<double> derivativeXByU = PrivateDerivativeHelper.ExecuteDerivativeXByU(complexArgs, _points, step);
            List<double> derivativeXByV = PrivateDerivativeHelper.ExecuteDerivativeXByV(complexArgs, _points, _k*step);
            List<double> derivativeYByU = PrivateDerivativeHelper.ExecuteDerivativeYByU(complexArgs, _points, step);
            List<double> derivativeYByV = PrivateDerivativeHelper.ExecuteDerivativeYByV(complexArgs, _points, _k*step);
            List<double> derivativeZByU = PrivateDerivativeHelper.ExecuteDerivativeZByU(complexArgs, _points, step);
            List<double> derivativeZByV = PrivateDerivativeHelper.ExecuteDerivativeZByV(complexArgs, _points, _k*step);

                

            for (int k = 0; k < derivativeXByU.Count; k++)
            {
                _valuesOfF.Add(derivativeXByU.ElementAt(k)*derivativeXByV.ElementAt(k) +
                               derivativeYByU.ElementAt(k)*derivativeYByV.ElementAt(k) +
                               derivativeZByU.ElementAt(k)*derivativeZByV.ElementAt(k));
            }
                
                
            for (int i = 0; i < derivativeXByU.Count; i++)
            {
                _e.Add(Math.Pow(derivativeXByU.ElementAt(i), 2) + Math.Pow(derivativeYByU.ElementAt(i),2)
                                                                + Math.Pow(derivativeZByU.ElementAt(i), 2));
                _g.Add(Math.Pow(derivativeXByV.ElementAt(i),2) + Math.Pow(derivativeYByV.ElementAt(i), 2)
                                                               + Math.Pow(derivativeZByV.ElementAt(i), 2));
            }
            
        }

        private void PrintX(double u, double v)
        {
            double res = 1 + 6 * u + 9 * u * u - 18 * v + 42 * u * v + 34.65 * u * v * v - 4.95 * u * u * v -
                9 * v * v - 11.55 * u * u * u + 1.65 * v * v * v;
            
            Console.WriteLine($"Real part X: {res}");
        }

        private void PrintY(double u, double v)
        {
            double res = 3 - 18 * u + 21 * u * u - 6 * v - 18 * u * v + 18.45 * u * v * v + 15.15 * u * u * v -
                         21 * v * v - 6.15 * u * u * u - 5.05 * v * v * v;
            
            Console.WriteLine($"Real part Y {res}");
        }

        private void PrintZ(double u, double v)
        {
            double res = 1 + 9 * u * u - 24 * u * v - 3 * u * v * v + 36 * u * u * v - 9 * v * v + u * u * u -
                         12 * v * v * v;
            
            Console.WriteLine($"Real part Z: {res}");
        }

        private string GetStringWithImaginePartsOfControlPoints()
        {
            string imaginePartsX = string.Empty;
            string imaginePartsY = string.Empty;
            string imaginePartsZ = string.Empty;

            for (int i = 0; i < _controlPoints.Count; i++)
            {
                imaginePartsX += _controlPoints.ElementAt(i).X.ImaginePart.ToString(CultureInfo.InvariantCulture) + " ";
                imaginePartsY += _controlPoints.ElementAt(i).Y.ImaginePart.ToString(CultureInfo.InvariantCulture) + " ";
                imaginePartsZ += _controlPoints.ElementAt(i).Z.ImaginePart.ToString(CultureInfo.InvariantCulture) + " ";

                if (i == _controlPoints.Count - 1) continue;
                
                imaginePartsX += ", ";
                imaginePartsY += ", ";
                imaginePartsZ += ", ";
            }

            return $"X: {imaginePartsX}; Y: {imaginePartsY}; Z: {imaginePartsZ}";

        }

        private async Task SaveFileOnServer(FileViewModel fileViewModel)
        {
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot",
                "data.json");

            await using var stream = new FileStream(path, FileMode.Create);
            
            await fileViewModel.File.CopyToAsync(stream);
            
        }

        private string GetDataFromJsonFile()
        {
            string json = "";

            var webRoot = _env.WebRootPath;
            var fileName = System.IO.Path.Combine(webRoot, "data.json");

            using (StreamReader r = new StreamReader(fileName))
            {
                json = r.ReadToEnd();
            }

            return json;
        }

        private string ValidateDataHolder(DataHolder dataHolder)
        {
            if (dataHolder.RealPartXOfControlPoints == null)
            {
                return $"Property {nameof(dataHolder.RealPartXOfControlPoints)} do not set";
            }
            
            if (dataHolder.RealPartYOfControlPoints == null)
            {
                return $"Property {nameof(dataHolder.RealPartYOfControlPoints)} do not set";
            }
            
            if (dataHolder.RealPartZOfControlPoints == null)
            {
                return $"Property {nameof(dataHolder.RealPartZOfControlPoints)} do not set";
            }
            
            if (dataHolder.ImaginePartZOfControlPoints == null)
            {
                return $"Property {nameof(dataHolder.ImaginePartZOfControlPoints)} do not set";
            }
            
            if (dataHolder.NodalVector == null)
            {
                return $"Property {nameof(dataHolder.NodalVector)} do not set";
            }
            
            if (dataHolder.RealPartXOfControlPoints.Count != dataHolder.RealPartYOfControlPoints.Count ||
                dataHolder.RealPartXOfControlPoints.Count != dataHolder.RealPartZOfControlPoints.Count)
            {
                return "Count of real parts of control points do not match";
            }

            if (dataHolder.ImaginePartZOfControlPoints.Count != dataHolder.RealPartZOfControlPoints.Count)
            {
                return
                    "Count of imagine parts of z coordinate of control points do not match with count of real parts of z coordinate";
            }

            if ((dataHolder.Degree + dataHolder.RealPartXOfControlPoints.Count + 1) != dataHolder.NodalVector.Length)
            {
                return
                    $"Nodal vector must contains {dataHolder.Degree + dataHolder.RealPartXOfControlPoints.Count + 1} elements";
            }

            return string.Empty;
        }
    }
}
