﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace X12ResourceTool.Spec.MapV2 {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("transaction", Namespace="", IsNullable=false)]
    public partial class transactionType {
        
        private string nameField;
        
        private LoopType loopField;
        
        private string xidField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="token")]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LoopType loop {
            get {
                return this.loopField;
            }
            set {
                this.loopField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
        public string xid {
            get {
                return this.xidField;
            }
            set {
                this.xidField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoopType {
        
        private SegmentType[] segmentField;
        
        private LoopType[] loopField;
        
        private string xidField;
        
        private string posField;
        
        private usageType usageField;
        
        private string repeatField;
        
        private string typeField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("segment", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SegmentType[] segment {
            get {
                return this.segmentField;
            }
            set {
                this.segmentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("loop", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LoopType[] loop {
            get {
                return this.loopField;
            }
            set {
                this.loopField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
        public string xid {
            get {
                return this.xidField;
            }
            set {
                this.xidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string pos {
            get {
                return this.posField;
            }
            set {
                this.posField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public usageType usage {
            get {
                return this.usageField;
            }
            set {
                this.usageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string repeat {
            get {
                return this.repeatField;
            }
            set {
                this.repeatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SegmentType {
        
        private string[] syntaxField;
        
        private ElementType[] elementField;
        
        private CompositeType[] compositeField;
        
        private string xidField;
        
        private usageType usageField;
        
        private string posField;
        
        private string max_useField;
        
        private string end_tagField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("syntax", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="token")]
        public string[] syntax {
            get {
                return this.syntaxField;
            }
            set {
                this.syntaxField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("element", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ElementType[] element {
            get {
                return this.elementField;
            }
            set {
                this.elementField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("composite", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CompositeType[] composite {
            get {
                return this.compositeField;
            }
            set {
                this.compositeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
        public string xid {
            get {
                return this.xidField;
            }
            set {
                this.xidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public usageType usage {
            get {
                return this.usageField;
            }
            set {
                this.usageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string pos {
            get {
                return this.posField;
            }
            set {
                this.posField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string max_use {
            get {
                return this.max_useField;
            }
            set {
                this.max_useField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string end_tag {
            get {
                return this.end_tagField;
            }
            set {
                this.end_tagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ElementType {
        
        private ElementTypeValid_codes valid_codesField;
        
        private string regexField;
        
        private string xidField;
        
        private string data_eleField;
        
        private usageType usageField;
        
        private string seqField;
        
        private string repeatField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ElementTypeValid_codes valid_codes {
            get {
                return this.valid_codesField;
            }
            set {
                this.valid_codesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="token")]
        public string regex {
            get {
                return this.regexField;
            }
            set {
                this.regexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
        public string xid {
            get {
                return this.xidField;
            }
            set {
                this.xidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string data_ele {
            get {
                return this.data_eleField;
            }
            set {
                this.data_eleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public usageType usage {
            get {
                return this.usageField;
            }
            set {
                this.usageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string seq {
            get {
                return this.seqField;
            }
            set {
                this.seqField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string repeat {
            get {
                return this.repeatField;
            }
            set {
                this.repeatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ElementTypeValid_codes {
        
        private string[] codeField;
        
        private string externalField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("code", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="token")]
        public string[] code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
        public string external {
            get {
                return this.externalField;
            }
            set {
                this.externalField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CompositeType {
        
        private string[] syntaxField;
        
        private ElementType[] elementField;
        
        private string xidField;
        
        private string data_eleField;
        
        private usageType usageField;
        
        private string seqField;
        
        private string repeatField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("syntax", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="token")]
        public string[] syntax {
            get {
                return this.syntaxField;
            }
            set {
                this.syntaxField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("element", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ElementType[] element {
            get {
                return this.elementField;
            }
            set {
                this.elementField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="NMTOKEN")]
        public string xid {
            get {
                return this.xidField;
            }
            set {
                this.xidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string data_ele {
            get {
                return this.data_eleField;
            }
            set {
                this.data_eleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public usageType usage {
            get {
                return this.usageField;
            }
            set {
                this.usageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string seq {
            get {
                return this.seqField;
            }
            set {
                this.seqField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string repeat {
            get {
                return this.repeatField;
            }
            set {
                this.repeatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    public enum usageType {
        
        /// <remarks/>
        R,
        
        /// <remarks/>
        S,
        
        /// <remarks/>
        N,
    }
}
