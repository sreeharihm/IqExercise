using MediatR;

namespace Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<string>
    {
        public int UserId { get; set; }
    }
}
