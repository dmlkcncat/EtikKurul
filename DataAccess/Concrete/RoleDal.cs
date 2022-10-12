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
    public class RoleDal : EfEntityRepositoryBase<Role, EtikContext>, IRoleDal
    {
        public Role GetById(int id)
        {
            using (EtikContext context = new EtikContext())
            {
                var query = context.Role.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
