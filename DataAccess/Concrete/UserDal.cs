using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User, EtikContext>, IUserDal
    {
        public void Active(User user)
        {
            using (EtikContext context = new EtikContext())
            {

                if (user.Active == true)
                {
                    user.Active = false;
                }
                else user.Active = true;
                var updatedEntity = context.Entry(user);
                Console.WriteLine(user.Password);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public User GetById(int id)
        {
            using (EtikContext context = new EtikContext())
            {
                var query = context.User.Where(item => item.Id == id).Include(question => question.Role);
                return query.SingleOrDefault();
            }
        }

        //Sekreterya listesi
        public List<User> GetDetail()
        {
            using (EtikContext context = new EtikContext())
            {
                return context.Set<User>().Where(item => item.RoleId == 3).ToList();
            }
        }

        //Kurul Üyeleri listesi
        public List<User> GetMember()
        {
            using (EtikContext context = new EtikContext())
            {
                return context.Set<User>().Where(item => item.RoleId == 2).ToList();
            }
        }

        public void StateActive(User user)
        {
            using (EtikContext context = new EtikContext())
            {

                if (user.StateActive == true)
                {
                    user.StateActive = false;
                }
                else user.StateActive = true;
                var updatedEntity = context.Entry(user);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdatePassword(User user, string email, string password)
        {
            using (EtikContext context = new EtikContext())
            {
             
                if(email == user.Eposta)
                {
                    user.Password = password;
                }
                var updatedEntity = context.Entry(user);
                Console.WriteLine(user.Password);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
