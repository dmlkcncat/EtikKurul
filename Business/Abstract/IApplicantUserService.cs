using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicantUserService
    {
        IDataResult<List<ApplicantUser>> GetAll();
        IResult Add(ApplicantUser applicantUser);
        IResult Delete(ApplicantUser applicantUser);
        IResult Update(ApplicantUser applicantUser);
        IDataResult<ApplicantUser> Get(Expression<Func<ApplicantUser, bool>> filter);
    }
}
