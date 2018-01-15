using SignalR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Repository
{
    public interface IHealthyInformationRepository
    {
        List<HealthyInformation> GetAllHealthyInformation();
        bool Insert(HealthyInformation healthyInformation);

    }
}