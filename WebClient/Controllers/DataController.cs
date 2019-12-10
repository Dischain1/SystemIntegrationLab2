using System;
using System.Web.Mvc;
using WebClient.DataService;

namespace WebClient.Controllers
{
    public class DataController : Controller
    {
        public ActionResult Deposits()
        {
            DataServiceClient client = new DataServiceClient();
            var model = client.ReadDeposits();
            client.Close();

            return View(model);
        }

        public ActionResult Wells(Guid depositId)
        {
            DataServiceClient client = new DataServiceClient();
            var model = client.ReadWells(depositId);
            client.Close();

            return View(model);
        }

        public ActionResult Extractions(Guid wellId, string dateFrom, string dateTo)
        {
            DataServiceClient client = new DataServiceClient();
            var model = client.ReadExtractions(wellId, dateFrom, dateTo);
            client.Close();

            return View(model);
        }
    }
}