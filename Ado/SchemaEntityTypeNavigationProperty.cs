using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public class SchemaEntityTypeNavigationProperty
    {

        private string _nameField;

        private string _relationshipField;

        private string _fromRoleField;

        private string _toRoleField;

        /// <remarks/>
        [XmlAttribute]
        public string Name
        {
            get => _nameField;
            set => _nameField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Relationship
        {
            get => _relationshipField;
            set => _relationshipField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string FromRole
        {
            get => _fromRoleField;
            set => _fromRoleField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string ToRole
        {
            get => _toRoleField;
            set => _toRoleField = value;
        }
    }
}