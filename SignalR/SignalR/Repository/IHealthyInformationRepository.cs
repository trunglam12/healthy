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
        List<HealthyInformation> FilterData(DateTime fromDate, DateTime toDate);
        List<HealthyInformation> MapToListHealthy(List<HealthyInformation> listSource);
    }
}