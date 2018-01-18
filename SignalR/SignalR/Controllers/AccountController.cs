using Microsoft.AspNetCore.Identity;
using SignalR.Entity;
using SignalR.Helper;
using SignalR.Models;
using SignalR.Repository;
using SignalR.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Controllers
{
    public class AccountController : BaseController
    {
        IAccountService _accountService;
        IAccountRepository _accountRepository;
        IUserRelationshipRepository _userRelationshipRepository;
        IUserRelationshipService _userRealtionshipService;
        HealthyEntities _healthyEntities ;
        IPasswordHasher<User> _passwordHasher ;
        public AccountController()
        {
            _healthyEntities = new HealthyEntities();
            _passwordHasher = new PasswordHasher<User>();

            _accountRepository = new AccountRepository(_healthyEntities);
            _accountService = new AccountService(_passwordHasher, _accountRepository);
            _userRelationshipRepository = new UserRelationshipRepository(_healthyEntities);

            _userRealtionshipService = new UserRelationshipService(_userRelationshipRepository); 
        }
      

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ResetPasswordViewModel model)
        {
            var resultChangePassword = _accountService.ChangePassword(Session["UserName"]?.ToString(), model.OldPassword, model.ConfirmPassword);
            if(resultChangePassword)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Error", "Cannot change password");
            return View();
        
        }

        public ActionResult UserProfile()
        {
            var resultUser = _accountService.GetUserByUserName(Session["UserName"]?.ToString());
            resultUser.UserRelationship = _userRealtionshipService.MapToListNonEntity(resultUser.UserRelationship.ToList());
            return View(resultUser);
        }

        public ActionResult Edit(int id)
        {
            var user = _accountRepository.GetForID(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            try
            {
                _accountRepository.Update(model,Session["UserName"]?.ToString());
                return RedirectToAction("UserProfile", "Account");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", String.Format("Cannot Edit User Because {0}", ex.Message));
            }

            return View();
        }

        public ActionResult SendSMS(int userID)
        {
            var account = _accountRepository.GetForID(userID);
            foreach(var relationship in account.UserRelationship)
            {
                var phone = relationship.Phone;
                if(phone.Length > 0 && phone[0]=='0')
                {
                    phone = phone.Remove(0,1);
                    ExtentionMethod.SendSMS(string.Format("{0}{1}","+84",phone),
                        String.Format("{0} has {1} heart beat. Please call emergency!",account.FullName,"150"));
                }
              
            }
            //ExtentionMethod.SendSMS("+84965198634", "testsms");
            return View("UserProfile");
        }

      

    }
}