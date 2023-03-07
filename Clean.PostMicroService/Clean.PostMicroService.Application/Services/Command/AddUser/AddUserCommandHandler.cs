﻿using Clean.PostMicroService.Domain.Entities;
using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserResultDto>
    {
        private readonly IAddUserService _addUserService;

        public AddUserCommandHandler(IAddUserService addUserService)
        {
            _addUserService = addUserService;
        }

        public Task<AddUserResultDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity()
            {
                Name= request.Name,
                Family= request.Family
            };
            return _addUserService.AddUser(user, cancellationToken);
        }

    }
}
