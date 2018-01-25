using Microsoft.AspNetCore.Identity;
using SignalR.Entity;
using SignalR.Models;
using SignalR.Repository;
using SignalR.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SignalR.Areas.api.Controllers
{
    public class AccountController : ApiController
    {

        private readonly IAccountService _accountService;
        private readonly IAccountRepository _accountRepository;
        private readonly HealthyEntities _healthyEntities;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountController()
        {
            _healthyEntities = new HealthyEntities();
            _passwordHasher = new PasswordHasher<User>();

            _accountRepository = new AccountRepository(_healthyEntities);
            _accountService = new AccountService(_passwordHasher, _accountRepository);
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public bool PostValidateUser([FromBody]RegisterViewModel value)
        {

            bool result = _accountService.VerifyAccount(value.LoginViewModel.UserName, value.LoginViewModel.Password);
            if (result)
            {
                return true;

            }
           
            return false;
        }
        [HttpPost]
        public bool PostEdit([FromBody]User model)
        {
            try
            {
                _accountRepository.Update(model, model?.UserName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}