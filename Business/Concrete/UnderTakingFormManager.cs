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
    public class UnderTakingFormManager : IUnderTakingFormService
    {
        IUnderTakingFormDal _underTakingFormDal;

        public UnderTakingFormManager(IUnderTakingFormDal underTakingFormDal)
        {
            _underTakingFormDal = underTakingFormDal;
        }
        public IResult Add(UnderTakingForm underTakingForm)
        {
            _underTakingFormDal.Add(underTakingForm);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(UnderTakingForm underTakingForm)
        {
            _underTakingFormDal.Delete(underTakingForm);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<UnderTakingForm>> GetAll()
        {
            return new SuccessDataResult<List<UnderTakingForm>>(_underTakingFormDal.GetAll(), Messages.Listed);

        }

        public IResult Update(UnderTakingForm underTakingForm)
        {
            _underTakingFormDal.Update(underTakingForm);
            return new SuccessResult(Messages.Updated);
        }
    }
}
