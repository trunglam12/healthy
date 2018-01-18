using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Entity;

namespace SignalR.Repository
{
    public class UserRelationshipRepository : IUserRelationshipRepository
    {
        private readonly HealthyEntities _healthyEntities;
        public UserRelationshipRepository(HealthyEntities healthyEntities)
        {
            _healthyEntities = healthyEntities;
        }
        public List<UserRelationship> GetForUsername(string userName)
        {
            var listResult = _healthyEntities.UserRelationship.Where(c => c.User.UserName.Equals(userName)).ToList();

            return listResult;
        }
        public UserRelationship GetForID(int id)
        {
            var result = _healthyEntities.UserRelationship.Where(c => c.ID.Equals(id)).FirstOrDefault();

            return result;
        }
        public void Update(UserRelationship userRelationship)
        {
            var currentUserRelationShip = GetForID(userRelationship.ID);

            if(currentUserRelationShip!=null)
            {
                _healthyEntities.Entry(currentUserRelationShip).CurrentValues.SetValues(userRelationship);
                _healthyEntities.SaveChanges();
            }
        }
    }
}