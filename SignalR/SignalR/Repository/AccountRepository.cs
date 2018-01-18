using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Entity;

namespace SignalR.Repository
{
    public class AccountRepository : IAccountRepository
    {
        HealthyEntities _healthyEntities;

        public AccountRepository()
        {

        }
        public AccountRepository(HealthyEntities healthyEntities)
        {
            _healthyEntities = healthyEntities;
        }

        public List<User> GetAllUser()
        {
            return _healthyEntities.User.ToList();
        }

        public User GetForID(int id)
        {
            return _healthyEntities.User.Where(c=>c.ID.Equals(id)).FirstOrDefault();
        }

        public bool Insert(User user)
        {
            var newUser = _healthyEntities.User.Add(user);
            _healthyEntities.SaveChanges();

            return newUser != null ? true : false;

        }
        public void Update(User user,string userName)
        {
            var currentUser = _healthyEntities.User.FirstOrDefault(c => c.UserName.Equals(userName));
            if(currentUser != null)
            {
                _healthyEntities.Entry(currentUser).CurrentValues.SetValues(user);
                _healthyEntities.SaveChanges();
            }

        }

       public User GetForUserName(string userName)
        {
            var currentUser = _healthyEntities.User.FirstOrDefault(c => c.UserName.Equals(userName));

            return currentUser;
        }
    }
}