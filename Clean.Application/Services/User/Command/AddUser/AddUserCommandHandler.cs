using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Services.User.Command.AddUser
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
                Family= request.Family,
                Email= request.Email,
                Password= request.Password
            };
            return _addUserService.AddUser(user, cancellationToken);
        }

    }
}
