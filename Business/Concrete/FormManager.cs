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
    public class FormManager : IFormService
    {
        IFormDal _petitionFormDal;

        public FormManager(IFormDal petitionFormDal)
        {
            _petitionFormDal = petitionFormDal;
        }
        public IResult Add(Form petitionForm)
        {
            _petitionFormDal.Add(petitionForm);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Form petitionForm)
        {
            _petitionFormDal.Delete(petitionForm);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Form>> GetAll()
        {
            return new SuccessDataResult<List<Form>>(_petitionFormDal.GetAll(), Messages.Listed);

        }

        public IResult Update(Form petitionForm)
        {
            _petitionFormDal.Update(petitionForm);
            return new SuccessResult(Messages.Updated);
        }
    }
}
