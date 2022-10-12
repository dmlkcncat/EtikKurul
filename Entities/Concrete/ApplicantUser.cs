using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ApplicantUser : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Eposta { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }
    }
}
