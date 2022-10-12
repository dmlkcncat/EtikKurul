using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IResult Active(User user);
        IResult StateActive(User user);
        IResult UpdatePassword(User user, string email, string password2);
        IDataResult<User> GetById(int Id);
        IDataResult<List<User>> GetDetail();
        IDataResult<List<User>> GetMember();
        IDataResult<User> Get(Expression<Func<User, bool>> filter);
    }
}
