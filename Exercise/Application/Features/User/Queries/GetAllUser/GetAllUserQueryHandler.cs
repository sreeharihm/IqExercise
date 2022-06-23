using Application.Dto;
using Application.Extensions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IUserRepository userRepositroy, IMapper mapper)
        {
            _userRepository = userRepositroy;
            _mapper = mapper;
        }

        //Get all the user data. By default took 20 records of user based on name field ascending order
        public async Task<List<UserModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var data = await _userRepository.GetAll();
            if (data.IsNull())
            {
                return new List<UserModel>();
            }
            if (!string.IsNullOrEmpty(request.Filter))
            {
                data = FieldFilter(data, request.Filter);
            }
            var skip = request.Skip ?? 0;
            var take = request.Take ?? 20;
            var viewModel = _mapper.Map<List<UserModel>>(data);
            foreach (var item in viewModel)
            {
                var dbData = data.First(x => x.Id == item.Id);
                if (!dbData.IsNull())
                    item.FullAddress = dbData.Address.GetFullAddress(dbData.Street, dbData.City, dbData.PinCode, dbData.State, dbData.Country);
            }
            var orderBy = request.SortKey ?? "asc";
            var field = request.SortField ?? "";
            viewModel = FieldSort(viewModel, field, orderBy);
            viewModel = viewModel.Skip(skip).Take(take).ToList();

            return viewModel;

        }

        // data filtering based on mentioned fields
        private IEnumerable<Domain.Entites.User> FieldFilter(IEnumerable<Domain.Entites.User> data, string filter)
        {
            var filterExp = filter.ToLower().Split(" ");
            if (filterExp.Count() == 3 && string.Compare(filterExp[1].ToLower(), "eq") == 0)
            {
                switch (filterExp[0].ToLower())
                {
                    case "name":
                        {
                            data = data.Where(x => x.Name.ToLower().Contains(filterExp[2])).ToList();
                            break;
                        }
                    case "desgination":
                        {
                            data = data.Where(x => x.Desgination.ToLower().Contains(filterExp[2])).ToList();
                            break;
                        }
                    case "joiningdate":
                        {
                            data = data.Where(x => x.JoiningDate.Equals(Convert.ToDateTime(filterExp[2]))).ToList();
                            break;
                        }
                    case "country":
                        {
                            data = data.Where(x => x.Country.ToLower().Contains(filterExp[2])).ToList();
                            break;
                        }
                }
            }

            return data;
        }

        // data sorting based on mentioned fields
        private List<UserModel> FieldSort(List<UserModel> viewModel, string field, string orderBy)
        {
            switch (field.ToLower())
            {
                case "name":
                    {
                        viewModel = orderBy == "asc" ? viewModel.OrderBy(u => u.Name).ToList() : viewModel.OrderByDescending(u => u.Name).ToList();
                        break;
                    }
                case "desgination":
                    {
                        viewModel = orderBy == "asc" ? viewModel.OrderBy(u => u.Desgination).ToList() : viewModel.OrderByDescending(u => u.Desgination).ToList();
                        break;
                    }
                case "joiningdate":
                    {
                        viewModel = orderBy == "asc" ? viewModel.OrderBy(u => u.JoiningDate).ToList() : viewModel.OrderByDescending(u => u.JoiningDate).ToList();
                        break;
                    }
                case "country":
                    {
                        viewModel = orderBy == "asc" ? viewModel.OrderBy(u => u.Country).ToList() : viewModel.OrderByDescending(u => u.Country).ToList();
                        break;
                    }
                default:
                    {
                        viewModel = orderBy == "asc" ? viewModel.OrderBy(u => u.Name).ToList() : viewModel.OrderByDescending(u => u.Name).ToList();
                        break;
                    }
            }
            return viewModel;
        }
    }
}
