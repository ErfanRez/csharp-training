using CoreLayer.DTOs.Posts;
using CoreLayer.Utilities;

namespace CoreLayer.Services.Posts
{
    public interface IPostService
    {
        OperationResult CreatePost(CreatePostDto command);

        OperationResult EditPost(EditPostDto command);

        PostDto GetPostById(int id);

        bool SlugExist(string slug);
    }
}
