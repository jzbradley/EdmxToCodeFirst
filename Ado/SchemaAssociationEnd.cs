using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaAssociationEnd
    {

        private string _roleField;

        private string _typeField;

        private string _multiplicityField;

        /// <remarks/>
        [XmlAttribute]
        public string Role
        {
            get => _roleField;
            set => _roleField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Type
        {
            get => _typeField;
            set => _typeField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Multiplicity
        {
            get => _multiplicityField;
            set => _multiplicityField = value;
        }
    }
}