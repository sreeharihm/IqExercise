
using Application.Dto;
using Application.Extensions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Queries.GetAllUserById
{
    public class GetAllUserByIdQueryHandler : IRequestHandler<GetAllUserByIdQuery, UserModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUserByIdQueryHandler(IUserRepository userRepositroy, IMapper mapper)
        {
            _userRepository = userRepositroy;
            _mapper = mapper;
        }
        public async Task<UserModel> Handle(GetAllUserByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _userRepository.Get(request.UserId);
            var result = new UserModel();
            if (data.IsNull())
                return result;
            var viewModel = _mapper.Map<UserModel>(data);
            viewModel.FullAddress = data.Address.GetFullAddress(data.Street, data.City, data.PinCode, data.State, data.Country);
            return viewModel;
        }
    }
}
