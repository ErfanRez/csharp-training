﻿namespace CoreLayer.DTOs.Posts
{
    public class CreatePostDto
    {

        public string Title { get; set; }


        public string Description { get; set; }

        public string Slug { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }
    }
}