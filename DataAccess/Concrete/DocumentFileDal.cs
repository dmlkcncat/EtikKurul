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
    public class DocumentFileDal : EfEntityRepositoryBase<DocumentFile, EtikContext>, IDocumentFileDal
    {
        public DocumentFile GetById(int id)
        {
            using (EtikContext context = new EtikContext())
            {
                var query = context.DocumentFile.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
