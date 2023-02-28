using Clean.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Clean.Application.Services.User.Query.GetUser
{
    public class GetUserQuery : IRequest<GetUserDto>
    {
        public int Id { get; set; }
    }
}
