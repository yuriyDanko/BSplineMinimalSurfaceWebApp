#pragma checksum "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "721ba9e4cdfe43a8c4a7de00b96b22d08261024e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Grid_grid), @"mvc.1.0.view", @"/Views/Grid/grid.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
using BSplineGridWebApp.Models.BusinessLogic.Point;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"721ba9e4cdfe43a8c4a7de00b96b22d08261024e", @"/Views/Grid/grid.cshtml")]
    public class Views_Grid_grid : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BSplineGridWebApp.ViewModels.FileViewModel>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n<!DOCTYPE html>\n\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "721ba9e4cdfe43a8c4a7de00b96b22d08261024e2961", async() => {
                WriteLiteral(@"
    <title>title</title>
    <script src='https://cdn.plot.ly/plotly-latest.min.js'></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.0/jquery.min.js""></script>
    <script src=""https://cdn.jsdelivr.net/npm/jquery-validation@1.19.1/dist/jquery.validate.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js""></script>
    
    <style>
    input[type=""file""] {
    display: none;
}
.custom-file-upload {
    border: 1px solid #ccc;
    display: inline-block;
    padding: 6px 12px;
    cursor: pointer;
}
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "721ba9e4cdfe43a8c4a7de00b96b22d08261024e4553", async() => {
                WriteLiteral("\n<div>\n");
#nullable restore
#line 28 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
      
        
        var error= ViewData["error"] as string;
    
        var realPartX = (double[])ViewData["realPartX"];
        var realPartY = (double[]) ViewData["realPartY"];
        var realPartZ = (double[]) ViewData["realPartZ"];
        var informationAboutGrid = ViewData["informationAboutGrid"] as List<string>;
        var realPartXOfControlPoints = ViewData["realPartXOfControlPoints"] as List<double>;
        var realPartYOfControlPoints = ViewData["realPartYOfControlPoints"] as List<double>;
        var realPartZOfControlPoints = ViewData["realPartZOfControlPoints"] as List<double>;

        var realPartXOfControlPointsString = ViewData["realPartXOfControlPointsString"] as string;
        var realPartYOfControlPointsString = ViewData["realPartYOfControlPointsString"] as string;
        var realPartZOfControlPointsString = ViewData["realPartZOfControlPointsString"] as string;

        var imaginePartsOfControlPointsString = ViewData["imaginePartsOfControlPointsString"] as string;

        var degree = ViewData["degree"] as string;
        var nodalVectorString = ViewData["nodalVector"] as string;
        var imaginePartOfFirstX = ViewData["imaginePartOfFirstX"] as string;
        var imaginePartOfFirstY = ViewData["imaginePartOfFirstY"] as string;

    

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n");
#nullable restore
#line 53 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
     if (@error != string.Empty)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>alert(");
#nullable restore
#line 55 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                 Write(Html.Raw(Json.Serialize(@error)));

#line default
#line hidden
#nullable disable
                WriteLiteral(");</script>\n");
#nullable restore
#line 56 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("  \n\n");
                WriteLiteral(@"    <form asp-controller=""Grid"" asp-action=""Grid"" method=""post""  
          enctype=""multipart/form-data"">
        <label asp-for = ""File"" for=""file-upload"" class=""custom-file-upload"">
            <i class=""fa fa-cloud-upload""></i> Select File
        </label>
        <input asp-for = ""File"" id=""file-upload"" type=""file"" name = ""file""/>
        <button class=""custom-file-upload"" type=""submit"">Upload File</button>
       
        <span class=""field-validation-valid text-danger"" 
                data-valmsg-for=""File"" 
                data-valmsg-replace=""true"">
        </span>
    </form> 
    
   
    
    <br/>
    <div>Degree of b-spline: ");
#nullable restore
#line 77 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                        Write(degree);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n    <div>Nodal vector: ");
#nullable restore
#line 78 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                  Write(nodalVectorString);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n    <div>Real part of x of control points: ");
#nullable restore
#line 79 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                                      Write(realPartXOfControlPointsString);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n    <div>Real part of y of control points: ");
#nullable restore
#line 80 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                                      Write(realPartYOfControlPointsString);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n    <div>Real part of z of control points: ");
#nullable restore
#line 81 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                                      Write(realPartZOfControlPointsString);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n    <div>Imagine part of first x of control point: ");
#nullable restore
#line 82 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                                              Write(imaginePartOfFirstX);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div> \n    <div>Imagine part of first y of control point: ");
#nullable restore
#line 83 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                                              Write(imaginePartOfFirstY);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n    <div>Imagine parts of control points: ");
#nullable restore
#line 84 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                                     Write(imaginePartsOfControlPointsString);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</div>

    <div id='myDiv' style=""height:600px; width:100%;""></div>
    
    <h2 style=""text-align: center; font-family: Verdana,serif; font-size: 12px;"">Orthogonal and isothermal characteristics</h2>
    <textarea style=""width: 100%; height: 150px; text-align: center"">
");
#nullable restore
#line 90 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
     if (@informationAboutGrid != null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
         foreach(var inf in @informationAboutGrid)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
       Write(inf);

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
                ;

#line default
#line hidden
#nullable disable
                WriteLiteral("            <br>\n");
#nullable restore
#line 96 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
         
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </textarea>\n    \n    \n</div>\n<script>\n\nvar trace1 = {\n  x: ");
#nullable restore
#line 105 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
Write(Html.Raw(Json.Serialize(@realPartX)));

#line default
#line hidden
#nullable disable
                WriteLiteral(",\n  y: ");
#nullable restore
#line 106 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
Write(Html.Raw(Json.Serialize(@realPartY)));

#line default
#line hidden
#nullable disable
                WriteLiteral(",\n  z: ");
#nullable restore
#line 107 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
Write(Html.Raw(Json.Serialize(@realPartZ)));

#line default
#line hidden
#nullable disable
                WriteLiteral(",\n  name: \'Grid\',\n  mode: \'markers\',\n  type: \'scatter3d\',\n  marker: {\n          color: \'black\',\n          size: 1\n        }\n};\n\nvar trace2 = {\n    x: ");
#nullable restore
#line 118 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
  Write(Html.Raw(Json.Serialize(@realPartXOfControlPoints)));

#line default
#line hidden
#nullable disable
                WriteLiteral(",\n    y: ");
#nullable restore
#line 119 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
  Write(Html.Raw(Json.Serialize(@realPartYOfControlPoints)));

#line default
#line hidden
#nullable disable
                WriteLiteral(",\n    z: ");
#nullable restore
#line 120 "/home/tiger/solutions/BSplineMinimalSurfaceWebApp/BSplineGridWebApp/BSplineGridWebApp/Views/Grid/grid.cshtml"
  Write(Html.Raw(Json.Serialize(@realPartZOfControlPoints)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",

    name : 'characteristic polygon',
    mode: 'markers',
    type: 'scatter3d'
   };


var layout = {
   scene:{
	xaxis: {
	 backgroundcolor: ""black"",
	 showbackground: false,
	}, 
    yaxis: {
     backgroundcolor: ""black"",
     showbackground: false,
    },
     zaxis: {
         backgroundcolor: ""black"",
         showbackground: false,
        }
}
};

var data = [trace1];

Plotly.newPlot('myDiv', data, layout);
</script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BSplineGridWebApp.ViewModels.FileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
