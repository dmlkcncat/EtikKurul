using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }
        public string OfficePhone { get; set; }
        public string Phone { get; set; }
        public string Eposta { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }
        public bool Active { get; set; }
        public bool StateActive { get; set; }
        public Role Role { get; set; }
    }
}
