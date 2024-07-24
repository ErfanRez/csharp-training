using CoreLayer.DTOs.Posts;
using CoreLayer.Mappers;
using CoreLayer.Utilities;
using DAL.Context;

namespace CoreLayer.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly DB _context;

        public PostService(DB context)
        {
            _context = context;
        }

        public OperationResult CreatePost(CreatePostDto command)
        {
            var post = PostMapper.CreateMapper(command);
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
    }
}
