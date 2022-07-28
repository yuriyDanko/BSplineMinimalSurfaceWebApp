using System.ComponentModel.DataAnnotations;
using BSplineGridWebApp.Validation;
using Microsoft.AspNetCore.Http;

namespace BSplineGridWebApp.ViewModels
{
    public class FileViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new [] { ".json"})]
        public IFormFile File { get; set; }
    }
}