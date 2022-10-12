using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationService
    {
        IDataResult<List<Application>> GetAll();
        IDataResult<List<Application>> GetAllById(int id);
        IResult Add(Application application);
        IResult Delete(Application application);
        IResult Update(Application application);
        IDataResult<Application> GetById(int Id);
        IDataResult<List<Application>> GetDetail();
        IDataResult<List<Application>> GetExpectedApplication();
        IDataResult<List<Application>> GetSignatureExpected();
        IDataResult<List<Application>> GetUpdateExpected();
        IDataResult<List<Application>> GetCompleteApplication();
        IDataResult<List<Application>> GetRedApplication();
    }
}
