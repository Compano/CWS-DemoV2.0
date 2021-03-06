﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo.ClientArtConnect {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0", ConfigurationName="ClientArtConnect.MessageServiceSoap")]
    public interface MessageServiceSoap {
        
        // CODEGEN: Generating message contract since the operation GetAvailableMessages is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="messageservice/GetAvailableMessages", ReplyAction="https://www.ketenstandaard.nl/WS/MessageService/3.0/MessageServiceSoap/GetAvailab" +
            "leMessagesResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Demo.ClientArtConnect.GetAvailableMessagesResponse GetAvailableMessages(Demo.ClientArtConnect.GetAvailableMessagesRequest request);
        
        // CODEGEN: Generating message contract since the operation GetMessage is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="messageservice/GetMessage", ReplyAction="https://www.ketenstandaard.nl/WS/MessageService/3.0/MessageServiceSoap/GetMessage" +
            "Response")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Demo.ClientArtConnect.GetMessageResponse GetMessage(Demo.ClientArtConnect.GetMessageRequest request);
        
        // CODEGEN: Generating message contract since the operation DeleteMessage is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="messageservice/DeleteMessage", ReplyAction="https://www.ketenstandaard.nl/WS/MessageService/3.0/MessageServiceSoap/DeleteMess" +
            "ageResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Demo.ClientArtConnect.DeleteMessageResponse DeleteMessage(Demo.ClientArtConnect.DeleteMessageRequest request);
        
        // CODEGEN: Generating message contract since the operation PostMessage is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="messageservice/PostMessage", ReplyAction="https://www.ketenstandaard.nl/WS/MessageService/3.0/MessageServiceSoap/PostMessag" +
            "eResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Demo.ClientArtConnect.DeleteMessageResponse PostMessage(Demo.ClientArtConnect.PostMessageRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
    public partial class CustomInfoType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool isTestMessageField;
        
        private string languageCodeField;
        
        private System.Nullable<bool> isContentCompressedField;
        
        private string applicationIdField;
        
        private string versionIdField;
        
        private string relationIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public bool IsTestMessage {
            get {
                return this.isTestMessageField;
            }
            set {
                this.isTestMessageField = value;
                this.RaisePropertyChanged("IsTestMessage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string LanguageCode {
            get {
                return this.languageCodeField;
            }
            set {
                this.languageCodeField = value;
                this.RaisePropertyChanged("LanguageCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=2)]
        public System.Nullable<bool> IsContentCompressed {
            get {
                return this.isContentCompressedField;
            }
            set {
                this.isContentCompressedField = value;
                this.RaisePropertyChanged("IsContentCompressed");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=3)]
        public string ApplicationId {
            get {
                return this.applicationIdField;
            }
            set {
                this.applicationIdField = value;
                this.RaisePropertyChanged("ApplicationId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=4)]
        public string VersionId {
            get {
                return this.versionIdField;
            }
            set {
                this.versionIdField = value;
                this.RaisePropertyChanged("VersionId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=5)]
        public string RelationId {
            get {
                return this.relationIdField;
            }
            set {
                this.relationIdField = value;
                this.RaisePropertyChanged("RelationId");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
    public partial class MessageResponseType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MessageType messageField;
        
        private bool messageResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public MessageType Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("Message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public bool MessageResult {
            get {
                return this.messageResultField;
            }
            set {
                this.messageResultField = value;
                this.RaisePropertyChanged("MessageResult");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
    public partial class MessageType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MessagePropertiesType msgPropertiesField;
        
        private string msgContentField;
        
        private AttachmentType[] attachmentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public MessagePropertiesType MsgProperties {
            get {
                return this.msgPropertiesField;
            }
            set {
                this.msgPropertiesField = value;
                this.RaisePropertyChanged("MsgProperties");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string MsgContent {
            get {
                return this.msgContentField;
            }
            set {
                this.msgContentField = value;
                this.RaisePropertyChanged("MsgContent");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Attachment", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public AttachmentType[] Attachment {
            get {
                return this.attachmentField;
            }
            set {
                this.attachmentField = value;
                this.RaisePropertyChanged("Attachment");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
    public partial class MessagePropertiesType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string msgIdField;
        
        private System.DateTime msgDateTimeField;
        
        private System.Nullable<MsgFormatType> msgFormatField;
        
        private string msgVersionField;
        
        private string msgTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public string MsgId {
            get {
                return this.msgIdField;
            }
            set {
                this.msgIdField = value;
                this.RaisePropertyChanged("MsgId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public System.DateTime MsgDateTime {
            get {
                return this.msgDateTimeField;
            }
            set {
                this.msgDateTimeField = value;
                this.RaisePropertyChanged("MsgDateTime");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=2)]
        public System.Nullable<MsgFormatType> MsgFormat {
            get {
                return this.msgFormatField;
            }
            set {
                this.msgFormatField = value;
                this.RaisePropertyChanged("MsgFormat");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=3)]
        public string MsgVersion {
            get {
                return this.msgVersionField;
            }
            set {
                this.msgVersionField = value;
                this.RaisePropertyChanged("MsgVersion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=4)]
        public string MsgType {
            get {
                return this.msgTypeField;
            }
            set {
                this.msgTypeField = value;
                this.RaisePropertyChanged("MsgType");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
    public enum MsgFormatType {
        
        /// <remarks/>
        INSBOU,
        
        /// <remarks/>
        D96A,
        
        /// <remarks/>
        KETENSTANDAARD,
        
        /// <remarks/>
        CUSTOM,
        
        /// <remarks/>
        SALES,
        
        /// <remarks/>
        ETIM,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
    public partial class AttachmentType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string uRLField;
        
        private string documentTypeField;
        
        private string fileTypeField;
        
        private string fileNameField;
        
        private byte[] attachedDataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public string URL {
            get {
                return this.uRLField;
            }
            set {
                this.uRLField = value;
                this.RaisePropertyChanged("URL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string DocumentType {
            get {
                return this.documentTypeField;
            }
            set {
                this.documentTypeField = value;
                this.RaisePropertyChanged("DocumentType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string FileType {
            get {
                return this.fileTypeField;
            }
            set {
                this.fileTypeField = value;
                this.RaisePropertyChanged("FileType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string FileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
                this.RaisePropertyChanged("FileName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", IsNullable=true, Order=4)]
        public byte[] AttachedData {
            get {
                return this.attachedDataField;
            }
            set {
                this.attachedDataField = value;
                this.RaisePropertyChanged("AttachedData");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
    public partial class MessageRequestResponseType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MessageType messageRequestResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public MessageType MessageRequestResult {
            get {
                return this.messageRequestResultField;
            }
            set {
                this.messageRequestResultField = value;
                this.RaisePropertyChanged("MessageRequestResult");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
    public partial class MessageRequestType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string msgIdField;
        
        private System.Nullable<MsgFormatType> msgFormatField;
        
        private string msgVersionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public string MsgId {
            get {
                return this.msgIdField;
            }
            set {
                this.msgIdField = value;
                this.RaisePropertyChanged("MsgId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=1)]
        public System.Nullable<MsgFormatType> MsgFormat {
            get {
                return this.msgFormatField;
            }
            set {
                this.msgFormatField = value;
                this.RaisePropertyChanged("MsgFormat");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=2)]
        public string MsgVersion {
            get {
                return this.msgVersionField;
            }
            set {
                this.msgVersionField = value;
                this.RaisePropertyChanged("MsgVersion");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
    public partial class AvailableMessagesRequestType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string msgTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public string MsgType {
            get {
                return this.msgTypeField;
            }
            set {
                this.msgTypeField = value;
                this.RaisePropertyChanged("MsgType");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAvailableMessagesRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
        public Demo.ClientArtConnect.CustomInfoType CustomInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0", Order=0)]
        public Demo.ClientArtConnect.AvailableMessagesRequestType AvailableMessagesRequest;
        
        public GetAvailableMessagesRequest() {
        }
        
        public GetAvailableMessagesRequest(Demo.ClientArtConnect.CustomInfoType CustomInfo, Demo.ClientArtConnect.AvailableMessagesRequestType AvailableMessagesRequest) {
            this.CustomInfo = CustomInfo;
            this.AvailableMessagesRequest = AvailableMessagesRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAvailableMessagesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("MessageList", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Demo.ClientArtConnect.MessagePropertiesType[] AvailableMessagesResponse;
        
        public GetAvailableMessagesResponse() {
        }
        
        public GetAvailableMessagesResponse(Demo.ClientArtConnect.MessagePropertiesType[] AvailableMessagesResponse) {
            this.AvailableMessagesResponse = AvailableMessagesResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetMessageRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
        public Demo.ClientArtConnect.CustomInfoType CustomInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0", Order=0)]
        public Demo.ClientArtConnect.MessageRequestType MessageRequest;
        
        public GetMessageRequest() {
        }
        
        public GetMessageRequest(Demo.ClientArtConnect.CustomInfoType CustomInfo, Demo.ClientArtConnect.MessageRequestType MessageRequest) {
            this.CustomInfo = CustomInfo;
            this.MessageRequest = MessageRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetMessageResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0", Order=0)]
        public Demo.ClientArtConnect.MessageRequestResponseType MessageRequestResponse;
        
        public GetMessageResponse() {
        }
        
        public GetMessageResponse(Demo.ClientArtConnect.MessageRequestResponseType MessageRequestResponse) {
            this.MessageRequestResponse = MessageRequestResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteMessageRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
        public Demo.ClientArtConnect.CustomInfoType CustomInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0", Order=0)]
        public Demo.ClientArtConnect.MessageRequestType MessageRequest;
        
        public DeleteMessageRequest() {
        }
        
        public DeleteMessageRequest(Demo.ClientArtConnect.CustomInfoType CustomInfo, Demo.ClientArtConnect.MessageRequestType MessageRequest) {
            this.CustomInfo = CustomInfo;
            this.MessageRequest = MessageRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteMessageResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0", Order=0)]
        public Demo.ClientArtConnect.MessageResponseType MessageResponse;
        
        public DeleteMessageResponse() {
        }
        
        public DeleteMessageResponse(Demo.ClientArtConnect.MessageResponseType MessageResponse) {
            this.MessageResponse = MessageResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PostMessageRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0")]
        public Demo.ClientArtConnect.CustomInfoType CustomInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://www.ketenstandaard.nl/WS/MessageService/3.0", Order=0)]
        public Demo.ClientArtConnect.MessageType Message;
        
        public PostMessageRequest() {
        }
        
        public PostMessageRequest(Demo.ClientArtConnect.CustomInfoType CustomInfo, Demo.ClientArtConnect.MessageType Message) {
            this.CustomInfo = CustomInfo;
            this.Message = Message;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MessageServiceSoapChannel : Demo.ClientArtConnect.MessageServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessageServiceSoapClient : System.ServiceModel.ClientBase<Demo.ClientArtConnect.MessageServiceSoap>, Demo.ClientArtConnect.MessageServiceSoap {
        
        public MessageServiceSoapClient() {
        }
        
        public MessageServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MessageServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessageServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessageServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Demo.ClientArtConnect.GetAvailableMessagesResponse Demo.ClientArtConnect.MessageServiceSoap.GetAvailableMessages(Demo.ClientArtConnect.GetAvailableMessagesRequest request) {
            return base.Channel.GetAvailableMessages(request);
        }
        
        public Demo.ClientArtConnect.MessagePropertiesType[] GetAvailableMessages(Demo.ClientArtConnect.CustomInfoType CustomInfo, Demo.ClientArtConnect.AvailableMessagesRequestType AvailableMessagesRequest) {
            Demo.ClientArtConnect.GetAvailableMessagesRequest inValue = new Demo.ClientArtConnect.GetAvailableMessagesRequest();
            inValue.CustomInfo = CustomInfo;
            inValue.AvailableMessagesRequest = AvailableMessagesRequest;
            Demo.ClientArtConnect.GetAvailableMessagesResponse retVal = ((Demo.ClientArtConnect.MessageServiceSoap)(this)).GetAvailableMessages(inValue);
            return retVal.AvailableMessagesResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Demo.ClientArtConnect.GetMessageResponse Demo.ClientArtConnect.MessageServiceSoap.GetMessage(Demo.ClientArtConnect.GetMessageRequest request) {
            return base.Channel.GetMessage(request);
        }
        
        public Demo.ClientArtConnect.MessageRequestResponseType GetMessage(Demo.ClientArtConnect.CustomInfoType CustomInfo, Demo.ClientArtConnect.MessageRequestType MessageRequest) {
            Demo.ClientArtConnect.GetMessageRequest inValue = new Demo.ClientArtConnect.GetMessageRequest();
            inValue.CustomInfo = CustomInfo;
            inValue.MessageRequest = MessageRequest;
            Demo.ClientArtConnect.GetMessageResponse retVal = ((Demo.ClientArtConnect.MessageServiceSoap)(this)).GetMessage(inValue);
            return retVal.MessageRequestResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Demo.ClientArtConnect.DeleteMessageResponse Demo.ClientArtConnect.MessageServiceSoap.DeleteMessage(Demo.ClientArtConnect.DeleteMessageRequest request) {
            return base.Channel.DeleteMessage(request);
        }
        
        public Demo.ClientArtConnect.MessageResponseType DeleteMessage(Demo.ClientArtConnect.CustomInfoType CustomInfo, Demo.ClientArtConnect.MessageRequestType MessageRequest) {
            Demo.ClientArtConnect.DeleteMessageRequest inValue = new Demo.ClientArtConnect.DeleteMessageRequest();
            inValue.CustomInfo = CustomInfo;
            inValue.MessageRequest = MessageRequest;
            Demo.ClientArtConnect.DeleteMessageResponse retVal = ((Demo.ClientArtConnect.MessageServiceSoap)(this)).DeleteMessage(inValue);
            return retVal.MessageResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Demo.ClientArtConnect.DeleteMessageResponse Demo.ClientArtConnect.MessageServiceSoap.PostMessage(Demo.ClientArtConnect.PostMessageRequest request) {
            return base.Channel.PostMessage(request);
        }
        
        public Demo.ClientArtConnect.MessageResponseType PostMessage(Demo.ClientArtConnect.CustomInfoType CustomInfo, Demo.ClientArtConnect.MessageType Message) {
            Demo.ClientArtConnect.PostMessageRequest inValue = new Demo.ClientArtConnect.PostMessageRequest();
            inValue.CustomInfo = CustomInfo;
            inValue.Message = Message;
            Demo.ClientArtConnect.DeleteMessageResponse retVal = ((Demo.ClientArtConnect.MessageServiceSoap)(this)).PostMessage(inValue);
            return retVal.MessageResponse;
        }
    }
}
