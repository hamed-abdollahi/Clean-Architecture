﻿namespace Clean.PostMicroService.Application.Services.Query.GetUser
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }

    }
}
