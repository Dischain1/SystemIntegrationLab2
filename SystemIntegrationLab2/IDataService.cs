using Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SystemIntegrationLab2
{
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        string Test();

        [OperationContract]
        List<DepositDto> GetDeposits();

        [OperationContract]
        RespondAndDataList<DepositDto> ReadDeposits();
        [OperationContract]
        RespondAndDataList<WellDto> ReadWells(Guid depositId);
        [OperationContract]
        RespondAndDataList<ExtractionDto> ReadExtractions(Guid wellId, string dateFrom, string dateTo);
    }
}
