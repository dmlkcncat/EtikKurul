using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Application : IEntity
    {
        public int Id { get; set; }
        public string ProjectNo { get; set; }
        public int ApplicationStatusId { get; set; }
        public int PrincipalInvestigatorId { get; set; }
        public string Kod { get; set; }
        public string ApplicationName { get; set; }
        public int ApplicationQualificationId { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }
        public ApplicantUser PrincipalInvestigator { get; set; }
        public ApplicationQualification ApplicationQualification { get; set; }

    }
}
