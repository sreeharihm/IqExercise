using Application.Dto;
using MediatR;

namespace Application.Features.User.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<List<UserModel>>
    {

        public string Filter { get; set; }

        public int? Skip { get; set; }

        public int? Take { get; set; }
        public string SortField { get; set; }
        public string SortKey { get; set; }
    }
}
