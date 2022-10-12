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
    public class ApplicationQualificationManager : IApplicationQualificationService
    {
        IApplicationQualificationDal _applicationQualificationDal;

        public ApplicationQualificationManager(IApplicationQualificationDal applicationQualificationDal)
        {
            _applicationQualificationDal = applicationQualificationDal;
        }

        public IResult Add(ApplicationQualification applicationQualification)
        {
            _applicationQualificationDal.Add(applicationQualification);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ApplicationQualification applicationQualification)
        {
            _applicationQualificationDal.Delete(applicationQualification);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<ApplicationQualification>> GetAll()
        {
            return new SuccessDataResult<List<ApplicationQualification>>(_applicationQualificationDal.GetAll(), Messages.Listed);
        }

        public IDataResult<ApplicationQualification> GetById(int Id)
        {
            return new SuccessDataResult<ApplicationQualification>(_applicationQualificationDal.GetById(Id), Messages.Listed);

        }

        public IResult Update(ApplicationQualification applicationQualification)
        {
            _applicationQualificationDal.Update(applicationQualification);
            return new SuccessResult(Messages.Updated);
        }
    }
}
