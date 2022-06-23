using Application.Dto;
using MediatR;

namespace Application.Features.User.Queries.GetAllUserById
{
    public class GetAllUserByIdQuery :IRequest<UserModel>
    {
        public int UserId { get; set; }
    }
}
