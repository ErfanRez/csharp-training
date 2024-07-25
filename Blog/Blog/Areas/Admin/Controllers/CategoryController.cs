using Blog.Areas.Admin.Models.Categories;
using CoreLayer.DTOs.Categories;
using CoreLayer.Services.Categories;
using CoreLayer.Utilities;
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

        [Route("/admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId)
        {

            return View();
        }

        [HttpPost("/admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId, CreateCategoryModel categoryModel)
        {
            categoryModel.ParentId = parentId;
            var result = _categoryService.CreateCategory(categoryModel.MapToDto());

            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(categoryModel.Title), result.Message);
                return View();
            }

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryBy(id);
            if (category == null) return RedirectToAction("Index");
            var model = new EditCategoryModel()
            {
                Title = category.Title,
                Slug = category.Slug,
                MetaTag = category.MetaTag,
                MetaDescription = category.MetaDescription,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryModel model)
        {
            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Id = id,
                Title = model.Title,
                Slug = model.Slug,
                MetaTag = model.MetaTag,
                MetaDescription = model.MetaDescription,
            });

            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(model.Title), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult GetChildCategories(int parentId)
        {
            var category = _categoryService.GetChildCategories(parentId);

            return new JsonResult(category);
        }
    }
}
