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
    public class AsistantInvestigatorDal : EfEntityRepositoryBase<AssistantInvestigator, EtikContext>, IAsistantInvestigatorDal
    {
        public AssistantInvestigator GetById(int id)
        {
            using (EtikContext context = new EtikContext())
            {
                var query = context.AssistantInvestigator.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
