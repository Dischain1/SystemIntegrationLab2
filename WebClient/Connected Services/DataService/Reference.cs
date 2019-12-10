﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClient.DataService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DataService.IDataService")]
    public interface IDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/Test", ReplyAction="http://tempuri.org/IDataService/TestResponse")]
        string Test();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/Test", ReplyAction="http://tempuri.org/IDataService/TestResponse")]
        System.Threading.Tasks.Task<string> TestAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetDeposits", ReplyAction="http://tempuri.org/IDataService/GetDepositsResponse")]
        System.Collections.Generic.List<Model.DepositDto> GetDeposits();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetDeposits", ReplyAction="http://tempuri.org/IDataService/GetDepositsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Model.DepositDto>> GetDepositsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/ReadDeposits", ReplyAction="http://tempuri.org/IDataService/ReadDepositsResponse")]
        Model.RespondAndDataList<Model.DepositDto> ReadDeposits();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/ReadDeposits", ReplyAction="http://tempuri.org/IDataService/ReadDepositsResponse")]
        System.Threading.Tasks.Task<Model.RespondAndDataList<Model.DepositDto>> ReadDepositsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/ReadWells", ReplyAction="http://tempuri.org/IDataService/ReadWellsResponse")]
        Model.RespondAndDataList<Model.WellDto> ReadWells(System.Guid depositId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/ReadWells", ReplyAction="http://tempuri.org/IDataService/ReadWellsResponse")]
        System.Threading.Tasks.Task<Model.RespondAndDataList<Model.WellDto>> ReadWellsAsync(System.Guid depositId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/ReadExtractions", ReplyAction="http://tempuri.org/IDataService/ReadExtractionsResponse")]
        Model.RespondAndDataList<Model.ExtractionDto> ReadExtractions(System.Guid wellId, string dateFrom, string dateTo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/ReadExtractions", ReplyAction="http://tempuri.org/IDataService/ReadExtractionsResponse")]
        System.Threading.Tasks.Task<Model.RespondAndDataList<Model.ExtractionDto>> ReadExtractionsAsync(System.Guid wellId, string dateFrom, string dateTo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataServiceChannel : WebClient.DataService.IDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataServiceClient : System.ServiceModel.ClientBase<WebClient.DataService.IDataService>, WebClient.DataService.IDataService {
        
        public DataServiceClient() {
        }
        
        public DataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Test() {
            return base.Channel.Test();
        }
        
        public System.Threading.Tasks.Task<string> TestAsync() {
            return base.Channel.TestAsync();
        }
        
        public System.Collections.Generic.List<Model.DepositDto> GetDeposits() {
            return base.Channel.GetDeposits();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Model.DepositDto>> GetDepositsAsync() {
            return base.Channel.GetDepositsAsync();
        }
        
        public Model.RespondAndDataList<Model.DepositDto> ReadDeposits() {
            return base.Channel.ReadDeposits();
        }
        
        public System.Threading.Tasks.Task<Model.RespondAndDataList<Model.DepositDto>> ReadDepositsAsync() {
            return base.Channel.ReadDepositsAsync();
        }
        
        public Model.RespondAndDataList<Model.WellDto> ReadWells(System.Guid depositId) {
            return base.Channel.ReadWells(depositId);
        }
        
        public System.Threading.Tasks.Task<Model.RespondAndDataList<Model.WellDto>> ReadWellsAsync(System.Guid depositId) {
            return base.Channel.ReadWellsAsync(depositId);
        }
        
        public Model.RespondAndDataList<Model.ExtractionDto> ReadExtractions(System.Guid wellId, string dateFrom, string dateTo) {
            return base.Channel.ReadExtractions(wellId, dateFrom, dateTo);
        }
        
        public System.Threading.Tasks.Task<Model.RespondAndDataList<Model.ExtractionDto>> ReadExtractionsAsync(System.Guid wellId, string dateFrom, string dateTo) {
            return base.Channel.ReadExtractionsAsync(wellId, dateFrom, dateTo);
        }
    }
}
