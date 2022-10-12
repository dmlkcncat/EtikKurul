using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ApplicantUserManager : IApplicantUserService
    {
        IApplicantUserDal _applicantUserDal;

        public ApplicantUserManager(IApplicantUserDal applicantUserDal)
        {
            _applicantUserDal = applicantUserDal;
        }
        public IResult Add(ApplicantUser applicantUser)
        {
            _applicantUserDal.Add(applicantUser);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ApplicantUser applicantUser)
        {
            _applicantUserDal.Delete(applicantUser);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<ApplicantUser> Get(Expression<Func<ApplicantUser, bool>> filter)
        {
            return new SuccessDataResult<ApplicantUser>(_applicantUserDal.Get(filter), Messages.Listed);

        }

        public IDataResult<List<ApplicantUser>> GetAll()
        {
            return new SuccessDataResult<List<ApplicantUser>>(_applicantUserDal.GetAll(), Messages.Listed);

        }

        public IResult Update(ApplicantUser applicantUser)
        {
            _applicantUserDal.Update(applicantUser);
            return new SuccessResult(Messages.Updated);
        }
    }
}
