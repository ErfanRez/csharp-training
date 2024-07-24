namespace CoreLayer.DTOs.Posts
{
    public class EditPostDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Slug { get; set; }

        public int CategoryId { get; set; }
    }
}
