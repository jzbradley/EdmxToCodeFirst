using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaAssociationReferentialConstraintPrincipal
    {

        private SchemaAssociationReferentialConstraintPrincipalPropertyRef _propertyRefField;

        private string _roleField;

        /// <remarks/>
        public SchemaAssociationReferentialConstraintPrincipalPropertyRef PropertyRef
        {
            get => _propertyRefField;
            set => _propertyRefField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Role
        {
            get => _roleField;
            set => _roleField = value;
        }
    }
}