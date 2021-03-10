using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaAssociationReferentialConstraint
    {

        private SchemaAssociationReferentialConstraintPrincipal _principalField;

        private SchemaAssociationReferentialConstraintDependent _dependentField;

        /// <remarks/>
        public SchemaAssociationReferentialConstraintPrincipal Principal
        {
            get => _principalField;
            set => _principalField = value;
        }

        /// <remarks/>
        public SchemaAssociationReferentialConstraintDependent Dependent
        {
            get => _dependentField;
            set => _dependentField = value;
        }
    }
}