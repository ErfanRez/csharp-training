namespace CoreLayer.Utilities
{
    public class Directories
    {
        public const string PostImage = "wwwroot/images/posts";

        public static string GetPostImage(string imageName) => $"{PostImage.Replace("wwwroot", "")}/{imageName}";

    }
}
