﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GetService.HelloWorldWebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HelloWorldWebService.HelloWorldWebServiceSoap")]
    public interface HelloWorldWebServiceSoap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 name 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        GetService.HelloWorldWebService.HelloWorldResponse HelloWorld(GetService.HelloWorldWebService.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<GetService.HelloWorldWebService.HelloWorldResponse> HelloWorldAsync(GetService.HelloWorldWebService.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/returnint", ReplyAction="*")]
        int returnint(int i);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/returnint", ReplyAction="*")]
        System.Threading.Tasks.Task<int> returnintAsync(int i);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public GetService.HelloWorldWebService.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(GetService.HelloWorldWebService.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string name;
        
        public HelloWorldRequestBody() {
        }
        
        public HelloWorldRequestBody(string name) {
            this.name = name;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public GetService.HelloWorldWebService.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(GetService.HelloWorldWebService.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface HelloWorldWebServiceSoapChannel : GetService.HelloWorldWebService.HelloWorldWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HelloWorldWebServiceSoapClient : System.ServiceModel.ClientBase<GetService.HelloWorldWebService.HelloWorldWebServiceSoap>, GetService.HelloWorldWebService.HelloWorldWebServiceSoap {
        
        public HelloWorldWebServiceSoapClient() {
        }
        
        public HelloWorldWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HelloWorldWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HelloWorldWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HelloWorldWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetService.HelloWorldWebService.HelloWorldResponse GetService.HelloWorldWebService.HelloWorldWebServiceSoap.HelloWorld(GetService.HelloWorldWebService.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld(string name) {
            GetService.HelloWorldWebService.HelloWorldRequest inValue = new GetService.HelloWorldWebService.HelloWorldRequest();
            inValue.Body = new GetService.HelloWorldWebService.HelloWorldRequestBody();
            inValue.Body.name = name;
            GetService.HelloWorldWebService.HelloWorldResponse retVal = ((GetService.HelloWorldWebService.HelloWorldWebServiceSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetService.HelloWorldWebService.HelloWorldResponse> GetService.HelloWorldWebService.HelloWorldWebServiceSoap.HelloWorldAsync(GetService.HelloWorldWebService.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<GetService.HelloWorldWebService.HelloWorldResponse> HelloWorldAsync(string name) {
            GetService.HelloWorldWebService.HelloWorldRequest inValue = new GetService.HelloWorldWebService.HelloWorldRequest();
            inValue.Body = new GetService.HelloWorldWebService.HelloWorldRequestBody();
            inValue.Body.name = name;
            return ((GetService.HelloWorldWebService.HelloWorldWebServiceSoap)(this)).HelloWorldAsync(inValue);
        }
        
        public int returnint(int i) {
            return base.Channel.returnint(i);
        }
        
        public System.Threading.Tasks.Task<int> returnintAsync(int i) {
            return base.Channel.returnintAsync(i);
        }
    }
}
