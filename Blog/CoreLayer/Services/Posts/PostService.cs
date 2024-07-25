using CoreLayer.DTOs.Posts;
using CoreLayer.Mappers;
using CoreLayer.Services.FileManager;
using CoreLayer.Utilities;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CoreLayer.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly DB _context;
        private readonly IFileManager _fileManger;

        public PostService(DB context, IFileManager fileManager)
        {
            _context = context;
            _fileManger = fileManager;
        }

        public OperationResult CreatePost(CreatePostDto command)
        {
            if (command.Image == null)
            {
                return OperationResult.Error();
            }
            var post = PostMapper.CreateMapper(command);
            post.Image = _fileManger.SaveFile(command.Image, Directories.PostImage);

            _context.Posts.Add(post);
            _context.SaveChanges();

            return OperationResult.Success();
        }

        public OperationResult EditPost(EditPostDto command)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == command.Id);
            if (post == null)
            {
                return OperationResult.NotFound();
            }

            PostMapper.EditMapper(command, post);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public PostDto GetPostById(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            return PostMapper.MapToDto(post);
        }

        public bool SlugExist(string slug)
        {
            return _context.Posts.Any(p => p.Slug == slug.ToSlug());
        }

        PostFilterDto IPostService.GetPostByFilter(PostFilterParams filterParams)
        {
            var result = _context.Posts
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .OrderBy(p => p.CreatedAt)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterParams.CategorySlug)) result = result.Where(p => p.Category.Slug == filterParams.CategorySlug);

            if (!string.IsNullOrWhiteSpace(filterParams.Title)) result = result.Where(p => p.Title.Contains(filterParams.Title));

            var skip = (filterParams.PageId - 1) * filterParams.Take;
            var pageCount = result.Count() / filterParams.Take;

            return new PostFilterDto()
            {
                Posts = result.Skip(skip).Take(filterParams.Take).Select(p => PostMapper.MapToDto(p)).ToList(),
                FilterParams = filterParams,
                PageCount = pageCount
            };


        }
    }
}
