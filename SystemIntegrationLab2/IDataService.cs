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
        Responce CreateDeposit(string name, string type, string openDate);
        [OperationContract]
        Responce CreateWell(Guid depositId, string number, string type, int depth, string drillingDate);
        [OperationContract]
        Responce CreateExtraction(Guid wellId, string date, double value);

        // read
        [OperationContract]
        ResponceAndDataList<DepositDto> ReadDeposits();
        [OperationContract]
        ResponceAndDataList<WellDto> ReadWells(Guid depositId);
        [OperationContract]
        ResponceAndDataList<ExtractionDto> ReadExtractions(Guid wellId, string dateFrom, string dateTo);
        
        // update
        [OperationContract]
        Responce UpdateDeposit(Guid depositId, string name);
        [OperationContract]
        Responce UpdateWell(Guid wellId, string number);
        [OperationContract]
        Responce UpdateExtraction(Guid extractionId, string date, double value);

        // delete
        [OperationContract]
        Responce DeleteDeposit(Guid depositId);
        [OperationContract]
        Responce DeleteWell(Guid wellId);
        [OperationContract]
        Responce DeleteExtraction(Guid extractionId);
    }
}
