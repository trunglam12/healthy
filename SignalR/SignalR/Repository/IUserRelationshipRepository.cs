using SignalR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Repository
{
    public interface IUserRelationshipRepository
    {
        List<UserRelationship> GetForUsername(String userName);
        UserRelationship GetForID(int id);
        void Update(UserRelationship userRelationship);

      
    }
}