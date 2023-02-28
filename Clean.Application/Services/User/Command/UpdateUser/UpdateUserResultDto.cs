﻿using MediatR;

namespace Clean.Application.Services.User.Command.UpdateUser
{

    public class UpdateUserResultDto 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

}
