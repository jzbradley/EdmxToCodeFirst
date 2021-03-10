using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaEntityContainer
    {

        private SchemaEntityContainerEntitySet[] _entitySetField;

        private SchemaEntityContainerAssociationSet[] _associationSetField;

        private string _nameField;

        /// <remarks/>
        [XmlElement("EntitySet")]
        public SchemaEntityContainerEntitySet[] EntitySet
        {
            get => _entitySetField;
            set => _entitySetField = value;
        }

        /// <remarks/>
        [XmlElement("AssociationSet")]
        public SchemaEntityContainerAssociationSet[] AssociationSet
        {
            get => _associationSetField;
            set => _associationSetField = value;
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