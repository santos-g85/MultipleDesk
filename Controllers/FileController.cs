using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace MultipleDesk.Controllers
{
    public class FileController : Controller
    {
        public IActionResult FileDownload()
        {
           string filepath = @"C:\Users\DELL\Downloads\Internship_Report_Improved.pdf";
            string filename = "Internship_Report_Improved.pdf";
            string contentType = "application/octet-stream";
            // Check if the file exists
            if (!System.IO.File.Exists(filepath))
            {
                return NotFound();
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out contentType))
            {
               //default already set
            }

            else {
                var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                return File(fileStream, contentType, filename);
            }
            return View();
        }
    }
}
