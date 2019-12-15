using Model;
using System;
using System.Web.Mvc;
using WebClient.DataService;
using WebClient.Models;

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

        public ActionResult Wells(Guid depositId, string depositName)
        {
            DataServiceClient client = new DataServiceClient();
            var wellsResponce = client.ReadWells(depositId);
            client.Close();

            var model = new WellsViewModel
            {
                DepositId = depositId,
                DepositName = depositName,
                WellsResponce = wellsResponce
            };

            return View(model);
        }

        public ActionResult Extractions(Guid wellId, string wellNumber, string dateFrom, string dateTo)
        {
            DateTime _dateFrom;
            DateTime _dateTo;

            DateTime.TryParse(dateFrom, out _dateFrom);
            DateTime.TryParse(dateTo, out _dateTo);

            DataServiceClient client = new DataServiceClient();
            var extractionsResponce = client.ReadExtractions(wellId, _dateFrom.ToString(StringHelper.dateFormat), _dateTo.ToString(StringHelper.dateFormat));
            client.Close();

            var model = new ExtractionsViewModel
            {
                WellId = wellId,
                WellNumber = wellNumber,
                DateFrom = _dateFrom.ToString("dd/MM/yyyy"),
                DateTo = _dateTo.ToString("dd/MM/yyyy"),
                ExtractionResponce = extractionsResponce
            };

            return View(model);
        }
    }
}