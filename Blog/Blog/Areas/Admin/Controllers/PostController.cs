using Blog.Areas.Admin.Models.Posts;
using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Posts;
using CoreLayer.Utilities;
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
        public IActionResult Add(CreatePostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _postService.CreatePost(new CreatePostDto()
            {
                CategoryId = model.CategoryId,
                Title = model.Title,
                Description = model.Description,
                Slug = model.Slug,
                SubCategoryId = model.SubCategoryId,
                Image = model.ImageFile,
                UserId = User.GetUserId(),
            });

            if (result.Status != OperationResultStatus.Success)
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null) return RedirectToAction("Index");

            var model = new EditPostModel()
            {
                CategoryId = post.CategoryId,
                Title = post.Title,
                Description = post.Description,
                Slug = post.Slug,
                SubCategoryId = post.SubCategoryId,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _postService.EditPost(new EditPostDto()
            {
                CategoryId = model.CategoryId,
                Title = model.Title,
                Description = model.Description,
                Slug = model.Slug,
                SubCategoryId = model.SubCategoryId,
                Image = model.ImageFile,
                Id = id,
            });

            if (result.Status != OperationResultStatus.Success)
                return View();

            return RedirectToAction("Index");
        }
    }
}
