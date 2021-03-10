using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaEntityContainerEntitySet
    {

        private string _nameField;

        private string _entityTypeField;

        private string _schemaField;

        private string _typeField;

        /// <remarks/>
        [XmlAttribute]
        public string Name
        {
            get => _nameField;
            set => _nameField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string EntityType
        {
            get => _entityTypeField;
            set => _entityTypeField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Schema
        {
            get => _schemaField;
            set => _schemaField = value;
        }

        /// <remarks/>
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/12/edm/EntityStoreSchemaGenerator")]
        public string Type
        {
            get => _typeField;
            set => _typeField = value;
        }
    }
}