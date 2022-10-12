using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationQualificationService
    {
        IDataResult<List<ApplicationQualification>> GetAll();
        IResult Add(ApplicationQualification applicationQualification);
        IResult Delete(ApplicationQualification applicationQualification);
        IResult Update(ApplicationQualification applicationQualification);
        IDataResult<ApplicationQualification> GetById(int Id);
    }
}
