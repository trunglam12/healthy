
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Entity;

namespace SignalR.Repository
{
    public class HealthyInformationRepository : IHealthyInformationRepository
    {
        HealthyEntities _healthyEntities;
        public HealthyInformationRepository(HealthyEntities healthyEntities)
        {
            _healthyEntities = healthyEntities;
        }
        public List<HealthyInformation> GetAllHealthyInformation()
        {
            return MapToListHealthy(_healthyEntities.HealthyInformation.ToList());
        }
        public List<HealthyInformation> GetHealthyInformationByUsername(string userName)
        {
            var listDataResult = _healthyEntities.HealthyInformation.Where(c => c.User.UserName.Equals(userName)).ToList();

            return MapToListHealthy(listDataResult);
        }

        public bool Insert(HealthyInformation healthyInformation)
        {
            if (healthyInformation != null)
                healthyInformation.CreateDate = DateTime.Now;

                var newInformation = _healthyEntities.HealthyInformation.Add(healthyInformation);
            _healthyEntities.SaveChanges();

            return newInformation != null ? true : false;
        }

        public List<HealthyInformation> FilterData(DateTime fromDate,DateTime toDate,string userName)
        {
            var listAllData = MapToListHealthy(GetHealthyInformationByUsername(userName));
            return listAllData.Where(c=>c.CreateDate >= fromDate && c.CreateDate<=toDate).ToList();
         
        }

        public List<HealthyInformation> MapToListHealthy(List<HealthyInformation> listSource)
        {
            var listDestination = new List<HealthyInformation>();
         
            for (int i = 0; i < listSource.Count; i++)
            {
                listDestination.Add(new HealthyInformation
                {
                    CreateDate = listSource[i].CreateDate,
                    HeartBeat = listSource[i].HeartBeat,
                    ID = listSource[i].ID,
                    Oxy = listSource[i].Oxy,
                    UserID = listSource[i].UserID
                });
            }

            return listDestination;

        }
    }
}