using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ApplicationManager : IApplicationService
    {
        IApplicationDal _applicationDal;

        public ApplicationManager(IApplicationDal applicationDal)
        {
            _applicationDal = applicationDal;
        }

        public IResult Add(Application application)
        {
            _applicationDal.Add(application);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Application application)
        {
            _applicationDal.Delete(application);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Application>> GetAll()
        {
            return new SuccessDataResult<List<Application>>(_applicationDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Application>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Application>>(_applicationDal.GetAllById(id), Messages.Listed);
        }

        public IDataResult<Application> GetById(int Id)
        {
            return new SuccessDataResult<Application>(_applicationDal.GetById(Id), Messages.Listed);

        }

        public IDataResult<List<Application>> GetCompleteApplication()
        {
            return new SuccessDataResult<List<Application>>(_applicationDal.GetCompleteApplication(), Messages.Listed);

        }

        public IDataResult<List<Application>> GetDetail()
        {
            return new SuccessDataResult<List<Application>>(_applicationDal.GetDetail(), Messages.Listed);
        }

        public IDataResult<List<Application>> GetExpectedApplication()
        {
            return new SuccessDataResult<List<Application>>(_applicationDal.GetExpectedApplication(), Messages.Listed);
        }

        public IDataResult<List<Application>> GetRedApplication()
        {
            return new SuccessDataResult<List<Application>>(_applicationDal.GetRedApplication(), Messages.Listed);

        }

        public IDataResult<List<Application>> GetSignatureExpected()
        {
            return new SuccessDataResult<List<Application>>(_applicationDal.GetSignatureExpected(), Messages.Listed);

        }

        public IDataResult<List<Application>> GetUpdateExpected()
        {
            return new SuccessDataResult<List<Application>>(_applicationDal.GetUpdateExpected(), Messages.Listed);

        }

        public IResult Update(Application application)
        {
            _applicationDal.Update(application);
            return new SuccessResult(Messages.Updated);
        }
    }
}
