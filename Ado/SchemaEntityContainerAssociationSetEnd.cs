using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaEntityContainerAssociationSetEnd
    {

        private string _roleField;

        private string _entitySetField;

        /// <remarks/>
        [XmlAttribute]
        public string Role
        {
            get => _roleField;
            set => _roleField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string EntitySet
        {
            get => _entitySetField;
            set => _entitySetField = value;
        }
    }
}