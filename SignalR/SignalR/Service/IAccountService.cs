using SignalR.Entity;
using SignalR.Models;
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
        User GetUserByUserName(string userName);
        void Insert(User user);
         void SendSMS(int userID);
        User MapFromRegisterViewModelToUser(RegisterViewModel model);
    }
}