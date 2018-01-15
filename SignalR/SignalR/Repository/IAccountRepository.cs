using SignalR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Repository
{
    public interface IAccountRepository
    {
        User GetUser(int id);
        List<User> GetAllUser();
        bool Insert(User user);
    }
}