using Microsoft.AspNet.SignalR;
using SignalR.Entity;
using SignalR.Hubs;
using SignalR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Controllers
{
    public class HealthyInformationController : Controller
    {
        protected readonly HealthyEntities _healthyEntities;

        protected readonly IHealthyInformationRepository _healthyInformationRepository;

        public HealthyInformationController()
        {
            _healthyEntities = new HealthyEntities();
            _healthyInformationRepository = new HealthyInformationRepository(_healthyEntities);
        }

        // GET: HealthyInformation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(int? heartBeat, int? oxy, int? userID)
        {
            if (heartBeat == null || oxy == null || userID == null)
                return Json("Error", JsonRequestBehavior.AllowGet);

            var healthyInformation = new HealthyInformation { HeartBeat = heartBeat.Value, Oxy = oxy.Value, UserID = userID.Value };
            var resultInsert = _healthyInformationRepository.Insert(healthyInformation);

            if (resultInsert)
            {
                var listHealthyInformationTemp = new List<HealthyInformation>();

                var listResult = _healthyInformationRepository.GetAllHealthyInformation();
                for (int i = 0; i < listResult.Count; i++)
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

                UpdateHealthyCare(listHealthyInformationTemp);
               return Json("Success", JsonRequestBehavior.AllowGet);
            }
               

            return Json("Fail", JsonRequestBehavior.AllowGet);
        }

        private void UpdateHealthyCare(List<HealthyInformation> listInformation)
        {
            GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients.All.updateChart(listInformation);
        }



    }
}