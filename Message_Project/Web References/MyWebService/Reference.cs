﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.33440.
// 
#pragma warning disable 1591

namespace Message_Project.MyWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SendSoap", Namespace="Send")]
    public partial class Send : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SendSmsOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreditOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeliveryOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetInboxOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Send() {
            this.Url = global::Message_Project.Properties.Settings.Default.Message_Project_MyWebService_Send;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SendSmsCompletedEventHandler SendSmsCompleted;
        
        /// <remarks/>
        public event CreditCompletedEventHandler CreditCompleted;
        
        /// <remarks/>
        public event DeliveryCompletedEventHandler DeliveryCompleted;
        
        /// <remarks/>
        public event GetInboxCompletedEventHandler GetInboxCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Send/SendSms", RequestNamespace="Send", ResponseNamespace="Send", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendSms(string username, string password, string from, string[] to, string text, bool flash, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] ref byte[] status, ref long[] recId) {
            object[] results = this.Invoke("SendSms", new object[] {
                        username,
                        password,
                        from,
                        to,
                        text,
                        flash,
                        status,
                        recId});
            status = ((byte[])(results[1]));
            recId = ((long[])(results[2]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SendSmsAsync(string username, string password, string from, string[] to, string text, bool flash, byte[] status, long[] recId) {
            this.SendSmsAsync(username, password, from, to, text, flash, status, recId, null);
        }
        
        /// <remarks/>
        public void SendSmsAsync(string username, string password, string from, string[] to, string text, bool flash, byte[] status, long[] recId, object userState) {
            if ((this.SendSmsOperationCompleted == null)) {
                this.SendSmsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSmsOperationCompleted);
            }
            this.InvokeAsync("SendSms", new object[] {
                        username,
                        password,
                        from,
                        to,
                        text,
                        flash,
                        status,
                        recId}, this.SendSmsOperationCompleted, userState);
        }
        
        private void OnSendSmsOperationCompleted(object arg) {
            if ((this.SendSmsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendSmsCompleted(this, new SendSmsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Send/Credit", RequestNamespace="Send", ResponseNamespace="Send", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double Credit(string username, string password) {
            object[] results = this.Invoke("Credit", new object[] {
                        username,
                        password});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void CreditAsync(string username, string password) {
            this.CreditAsync(username, password, null);
        }
        
        /// <remarks/>
        public void CreditAsync(string username, string password, object userState) {
            if ((this.CreditOperationCompleted == null)) {
                this.CreditOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreditOperationCompleted);
            }
            this.InvokeAsync("Credit", new object[] {
                        username,
                        password}, this.CreditOperationCompleted, userState);
        }
        
        private void OnCreditOperationCompleted(object arg) {
            if ((this.CreditCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreditCompleted(this, new CreditCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Send/Delivery", RequestNamespace="Send", ResponseNamespace="Send", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Delivery(long recId) {
            object[] results = this.Invoke("Delivery", new object[] {
                        recId});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void DeliveryAsync(long recId) {
            this.DeliveryAsync(recId, null);
        }
        
        /// <remarks/>
        public void DeliveryAsync(long recId, object userState) {
            if ((this.DeliveryOperationCompleted == null)) {
                this.DeliveryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeliveryOperationCompleted);
            }
            this.InvokeAsync("Delivery", new object[] {
                        recId}, this.DeliveryOperationCompleted, userState);
        }
        
        private void OnDeliveryOperationCompleted(object arg) {
            if ((this.DeliveryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeliveryCompleted(this, new DeliveryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Send/GetInbox", RequestNamespace="Send", ResponseNamespace="Send", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetInbox(string username, string password, string to, int year, int month, int day, int hour, int minute) {
            object[] results = this.Invoke("GetInbox", new object[] {
                        username,
                        password,
                        to,
                        year,
                        month,
                        day,
                        hour,
                        minute});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetInboxAsync(string username, string password, string to, int year, int month, int day, int hour, int minute) {
            this.GetInboxAsync(username, password, to, year, month, day, hour, minute, null);
        }
        
        /// <remarks/>
        public void GetInboxAsync(string username, string password, string to, int year, int month, int day, int hour, int minute, object userState) {
            if ((this.GetInboxOperationCompleted == null)) {
                this.GetInboxOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetInboxOperationCompleted);
            }
            this.InvokeAsync("GetInbox", new object[] {
                        username,
                        password,
                        to,
                        year,
                        month,
                        day,
                        hour,
                        minute}, this.GetInboxOperationCompleted, userState);
        }
        
        private void OnGetInboxOperationCompleted(object arg) {
            if ((this.GetInboxCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetInboxCompleted(this, new GetInboxCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void SendSmsCompletedEventHandler(object sender, SendSmsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendSmsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendSmsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public byte[] status {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[1]));
            }
        }
        
        /// <remarks/>
        public long[] recId {
            get {
                this.RaiseExceptionIfNecessary();
                return ((long[])(this.results[2]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void CreditCompletedEventHandler(object sender, CreditCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreditCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreditCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void DeliveryCompletedEventHandler(object sender, DeliveryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeliveryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeliveryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetInboxCompletedEventHandler(object sender, GetInboxCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetInboxCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetInboxCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591