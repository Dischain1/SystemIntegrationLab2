using Model;
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
            DateTime _dateFrom;
            DateTime _dateTo;

            DateTime.TryParse(dateFrom, out _dateFrom);
            DateTime.TryParse(dateTo, out _dateTo);

            DataServiceClient client = new DataServiceClient();
            var model = client.ReadExtractions(wellId, _dateFrom.ToString(StringHelper.dateFormat), _dateTo.ToString(StringHelper.dateFormat));
            client.Close();

            return View(model);
        }
    }
}