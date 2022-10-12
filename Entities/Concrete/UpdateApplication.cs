using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UpdateApplication : IEntity
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
