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
        List<HealthyInformation> GetHealthyInformationByUsername(string userName);
        bool Insert(HealthyInformation healthyInformation);
        List<HealthyInformation> FilterData(DateTime fromDate, DateTime toDate,string userName);
        List<HealthyInformation> MapToListHealthy(List<HealthyInformation> listSource);
    }
}