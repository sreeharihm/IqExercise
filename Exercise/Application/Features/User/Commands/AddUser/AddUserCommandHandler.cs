using Application.Constants;
using Application.Extensions;
using Application.Helper;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AddUserCommandHandler(IUserRepository userRepositroy, IMapper mapper)
        {
            _userRepository = userRepositroy;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsNull())
            {
                Guid guid = Guid.NewGuid();
                var path = string.Empty;

                if (!string.IsNullOrEmpty(request.ImageName) && !string.IsNullOrEmpty(request.ImageData))
                {
                    path = await ImageOperationHelper.UploadImageAsync(request.ImageData, request.ImageName, guid);
                }
                
                var user = _mapper.Map<Domain.Entites.User>(request);
                user.ImagePath = path;
                user.Guid = guid;
                await _userRepository.Add(user);
            }
            return Messages.Create;
        }
    }
}
