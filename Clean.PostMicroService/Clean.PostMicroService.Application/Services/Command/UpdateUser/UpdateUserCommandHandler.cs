using Clean.PostMicroService.Application.Services.Command.AddUser;
using Clean.PostMicroService.Domain.Entities;
using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.UpdateUser
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
                UserId = request.UserId,
                Name = request.Name,
                Family = request.Family,
            };
            return _updateUserService.UpdateUser(user, cancellationToken);
        }

        
    }
}
