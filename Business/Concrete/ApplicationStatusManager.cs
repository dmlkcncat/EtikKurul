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
    public class ApplicationStatusManager : IApplicationStatusService
    {
        IApplicationStatusDal _applicationStatusDal;

        public ApplicationStatusManager(IApplicationStatusDal applicationStatusDal)
        {
            _applicationStatusDal = applicationStatusDal;
        }
        public IResult Add(ApplicationStatus applicationStatus)
        {
            _applicationStatusDal.Add(applicationStatus);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ApplicationStatus applicationStatus)
        {
            _applicationStatusDal.Delete(applicationStatus);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<ApplicationStatus>> GetAll()
        {
            return new SuccessDataResult<List<ApplicationStatus>>(_applicationStatusDal.GetAll(), Messages.Listed);
        }

        public IDataResult<ApplicationStatus> GetById(int Id)
        {
            return new SuccessDataResult<ApplicationStatus>(_applicationStatusDal.GetById(Id), Messages.Listed);

        }

        public IResult Update(ApplicationStatus applicationStatus)
        {
            _applicationStatusDal.Update(applicationStatus);
            return new SuccessResult(Messages.Updated);
        }
    }
}
