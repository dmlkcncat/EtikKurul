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
    public class UserManager : IUserService
    {

        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Active(User user)
        {
            _userDal.Active(user);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter), Messages.Listed);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.GetById(Id), Messages.Listed);

        }

        public IDataResult<List<User>> GetDetail()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetDetail(), Messages.Listed);
        }

        public IDataResult<List<User>> GetMember()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetMember(), Messages.Listed);
        }

        public IResult UpdatePassword(User user, string email, string password2)
        {
            _userDal.UpdatePassword(user, email, password2);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        public IResult StateActive(User user)
        {
            _userDal.StateActive(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
