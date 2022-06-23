using Application.Constants;
using Application.Extensions;
using Application.Helper;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IUserRepository userRepositroy, IMapper mapper)
        {
            _userRepository = userRepositroy;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _userRepository.Get(request.UserId);
            if (data.IsNull())
            {
                return Messages.NotFound;
            }
            if (!string.IsNullOrEmpty(data.ImagePath) && !Directory.Exists(data.ImagePath))
            {
                ImageOperationHelper.DeleteImage(data.ImagePath, data.Guid);
            }
            await _userRepository.Delete(request.UserId);

            return Messages.Delete;
        }
    }
}
