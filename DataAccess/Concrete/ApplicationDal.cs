using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ApplicationDal : EfEntityRepositoryBase<Application, EtikContext>, IApplicationDal
    {
        public void AddApplicant(Application application)
        {
            using (EtikContext context = new EtikContext())
            {
                var addedEntity = context.Entry(application);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<Application> GetAllById(int id)
        {
            using (EtikContext context = new EtikContext())
            {
                return context.Set<Application>().Where(item => item.PrincipalInvestigatorId == id).ToList();
            }
        }
        public Application GetById(int id)
        {
            using (EtikContext context = new EtikContext())
            {
                var query = context.Application.Where(item => item.Id == id).Include(app => app.ApplicationStatus).Include(item => item.ApplicationQualification).Include(p => p.PrincipalInvestigator);
                return query.SingleOrDefault();
            }
        }

        public List<Application> GetCompleteApplication()
        {
            using (EtikContext context = new EtikContext())
            {
                return context.Set<Application>().Include(app => app.ApplicationStatus).Include(item => item.ApplicationQualification)
                    .Include(p => p.PrincipalInvestigator).Where(item => item.ApplicationStatusId == 6).ToList();
            }
        }

        public List<Application> GetDetail()
        {
            using (EtikContext context = new EtikContext())
            {
                return context.Set<Application>().Include(app => app.ApplicationStatus).Include(item => item.ApplicationQualification).Include(p => p.PrincipalInvestigator).ToList();
            }
        }

        public List<Application> GetExpectedApplication()
        {
            using (EtikContext context = new EtikContext())
            {
                return context.Set<Application>().Include(app => app.ApplicationStatus).Include(item => item.ApplicationQualification)
                    .Include(p => p.PrincipalInvestigator).Where(item => item.ApplicationStatusId == 1).ToList();
            }
        }

        public List<Application> GetRedApplication()
        {
            using (EtikContext context = new EtikContext())
            {
                return context.Set<Application>().Include(app => app.ApplicationStatus).Include(item => item.ApplicationQualification)
                    .Include(p => p.PrincipalInvestigator).Where(item => item.ApplicationStatusId == 3).ToList();
            }
        }

        public List<Application> GetSignatureExpected()
        {
            using (EtikContext context = new EtikContext())
            {
                return context.Set<Application>().Include(app => app.ApplicationStatus).Include(item => item.ApplicationQualification)
                    .Include(p => p.PrincipalInvestigator).Where(item => item.ApplicationStatusId == 5).ToList();
            }
        }

        public List<Application> GetUpdateExpected()
        {
            using (EtikContext context = new EtikContext())
            {
                return context.Set<Application>().Include(app => app.ApplicationStatus).Include(item => item.ApplicationQualification)
                    .Include(p => p.PrincipalInvestigator).Where(item => item.ApplicationStatusId == 2).ToList();
            }
        }
    }
}
