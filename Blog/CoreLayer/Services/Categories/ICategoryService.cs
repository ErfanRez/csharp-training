using CoreLayer.DTOs.Categories;
using CoreLayer.Utilities;

namespace CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto command);

        OperationResult EditCategory(EditCategoryDto command);

        List<CategoryDto> GetAllCategories();

        CategoryDto? GetCategoryBy(int id);

        CategoryDto? GetCategoryBy(string slug);
    }

}
