using SignalR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Service
{
    public interface IUserRelationshipService
    {
        List<UserRelationship> MapToListNonEntity(List<UserRelationship> listSource);
        List<UserRelationship> GetForUsername(string userName);
    }
}