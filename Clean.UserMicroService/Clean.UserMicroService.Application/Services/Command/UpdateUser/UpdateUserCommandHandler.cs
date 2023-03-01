using Clean.UserMicroService.Application.Services.Command.AddUser;
using Clean.UserMicroService.Domain.Entities;
using MediatR;

namespace Clean.UserMicroService.Application.Services.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResultDto>
    {
        private readonly IUpdateUserService _updateUserService;

        public UpdateUserCommandHandler(IUpdateUserService updateUserService)
        {
            _updateUserService = updateUserService;
        }

        public Task<UpdateUserResultDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity()
            {
                Id = request.Id,
                Name = request.Name,
                Family = request.Family,
                Email = request.Email,
                Password = request.Password
            };
            return _updateUserService.UpdateUser(user, cancellationToken);
        }

        
    }
}
