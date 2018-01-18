using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SignalR.Entity;
using SignalR.Helper;
using SignalR.Hubs;
using SignalR.Repository;
using SignalR.Service;
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
        protected readonly IAccountService _accountService;
        protected readonly IAccountRepository _accountRepository;
        protected readonly IHealthyInformationRepository _healthyInformationRepository;
        protected readonly IPasswordHasher<User> _passwordHasher;

        public HealthyInformationController()
        {
            _healthyEntities = new HealthyEntities();
            _passwordHasher = new PasswordHasher<User>();

            _accountRepository = new AccountRepository(_healthyEntities);
            _accountService = new AccountService(_passwordHasher, _accountRepository);
       
        }

        // GET: HealthyInformation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(int? heartBeat, int? oxy, int? userID)
        {
            try
            {
                if (heartBeat == null || oxy == null || userID == null)
                    return Json("Error", JsonRequestBehavior.AllowGet);

                var healthyInformation = new HealthyInformation { HeartBeat = heartBeat.Value, Oxy = oxy.Value, UserID = userID.Value };
                var resultInsert = _healthyInformationRepository.Insert(healthyInformation);

                if (resultInsert)
                {
                    var listHealthyInformationTemp = new List<HealthyInformation>();

                    var listResult = _healthyInformationRepository.GetHealthyInformationByUsername(Session["UserName"]?.ToString());
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

                    if (heartBeat != null && (heartBeat > 110 || heartBeat < 40))
                    {
                        _accountService.SendSMS(userID ?? 0);
                    }

                    return Json("Success", JsonRequestBehavior.AllowGet);
                }

            }
            catch(Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }



            return Json("Fail", JsonRequestBehavior.AllowGet);
        }

        private void UpdateHealthyCare(List<HealthyInformation> listInformation)
        {
            GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients.All.updateChart(listInformation);
        }

        [HttpPost]
        public void FilterData(string fromDate, string toDate)
        {
            if (fromDate.Equals(String.Empty) && toDate.Equals(string.Empty))
            {
                var listAllData = _healthyInformationRepository.GetHealthyInformationByUsername(Session["UserName"]?.ToString());
                GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients.All.updateChart(listAllData);

            }
            else
             if (fromDate.Equals(String.Empty))
            {

                var dateTo = DateTime.Parse(toDate);
                var resultFilterDate = _healthyInformationRepository.FilterData(DateTime.Now, dateTo, Session["UserName"]?.ToString());
                GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients.All.updateChart(resultFilterDate);

            }
            else
              if (toDate.Equals(String.Empty))
            {

                var dateFrom = DateTime.Parse(fromDate);
                var resultFilterDate = _healthyInformationRepository.FilterData(dateFrom, DateTime.Now, Session["UserName"]?.ToString());
                GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients.All.updateChart(resultFilterDate);

            }
            else
            {
                var dateFrom = DateTime.Parse(fromDate);
                var dateTo = DateTime.Parse(toDate);
                var resultFilterDate = _healthyInformationRepository.FilterData(dateFrom, dateTo, Session["UserName"]?.ToString());
                GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients.All.updateChart(resultFilterDate);
            }


        }

    }
}