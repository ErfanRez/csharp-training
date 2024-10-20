using CoreLayer.DTOs.Categories;
using DataLayer.Entities;

namespace CoreLayer.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto Map(Category category)
        {
            return new CategoryDto()
            {
                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag,
                Slug = category.Slug,
                ParentId = category.ParentId,
                Id = category.Id,
                Title = category.Title
            };
        }
    }
}