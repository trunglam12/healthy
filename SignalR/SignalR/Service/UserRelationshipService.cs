using SignalR.Entity;
using SignalR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Service
{
    public class UserRelationshipService : IUserRelationshipService
    {
        private readonly IUserRelationshipRepository _userRelationshipRepository;
        public UserRelationshipService(IUserRelationshipRepository userRelationshipRepository)
        {
            _userRelationshipRepository = userRelationshipRepository;
        }

      public  List<UserRelationship> MapToListNonEntity(List<UserRelationship> listSource)
        {
            var listResult = new List<UserRelationship>();

            foreach(var relationship in listSource)
            {
                listResult.Add(new UserRelationship { Address = relationship.Address,
                                                      FullName = relationship.FullName,
                                                        ID = relationship.ID,
                                                        Phone = relationship.Phone,
                                                        UserID = relationship.UserID});
            }

            return listResult;
         }

        public List<UserRelationship> GetForUsername(string userName)
        {
            return _userRelationshipRepository.GetForUsername(userName);
        }
    }
}