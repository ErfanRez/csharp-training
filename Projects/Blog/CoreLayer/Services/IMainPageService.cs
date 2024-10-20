using System.Linq;
using CoreLayer.DTOs;
using CoreLayer.DTOs.Posts;
using CoreLayer.Mappers;
using CoreLayer.Services.Posts;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace CoreLayer.Services
{
    public interface IMainPageService
    {
        MainPageDto GetData();
    }

    public class MainPageService : IMainPageService
    {
        private readonly BlogContext _context;
        public MainPageService(BlogContext context)
        {
            _context = context;
        }

        public MainPageDto GetData()
        {
            var categories = _context.Categories
                .OrderByDescending(d => d.Id)
                .Take(6)
                .Include(c => c.Posts)
                .Include(c => c.SubPosts)
                .Select(category => new MainPageCategoryDto()
                {
                    Title = category.Title,
                    Slug = category.Slug,
                    PostChild = category.Posts.Count + category.SubPosts.Count,
                    IsMainCategory = category.ParentId == null
                }).ToList();

            var specialPosts = _context.Posts
                .OrderByDescending(d => d.Id)
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .Where(r => r.IsSpecial).Take(4)
                .Select(post => PostMapper.MapToDto(post)).ToList();

            var latestPost = _context.Posts
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .OrderByDescending(d => d.Id)
                .Take(6)
                .Select(post=>PostMapper.MapToDto(post)).ToList();

            return new MainPageDto()
            {
                LatestPosts = latestPost,
                Categories = categories,
                SpecialPosts = specialPosts
            };
        }
    }
}