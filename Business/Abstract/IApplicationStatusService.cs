using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationStatusService
    {
        IDataResult<List<ApplicationStatus>> GetAll();
        IResult Add(ApplicationStatus applicationStatus);
        IResult Delete(ApplicationStatus applicationStatus);
        IResult Update(ApplicationStatus applicationStatus);
        IDataResult<ApplicationStatus> GetById(int Id);
    }
}
