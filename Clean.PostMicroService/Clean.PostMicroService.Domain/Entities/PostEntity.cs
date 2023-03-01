﻿namespace Clean.PostMicroService.Domain.Entities
{
    public class PostEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public UserEntity UserEntity { get; set; }

    }
}
