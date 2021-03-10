using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaAssociation
    {

        private SchemaAssociationEnd[] _endField;

        private SchemaAssociationReferentialConstraint _referentialConstraintField;

        private string _nameField;

        /// <remarks/>
        [XmlElement("End")]
        public SchemaAssociationEnd[] End
        {
            get => _endField;
            set => _endField = value;
        }

        /// <remarks/>
        public SchemaAssociationReferentialConstraint ReferentialConstraint
        {
            get => _referentialConstraintField;
            set => _referentialConstraintField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Name
        {
            get => _nameField;
            set => _nameField = value;
        }
    }
}