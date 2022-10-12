using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ApplicationQualificationDal : EfEntityRepositoryBase<ApplicationQualification, EtikContext>, IApplicationQualificationDal
    {
        public ApplicationQualification GetById(int id)
        {
            using (EtikContext context = new EtikContext())
            {
                var query = context.ApplicationQualification.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
