using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int pageId = 1, string title = "", string categorySlug = "")
        {
            var param = new PostFilterParams()
            {
                CategorySlug = categorySlug,
                PageId = pageId,
                Take = 20,
                Title = title
            };
            var model = _postService.GetPostByFilter(param);
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(string t)
        {
            return View();
        }
    }
}
