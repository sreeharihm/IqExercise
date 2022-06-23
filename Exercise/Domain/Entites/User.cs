using Domain.Common;

namespace Domain.Entites
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Desgination { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public string ImagePath { get; set; }
    }
}
