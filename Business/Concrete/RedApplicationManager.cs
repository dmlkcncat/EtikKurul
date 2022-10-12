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
    public class RedApplicationManager : IRedApplicationService
    {
        IRedApplicationDal _redApplicationDal;

        public RedApplicationManager(IRedApplicationDal redApplicationDal)
        {
            _redApplicationDal = redApplicationDal;
        }
        public IResult Add(RedApplication redApplication)
        {
            _redApplicationDal.Add(redApplication);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(RedApplication redApplication)
        {
            _redApplicationDal.Delete(redApplication);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<RedApplication>> GetAll()
        {
            return new SuccessDataResult<List<RedApplication>>(_redApplicationDal.GetAll(), Messages.Listed);

        }

        public IDataResult<RedApplication> GetById(int Id)
        {
            return new SuccessDataResult<RedApplication>(_redApplicationDal.GetById(Id), Messages.Listed);

        }

        public IResult Update(RedApplication redApplication)
        {
            _redApplicationDal.Update(redApplication);
            return new SuccessResult(Messages.Updated);
        }
    }
}
