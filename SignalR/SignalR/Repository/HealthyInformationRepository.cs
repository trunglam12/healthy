
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
      
            return _healthyEntities.HealthyInformation.ToList();
        }

        public bool Insert(HealthyInformation healthyInformation)
        {
            if (healthyInformation != null)
                healthyInformation.CreateDate = DateTime.Now;

                var newInformation = _healthyEntities.HealthyInformation.Add(healthyInformation);
            _healthyEntities.SaveChanges();

            return newInformation != null ? true : false;
        }
    }
}