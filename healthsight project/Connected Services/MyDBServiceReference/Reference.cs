﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace healthsight_project.MyDBServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/MyDBService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Patient", Namespace="http://schemas.datacontract.org/2004/07/MyDBService.Entity")]
    [System.SerializableAttribute()]
    public partial class Patient : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddrField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DOBField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MedConField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NRICField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PhoneNoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Addr {
            get {
                return this.AddrField;
            }
            set {
                if ((object.ReferenceEquals(this.AddrField, value) != true)) {
                    this.AddrField = value;
                    this.RaisePropertyChanged("Addr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DOB {
            get {
                return this.DOBField;
            }
            set {
                if ((this.DOBField.Equals(value) != true)) {
                    this.DOBField = value;
                    this.RaisePropertyChanged("DOB");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MedCon {
            get {
                return this.MedConField;
            }
            set {
                if ((object.ReferenceEquals(this.MedConField, value) != true)) {
                    this.MedConField = value;
                    this.RaisePropertyChanged("MedCon");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NRIC {
            get {
                return this.NRICField;
            }
            set {
                if ((object.ReferenceEquals(this.NRICField, value) != true)) {
                    this.NRICField = value;
                    this.RaisePropertyChanged("NRIC");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nat {
            get {
                return this.NatField;
            }
            set {
                if ((object.ReferenceEquals(this.NatField, value) != true)) {
                    this.NatField = value;
                    this.RaisePropertyChanged("Nat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PhoneNo {
            get {
                return this.PhoneNoField;
            }
            set {
                if ((this.PhoneNoField.Equals(value) != true)) {
                    this.PhoneNoField = value;
                    this.RaisePropertyChanged("PhoneNo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/MyDBService.Entity")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FinalHashField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SaltField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FinalHash {
            get {
                return this.FinalHashField;
            }
            set {
                if ((object.ReferenceEquals(this.FinalHashField, value) != true)) {
                    this.FinalHashField = value;
                    this.RaisePropertyChanged("FinalHash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IV {
            get {
                return this.IVField;
            }
            set {
                if ((object.ReferenceEquals(this.IVField, value) != true)) {
                    this.IVField = value;
                    this.RaisePropertyChanged("IV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Salt {
            get {
                return this.SaltField;
            }
            set {
                if ((object.ReferenceEquals(this.SaltField, value) != true)) {
                    this.SaltField = value;
                    this.RaisePropertyChanged("Salt");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyDBServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        healthsight_project.MyDBServiceReference.CompositeType GetDataUsingDataContract(healthsight_project.MyDBServiceReference.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<healthsight_project.MyDBServiceReference.CompositeType> GetDataUsingDataContractAsync(healthsight_project.MyDBServiceReference.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPatientByNRIC", ReplyAction="http://tempuri.org/IService1/GetPatientByNRICResponse")]
        healthsight_project.MyDBServiceReference.Patient GetPatientByNRIC(string nric);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPatientByNRIC", ReplyAction="http://tempuri.org/IService1/GetPatientByNRICResponse")]
        System.Threading.Tasks.Task<healthsight_project.MyDBServiceReference.Patient> GetPatientByNRICAsync(string nric);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPatientByEmail", ReplyAction="http://tempuri.org/IService1/GetPatientByEmailResponse")]
        healthsight_project.MyDBServiceReference.Patient GetPatientByEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPatientByEmail", ReplyAction="http://tempuri.org/IService1/GetPatientByEmailResponse")]
        System.Threading.Tasks.Task<healthsight_project.MyDBServiceReference.Patient> GetPatientByEmailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreatePatient", ReplyAction="http://tempuri.org/IService1/CreatePatientResponse")]
        int CreatePatient(string name, string nric, System.DateTime dob, string gen, string nat, string addr, string medcon, string email, double phoneNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreatePatient", ReplyAction="http://tempuri.org/IService1/CreatePatientResponse")]
        System.Threading.Tasks.Task<int> CreatePatientAsync(string name, string nric, System.DateTime dob, string gen, string nat, string addr, string medcon, string email, double phoneNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserByEmail", ReplyAction="http://tempuri.org/IService1/GetUserByEmailResponse")]
        healthsight_project.MyDBServiceReference.User GetUserByEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserByEmail", ReplyAction="http://tempuri.org/IService1/GetUserByEmailResponse")]
        System.Threading.Tasks.Task<healthsight_project.MyDBServiceReference.User> GetUserByEmailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateUser", ReplyAction="http://tempuri.org/IService1/CreateUserResponse")]
        int CreateUser(string email, string finalHash, string salt, string key, string iv);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateUser", ReplyAction="http://tempuri.org/IService1/CreateUserResponse")]
        System.Threading.Tasks.Task<int> CreateUserAsync(string email, string finalHash, string salt, string key, string iv);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : healthsight_project.MyDBServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<healthsight_project.MyDBServiceReference.IService1>, healthsight_project.MyDBServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public healthsight_project.MyDBServiceReference.CompositeType GetDataUsingDataContract(healthsight_project.MyDBServiceReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<healthsight_project.MyDBServiceReference.CompositeType> GetDataUsingDataContractAsync(healthsight_project.MyDBServiceReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public healthsight_project.MyDBServiceReference.Patient GetPatientByNRIC(string nric) {
            return base.Channel.GetPatientByNRIC(nric);
        }
        
        public System.Threading.Tasks.Task<healthsight_project.MyDBServiceReference.Patient> GetPatientByNRICAsync(string nric) {
            return base.Channel.GetPatientByNRICAsync(nric);
        }
        
        public healthsight_project.MyDBServiceReference.Patient GetPatientByEmail(string email) {
            return base.Channel.GetPatientByEmail(email);
        }
        
        public System.Threading.Tasks.Task<healthsight_project.MyDBServiceReference.Patient> GetPatientByEmailAsync(string email) {
            return base.Channel.GetPatientByEmailAsync(email);
        }
        
        public int CreatePatient(string name, string nric, System.DateTime dob, string gen, string nat, string addr, string medcon, string email, double phoneNo) {
            return base.Channel.CreatePatient(name, nric, dob, gen, nat, addr, medcon, email, phoneNo);
        }
        
        public System.Threading.Tasks.Task<int> CreatePatientAsync(string name, string nric, System.DateTime dob, string gen, string nat, string addr, string medcon, string email, double phoneNo) {
            return base.Channel.CreatePatientAsync(name, nric, dob, gen, nat, addr, medcon, email, phoneNo);
        }
        
        public healthsight_project.MyDBServiceReference.User GetUserByEmail(string email) {
            return base.Channel.GetUserByEmail(email);
        }
        
        public System.Threading.Tasks.Task<healthsight_project.MyDBServiceReference.User> GetUserByEmailAsync(string email) {
            return base.Channel.GetUserByEmailAsync(email);
        }
        
        public int CreateUser(string email, string finalHash, string salt, string key, string iv) {
            return base.Channel.CreateUser(email, finalHash, salt, key, iv);
        }
        
        public System.Threading.Tasks.Task<int> CreateUserAsync(string email, string finalHash, string salt, string key, string iv) {
            return base.Channel.CreateUserAsync(email, finalHash, salt, key, iv);
        }
    }
}
