using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Clean.UserMicroService.Application.Services.Query.GetUsers
{
    public class GetUsersQuery : IRequest<GetUsersResultDto>
    {
        public string? Key { get; set; }
        public int page { get; set; }

    }
}
