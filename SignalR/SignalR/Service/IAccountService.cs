using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Service
{
    public interface IAccountService
    {
       bool  VerifyAccount(string username, string password);
        bool ChangePassword(string userName, string oldPassword, string confirmPassword);
    }
}