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
    public class RoleManager : IRoleService
    {

        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public IResult Add(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Role role)
        {
            _roleDal.Delete(role);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Role>> GetAll()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Role> GetById(int Id)
        {
            return new SuccessDataResult<Role>(_roleDal.GetById(Id), Messages.Listed);

        }

        public IResult Update(Role role)
        {
            _roleDal.Update(role);
            return new SuccessResult(Messages.Updated);
        }
    }
}
