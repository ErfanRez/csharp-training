using CoreLayer.DTOs.Categories;

namespace CoreLayer.DTOs.Posts
{
    public class PostDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Slug { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        public string Image { get; set; }

        public int Visit { get; set; }

        public CategoryDto Category { get; set; }

        public CategoryDto? SubCategory { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
