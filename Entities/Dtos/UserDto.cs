using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserDto : IDto
    {
        public string FullName { get; set; }
        public string OfficePhone { get; set; }
        public string Phone { get; set; }
        public string Eposta { get; set; }
        public string Address { get; set; }
    }
}
