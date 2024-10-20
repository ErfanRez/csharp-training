using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Services.FileManager;
using CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;

namespace Web.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileManager _fileManager;

        public UploadController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }
        [Route("/Upload/Article")]

        public IActionResult UploadArticleImage(IFormFile upload)
        {
            if (upload == null)
                BadRequest();

            var imageName = _fileManager.SaveFileAndReturnName(upload, Directories.PostContentImage);

            return Json(new { Uploaded = true, url = Directories.GetPostContentImage(imageName) });
        }
    }
}
