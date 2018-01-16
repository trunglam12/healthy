using Microsoft.AspNetCore.Identity;
using SignalR.Entity;
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
    public class AccountController : Controller
    {
        IAccountService _accountService;
        IAccountRepository _accountRepository;
        HealthyEntities _healthyEntities ;
        IPasswordHasher<User> _passwordHasher ;
        public AccountController()
        {
            _healthyEntities = new HealthyEntities();
            _passwordHasher = new PasswordHasher<User>();

            _accountRepository = new AccountRepository(_healthyEntities);
            _accountService = new AccountService(_passwordHasher, _accountRepository);
        }
        // GET: Account
        public ActionResult Index()
        {
            //var user = new User { UserName = "admin", Password = "123456" };
            //user.Password = _passwordHasher.HashPassword(user, "123456");

            //_accountRepository.Insert(user);
            //return to home already login
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Login(LoginViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                bool result = _accountService.VerifyAccount(model.UserName, model.Password);
                if (result)
                {
                    Session["UserName"] = model.UserName;

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Invalid password or username");
                }
            }

            ModelState.AddModelError("", "Invalid password or username");

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Account");
          
        }
    }
}