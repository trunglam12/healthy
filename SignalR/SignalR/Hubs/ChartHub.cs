using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalR.Entity;
using SignalR.Repository;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.Hubs
{
    [HubName("HealthyCare")]
    public class ChartHub : Hub
    {
        protected readonly HealthyEntities _healthyEntities;
        protected readonly IHealthyInformationRepository _healthyInformationRepository;
        public ChartHub()
        {
            _healthyEntities = new HealthyEntities();
            _healthyInformationRepository = new HealthyInformationRepository(_healthyEntities);
        }
        public void Hello()
        {
            Clients.All.hello();
        }

        public List<HealthyInformation> GetAllInformation()
        {
            var listResult = _healthyInformationRepository.GetAllHealthyInformation();

            return _healthyInformationRepository.MapToListHealthy(listResult);
        }
    }
}