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
    public class ApplicationFormManager : IApplicationFormService
    {
        IApplicationFormDal _applicationFormDal;

        public ApplicationFormManager(IApplicationFormDal applicationFormDal)
        {
            _applicationFormDal = applicationFormDal;
        }
        public IResult Add(ApplicationForm applicationForm)
        {
            _applicationFormDal.Add(applicationForm);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ApplicationForm applicationForm)
        {
            _applicationFormDal.Delete(applicationForm);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<ApplicationForm>> GetAll()
        {
            return new SuccessDataResult<List<ApplicationForm>>(_applicationFormDal.GetAll(), Messages.Listed);

        }

        public IResult Update(ApplicationForm applicationForm)
        {
            _applicationFormDal.Update(applicationForm);
            return new SuccessResult(Messages.Updated);
        }
    }
}
