using Microsoft.AspNetCore.Identity;
using SignalR.Entity;
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
    }
}