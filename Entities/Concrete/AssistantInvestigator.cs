using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AssistantInvestigator : IEntity
    {
        public int Id { get; set; }
        public int ApplicantUserId { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
    }
}
