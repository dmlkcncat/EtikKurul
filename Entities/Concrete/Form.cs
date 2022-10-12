using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Form : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Path { get; set; }
    }
}
