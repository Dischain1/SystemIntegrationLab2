using Model;
using System;

namespace WebClient.Models
{
    public class WellsViewModel
    {
        public ResponceAndDataList<WellDto> WellsResponce { get; set; }
        public Guid DepositId { get; set; }
        public string DepositName { get; set; }
    }

    public class ExtractionsViewModel
    {
        public ResponceAndDataList<ExtractionDto> ExtractionResponce { get; set; }
        public Guid WellId { get; set; }
        public string WellNumber { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}