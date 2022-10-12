using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IApplicationDal : IEntityRepository<Application>
    {
        Application GetById(int id);
        public List<Application> GetDetail();
        public List<Application> GetExpectedApplication();
        public List<Application> GetSignatureExpected();
        public List<Application> GetUpdateExpected();
        public List<Application> GetCompleteApplication();
        public List<Application> GetRedApplication();
        public List<Application> GetAllById(int id);
        void AddApplicant(Application application);
    }
}
