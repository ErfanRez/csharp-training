using System.Collections.Generic;
using CoreLayer.DTOs.Categories;
using CoreLayer.Utilities;

namespace CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto command);
        OperationResult EditCategory(EditCategoryDto command);
        List<CategoryDto> GetAllCategory();
        List<CategoryDto> GetChildCategories(int parentId);
        CategoryDto GetCategoryBy(int id);
        CategoryDto GetCategoryBy(string slug);
        bool IsSlugExist(string slug);
    }
}