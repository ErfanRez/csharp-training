using Blog.Areas.Admin.Models.Categories;
using CoreLayer.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateCategoryModel categoryModel)
        {
            var result = _categoryService.CreateCategory(categoryModel.MapToDto());
            return Redirect("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
