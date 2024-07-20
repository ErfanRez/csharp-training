using System.ComponentModel.DataAnnotations;

namespace Blog.Areas.Admin.Models.Categories
{
    public class EditCategoryModel
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
    }
}


