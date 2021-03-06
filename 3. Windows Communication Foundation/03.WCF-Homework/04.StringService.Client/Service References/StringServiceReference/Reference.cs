﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _04.StringService.Client.StringServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StringServiceReference.IStringService")]
    public interface IStringService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStringService/GetStringOccurences", ReplyAction="http://tempuri.org/IStringService/GetStringOccurencesResponse")]
        int GetStringOccurences(string firstString, string secondString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStringService/GetStringOccurences", ReplyAction="http://tempuri.org/IStringService/GetStringOccurencesResponse")]
        System.Threading.Tasks.Task<int> GetStringOccurencesAsync(string firstString, string secondString);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStringServiceChannel : _04.StringService.Client.StringServiceReference.IStringService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StringServiceClient : System.ServiceModel.ClientBase<_04.StringService.Client.StringServiceReference.IStringService>, _04.StringService.Client.StringServiceReference.IStringService {
        
        public StringServiceClient() {
        }
        
        public StringServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StringServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StringServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StringServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetStringOccurences(string firstString, string secondString) {
            return base.Channel.GetStringOccurences(firstString, secondString);
        }
        
        public System.Threading.Tasks.Task<int> GetStringOccurencesAsync(string firstString, string secondString) {
            return base.Channel.GetStringOccurencesAsync(firstString, secondString);
        }
    }
}
