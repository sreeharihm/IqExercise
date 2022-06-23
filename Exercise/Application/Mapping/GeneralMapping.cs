using AutoMapper;
using Domain.Entites;
using Application.Dto;
using Application.Features.User.Commands.AddUser;
using Application.Features.User.Commands.UpdateUser;

namespace Application.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<User, AddUserCommand>()
                .ReverseMap();
            CreateMap<User, UpdateUserCommand>()
               .ReverseMap();

        }
    }
}
