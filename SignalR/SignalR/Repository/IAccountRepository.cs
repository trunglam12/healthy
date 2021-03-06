﻿using SignalR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Repository
{
    public interface IAccountRepository
    {
        User GetForID(int id);
        User GetForUserName(string userName);
        List<User> GetAllUser();
        bool Insert(User user);
        void Update(User user, string userName);
    }
}