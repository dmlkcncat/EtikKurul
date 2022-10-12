using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUpdateApplicationService
    {
        IDataResult<List<UpdateApplication>> GetAll();
        IResult Add(UpdateApplication updateApplication);
        IResult Delete(UpdateApplication updateApplication);
        IResult Update(UpdateApplication updateApplication);
        IDataResult<UpdateApplication> GetById(int Id);
    }
}
