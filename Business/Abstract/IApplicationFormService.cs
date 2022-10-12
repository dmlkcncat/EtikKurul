using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationFormService
    {
        IDataResult<List<ApplicationForm>> GetAll();
        IResult Add(ApplicationForm applicationForm);
        IResult Delete(ApplicationForm applicationForm);
        IResult Update(ApplicationForm applicationForm);
    }
}
