using CoreLayer.DTOs.Posts;
using DAL.Entities;

namespace CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post CreateMapper(CreatePostDto dto)
        {
            return new Post()
            {
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Slug = dto.Slug,
                Title = dto.Title,
                UserId = dto.UserId,
                Visit = 0,
                IsDeleted = false,
                SubCategoryId = dto.SubCategoryId,
            };
        }

        public static Post EditMapper(EditPostDto dto, Post post)
        {
            post.Description = dto.Description;
            post.CategoryId = dto.CategoryId;
            post.Slug = dto.Slug;
            post.Title = dto.Title;
            post.SubCategoryId = dto.SubCategoryId;
            return post;
        }

        public static PostDto MapToDto(Post post)
        {
            return new PostDto()
            {
                Description = post.Description,
                CategoryId = post.CategoryId,
                Slug = post.Slug,
                Title = post.Title,
                UserId = post.UserId,
                Visit = post.Visit,
                CreatedAt = post.CreatedAt,
                Category = CategoryMapper.Map(post.Category),
                Image = post.Image,
                Id = post.Id,
                SubCategoryId = post.SubCategoryId,
                SubCategory = post.SubCategoryId != null ? CategoryMapper.Map(post.SubCategory) : null,
            };
        }

    }
}
