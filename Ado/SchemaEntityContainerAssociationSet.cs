using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaEntityContainerAssociationSet
    {

        private SchemaEntityContainerAssociationSetEnd[] _endField;

        private string _nameField;

        private string _associationField;

        /// <remarks/>
        [XmlElement("End")]
        public SchemaEntityContainerAssociationSetEnd[] End
        {
            get => _endField;
            set => _endField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Name
        {
            get => _nameField;
            set => _nameField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Association
        {
            get => _associationField;
            set => _associationField = value;
        }
    }
}