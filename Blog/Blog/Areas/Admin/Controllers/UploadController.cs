using CoreLayer.Services.FileManager;
using CoreLayer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileManager _FileManager;

        public UploadController(IFileManager fileManager)
        {
            _FileManager = fileManager;
        }

        [Route("/Upload/Article")]
        [Authorize]
        public IActionResult UploadArticleImage(IFormFile upload)
        {
            if (upload == null) return BadRequest();

            var imageName = _FileManager.SaveFile(upload, Directories.PostContentImage);

            return Json(new { Uploaded = true, url = Directories.GetPostContentImage(imageName) });
        }
    }
}
