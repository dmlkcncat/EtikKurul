using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        User GetById(int id);
        public List<User> GetDetail();
        public List<User> GetMember();
        void UpdatePassword(User user, string email, string password);
        void Active(User user);
        void StateActive(User user);
    }
}
