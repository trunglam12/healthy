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
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAccountRepository _accountRepository;
        private readonly HealthyEntities _healthyEntities;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginController()
        {
            _healthyEntities = new HealthyEntities();
            _passwordHasher = new PasswordHasher<User>();

            _accountRepository = new AccountRepository(_healthyEntities);
            _accountService = new AccountService(_passwordHasher, _accountRepository);
        }
        // GET: Account
        public ActionResult Index()
        {

            if (Session["UserName"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Login(RegisterViewModel model)
        {


            bool result = _accountService.VerifyAccount(model.LoginViewModel.UserName, model.LoginViewModel.Password);
            if (result)
            {
                Session["UserName"] = model.LoginViewModel.UserName;

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Invalid password or username");
            }

            return View("Index");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var convertToUserModel = _accountService.MapFromRegisterViewModelToUser(model);

            try
            {
                _accountService.Insert(convertToUserModel);

                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RegisterError", string.Format("Cannot register new account because {0}", ex.Message));
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }
        public JsonResult IsUserNameExist(string UserName)
        {
            var account = _accountRepository.GetForUserName(UserName);
            if (account == null)
                return Json(true, JsonRequestBehavior.AllowGet);

            return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}