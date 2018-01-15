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
            var listHealthyInformationTemp = new List<HealthyInformation>();
        
            var listResult = _healthyInformationRepository.GetAllHealthyInformation();
            for(int i=0;i< listResult.Count;i++)
            {
                listHealthyInformationTemp.Add(new HealthyInformation
                {
                    CreateDate = listResult[i].CreateDate,
                    HeartBeat = listResult[i].HeartBeat,
                    ID = listResult[i].ID,
                    Oxy = listResult[i].Oxy,
                    UserID = listResult[i].UserID
                });
            }

            //listHealthyInformationTemp.AddRange(listResult);

            return listHealthyInformationTemp;
        }
    }
}