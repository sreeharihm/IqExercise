using Application.Constants;
using Application.Extensions;
using Application.Helper;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepositroy)
        {
            _userRepository = userRepositroy;
        }
        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsNull())
            {
                var path = string.Empty;
                var data = await _userRepository.Get(request.Id);
                if (data.IsNull())
                {
                    return Messages.NotFound;
                }
                if (!string.IsNullOrEmpty(request.ImageName) && !string.IsNullOrEmpty(request.ImageData))
                {
                    path = await ImageOperationHelper.UploadImageAsync(request.ImageData, request.ImageName, data.Guid);
                }
                data.Name = request.Name;
                data.Desgination = request.Desgination;
                data.Address = request.Address;
                data.Street = request.Street;
                data.City = request.City;
                data.State = request.State;
                data.PinCode = request.PinCode;
                data.JoiningDate = request.JoiningDate;
                data.Country = request.Country;
                data.ImagePath = path;
                await _userRepository.Update(data);
            }
            return Messages.Update;
        }
    }
}
