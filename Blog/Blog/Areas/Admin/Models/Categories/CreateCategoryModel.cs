using CoreLayer.DTOs.Categories;
using System.ComponentModel.DataAnnotations;

namespace Blog.Areas.Admin.Models.Categories
{
    public class CreateCategoryModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} is required!")]
        public string Title { get; set; }

        [Display(Name = "Slug")]
        [Required(ErrorMessage = "{0} is required!")]
        public string Slug { get; set; }

        public string MetaTag { get; set; }

        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }

        public int? ParentId { get; set; }

        public CreateCategoryDto MapToDto()
        {
            return new CreateCategoryDto()
            {
                Title = Title,
                Slug = Slug,
                MetaTag = MetaTag,
                MetaDescription = MetaDescription,
                ParentId = ParentId,
            };
        }
    }
}
