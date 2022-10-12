using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFormService
    {
        IDataResult<List<Form>> GetAll();
        IResult Add(Form petitionForm);
        IResult Delete(Form petitionForm);
        IResult Update(Form petitionForm);
    }
}
