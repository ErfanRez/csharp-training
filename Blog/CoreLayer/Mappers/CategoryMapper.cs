using CoreLayer.DTOs.Categories;
using DAL.Entities;

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
                ParentId = category.ParentId,
                Slug = category.Slug,
                Id = category.Id,
                Title = category.Title,
            };
        }
    }
}
