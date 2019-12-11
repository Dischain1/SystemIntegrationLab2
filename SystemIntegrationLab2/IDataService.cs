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

        // create
        [OperationContract]
        Respond CreateDeposit(string name, string type, string openDate);
        [OperationContract]
        Respond CreateWell(Guid depositId, string number, string type, int depth, string drillingDate);
        [OperationContract]
        Respond CreateExtraction(Guid wellId, string date, int value);

        // read
        [OperationContract]
        RespondAndDataList<DepositDto> ReadDeposits();
        [OperationContract]
        RespondAndDataList<WellDto> ReadWells(Guid depositId);
        [OperationContract]
        RespondAndDataList<ExtractionDto> ReadExtractions(Guid wellId, string dateFrom, string dateTo);
        
        // update
        [OperationContract]
        Respond UpdateDeposit(Guid depositId, string name);
        [OperationContract]
        Respond UpdateWell(Guid wellId, string number);
        [OperationContract]
        Respond UpdateExtraction(Guid extractionId, string date, int value);

        // delete
        [OperationContract]
        Respond DeleteDeposit(Guid depositId);
        [OperationContract]
        Respond DeleteWell(Guid wellId);
        [OperationContract]
        Respond DeleteExtraction(Guid extractionId);
    }
}
