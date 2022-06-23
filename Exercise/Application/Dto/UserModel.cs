using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desgination { get; set; }
        public DateTime JoiningDate { get; set; }
        public string FullAddress { get; set; }
        public string Country { get; set; }
        public string ImagePath { get; set; }
    }
}
