using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRedApplicationService 
    {
        IDataResult<List<RedApplication>> GetAll();
        IResult Add(RedApplication redApplication);
        IResult Delete(RedApplication redApplication);
        IResult Update(RedApplication redApplication);
        IDataResult<RedApplication> GetById(int Id);
    }
}
