using Microsoft.AspNetCore.Identity;
using SignalR.Entity;
using SignalR.Helper;
using SignalR.Models;
using SignalR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Service
{
    public class AccountService : IAccountService
    {
        IPasswordHasher<User> _passwordHasher;
        IAccountRepository _accountRepository;
        public AccountService()
        {
            
        }
        public AccountService(IPasswordHasher<User> passwordHasher,IAccountRepository accountRepository)
        {
            _passwordHasher = passwordHasher;
            _accountRepository = accountRepository;
        }
        public bool VerifyAccount(string userName, string password)
        {
            var oldAccount = _accountRepository.GetAllUser().Where(c => c.UserName.ToLower() == userName.ToLower() || c.Email.ToLower() == userName.ToLower()).FirstOrDefault();
            if (oldAccount != null)
            {
                return _passwordHasher.VerifyHashedPassword(oldAccount,oldAccount.Password, password) == PasswordVerificationResult.Success;
            }

            return false;
          
        }

        public bool ChangePassword(string userName, string oldPassword,string confirmPassword)
        {
            var oldAccount = _accountRepository.GetAllUser().Where(c => c.UserName.ToLower() == userName.ToLower() || c.Email.ToLower() == userName.ToLower()).FirstOrDefault();
            if (oldAccount != null)
            {
                var comparePassword=  _passwordHasher.VerifyHashedPassword(oldAccount, oldAccount.Password, oldPassword) == PasswordVerificationResult.Success;
                if(comparePassword)
                {
                    oldAccount.Password = _passwordHasher.HashPassword(oldAccount, confirmPassword);
                    _accountRepository.Update(oldAccount, userName);
                    return true;
                }
            }

            return false;

        }

        public void Insert(User user)
        {
            var currentPassword = user.Password;
            user.Password = _passwordHasher.HashPassword(user, currentPassword);

            _accountRepository.Insert(user);
        }
        public User GetUserByUserName(string userName)
        {
            return _accountRepository.GetAllUser().Where(c => c.UserName.ToLower() == userName.ToLower() || c.Email.ToLower() == userName.ToLower()).FirstOrDefault();
        }

       public User MapFromRegisterViewModelToUser(RegisterViewModel model)
        {
            var newUser = new User { Address = model.Address,
                Email = model.Email, FullName = model.FullName,
                Mobile = model.Mobile, Password = model.Password,
                UserName = model.UserName };

            return newUser;
        }
        public void SendSMS(int userID)
        {
            var account = _accountRepository.GetForID(userID);
            foreach (var relationship in account.UserRelationship)
            {
                var phone = relationship.Phone;
                if (phone.Length > 0 && phone[0] == '0')
                {
                    phone = phone.Remove(0, 1);
                    ExtentionMethod.SendSMS(string.Format("{0}{1}", "+84", phone),
                        String.Format("{0} has {1} heart beat. Please call emergency!", account.FullName, "150"));
                }

            }
            //ExtentionMethod.SendSMS("+84965198634", "testsms");
          
        }

    }
}