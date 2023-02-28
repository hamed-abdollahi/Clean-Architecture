﻿using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Clean.Application.Services.User.Query.GetUsers
{
    public class GetUsersQuery : IRequest<GetUsersResultDto>
    {
        public string? Key { get; set; }
        public int page { get; set; }

    }
}
