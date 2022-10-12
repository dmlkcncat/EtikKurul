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
    public class UpdateApplicationManager : IUpdateApplicationService
    {
        IUpdateApplicationDal _updateApplicationDal;

        public UpdateApplicationManager(IUpdateApplicationDal updateApplicationDal)
        {
            _updateApplicationDal = updateApplicationDal;
        }
        public IResult Add(UpdateApplication updateApplication)
        {
            _updateApplicationDal.Add(updateApplication);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(UpdateApplication updateApplication)
        {
            _updateApplicationDal.Delete(updateApplication);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<UpdateApplication>> GetAll()
        {
            return new SuccessDataResult<List<UpdateApplication>>(_updateApplicationDal.GetAll(), Messages.Listed);

        }

        public IDataResult<UpdateApplication> GetById(int Id)
        {
            return new SuccessDataResult<UpdateApplication>(_updateApplicationDal.GetById(Id), Messages.Listed);

        }

        public IResult Update(UpdateApplication updateApplication)
        {
            _updateApplicationDal.Update(updateApplication);
            return new SuccessResult(Messages.Updated);
        }
    }
}
