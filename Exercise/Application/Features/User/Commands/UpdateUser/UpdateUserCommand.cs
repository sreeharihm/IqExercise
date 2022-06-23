
using MediatR;

namespace Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desgination { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public Guid Guid { get; set; }
        public string ImageData { get; set; }
        public string ImageName { get; set; }
    }
}
