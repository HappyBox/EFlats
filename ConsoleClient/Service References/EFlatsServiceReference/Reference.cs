﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleClient.EFlatsServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EFlatsServiceReference.IWcfEFlatsService")]
    public interface IWcfEFlatsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/AddStudent", ReplyAction="http://tempuri.org/IWcfEFlatsService/AddStudentResponse")]
        bool AddStudent(
                    string email, 
                    string password, 
                    bool confirmed, 
                    bool student, 
                    int score, 
                    int numberOfChildren, 
                    bool pet, 
                    int numberOfCohabiters, 
                    bool disabled, 
                    System.DateTime dateOfCreation, 
                    string name, 
                    string surname, 
                    string address, 
                    string postCode, 
                    string city, 
                    string country, 
                    string phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/AddStudent", ReplyAction="http://tempuri.org/IWcfEFlatsService/AddStudentResponse")]
        System.Threading.Tasks.Task<bool> AddStudentAsync(
                    string email, 
                    string password, 
                    bool confirmed, 
                    bool student, 
                    int score, 
                    int numberOfChildren, 
                    bool pet, 
                    int numberOfCohabiters, 
                    bool disabled, 
                    System.DateTime dateOfCreation, 
                    string name, 
                    string surname, 
                    string address, 
                    string postCode, 
                    string city, 
                    string country, 
                    string phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/AddLandlord", ReplyAction="http://tempuri.org/IWcfEFlatsService/AddLandlordResponse")]
        bool AddLandlord(string email, string password, bool confirmed, System.DateTime dateOfCreation, string name, string surname, string address, string postCode, string city, string country, string phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/AddLandlord", ReplyAction="http://tempuri.org/IWcfEFlatsService/AddLandlordResponse")]
        System.Threading.Tasks.Task<bool> AddLandlordAsync(string email, string password, bool confirmed, System.DateTime dateOfCreation, string name, string surname, string address, string postCode, string city, string country, string phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/Login", ReplyAction="http://tempuri.org/IWcfEFlatsService/LoginResponse")]
        bool Login(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/Login", ReplyAction="http://tempuri.org/IWcfEFlatsService/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/AddApartment", ReplyAction="http://tempuri.org/IWcfEFlatsService/AddApartmentResponse")]
        bool AddApartment(string landlordEmail, string type, string address, string zipCode, double rentPrice, double deposit, System.DateTime avaiable, System.DateTime dateFormCreation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/AddApartment", ReplyAction="http://tempuri.org/IWcfEFlatsService/AddApartmentResponse")]
        System.Threading.Tasks.Task<bool> AddApartmentAsync(string landlordEmail, string type, string address, string zipCode, double rentPrice, double deposit, System.DateTime avaiable, System.DateTime dateFormCreation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/GetData", ReplyAction="http://tempuri.org/IWcfEFlatsService/GetDataResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetData(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfEFlatsService/GetData", ReplyAction="http://tempuri.org/IWcfEFlatsService/GetDataResponse")]
        System.Threading.Tasks.Task<object[]> GetDataAsync(string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfEFlatsServiceChannel : ConsoleClient.EFlatsServiceReference.IWcfEFlatsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfEFlatsServiceClient : System.ServiceModel.ClientBase<ConsoleClient.EFlatsServiceReference.IWcfEFlatsService>, ConsoleClient.EFlatsServiceReference.IWcfEFlatsService {
        
        public WcfEFlatsServiceClient() {
        }
        
        public WcfEFlatsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WcfEFlatsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfEFlatsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfEFlatsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddStudent(
                    string email, 
                    string password, 
                    bool confirmed, 
                    bool student, 
                    int score, 
                    int numberOfChildren, 
                    bool pet, 
                    int numberOfCohabiters, 
                    bool disabled, 
                    System.DateTime dateOfCreation, 
                    string name, 
                    string surname, 
                    string address, 
                    string postCode, 
                    string city, 
                    string country, 
                    string phone) {
            return base.Channel.AddStudent(email, password, confirmed, student, score, numberOfChildren, pet, numberOfCohabiters, disabled, dateOfCreation, name, surname, address, postCode, city, country, phone);
        }
        
        public System.Threading.Tasks.Task<bool> AddStudentAsync(
                    string email, 
                    string password, 
                    bool confirmed, 
                    bool student, 
                    int score, 
                    int numberOfChildren, 
                    bool pet, 
                    int numberOfCohabiters, 
                    bool disabled, 
                    System.DateTime dateOfCreation, 
                    string name, 
                    string surname, 
                    string address, 
                    string postCode, 
                    string city, 
                    string country, 
                    string phone) {
            return base.Channel.AddStudentAsync(email, password, confirmed, student, score, numberOfChildren, pet, numberOfCohabiters, disabled, dateOfCreation, name, surname, address, postCode, city, country, phone);
        }
        
        public bool AddLandlord(string email, string password, bool confirmed, System.DateTime dateOfCreation, string name, string surname, string address, string postCode, string city, string country, string phone) {
            return base.Channel.AddLandlord(email, password, confirmed, dateOfCreation, name, surname, address, postCode, city, country, phone);
        }
        
        public System.Threading.Tasks.Task<bool> AddLandlordAsync(string email, string password, bool confirmed, System.DateTime dateOfCreation, string name, string surname, string address, string postCode, string city, string country, string phone) {
            return base.Channel.AddLandlordAsync(email, password, confirmed, dateOfCreation, name, surname, address, postCode, city, country, phone);
        }
        
        public bool Login(string email, string password) {
            return base.Channel.Login(email, password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string email, string password) {
            return base.Channel.LoginAsync(email, password);
        }
        
        public bool AddApartment(string landlordEmail, string type, string address, string zipCode, double rentPrice, double deposit, System.DateTime avaiable, System.DateTime dateFormCreation) {
            return base.Channel.AddApartment(landlordEmail, type, address, zipCode, rentPrice, deposit, avaiable, dateFormCreation);
        }
        
        public System.Threading.Tasks.Task<bool> AddApartmentAsync(string landlordEmail, string type, string address, string zipCode, double rentPrice, double deposit, System.DateTime avaiable, System.DateTime dateFormCreation) {
            return base.Channel.AddApartmentAsync(landlordEmail, type, address, zipCode, rentPrice, deposit, avaiable, dateFormCreation);
        }
        
        public object[] GetData(string email) {
            return base.Channel.GetData(email);
        }
        
        public System.Threading.Tasks.Task<object[]> GetDataAsync(string email) {
            return base.Channel.GetDataAsync(email);
        }
    }
}
