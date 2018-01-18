using SignalR.Entity;
using SignalR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Controllers
{
    public class UserRelationshipController : Controller
    {
        private readonly HealthyEntities _healthyEntities;
        private readonly IUserRelationshipRepository _userRelationshipRepository;
         public UserRelationshipController()
        {
            _healthyEntities = new HealthyEntities();
            _userRelationshipRepository = new UserRelationshipRepository(_healthyEntities);
        }
        // GET: UserRelationship
        public ActionResult Edit(int? id)
        {
           var userRelationship =  _userRelationshipRepository.GetForID(id??0);
            return View(userRelationship);
        }

        [HttpPost]
        public ActionResult Edit(UserRelationship model)
        {
            try
            {
                _userRelationshipRepository.Update(model);
                return RedirectToAction("UserProfile", "Account");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("error", String.Format("Cannot Edit User Realtionship Because {0}", ex.Message));
            }
           
            return View();

        }
    }
}