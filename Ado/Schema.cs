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
    [XmlRoot("Schema", Namespace = "http://schemas.microsoft.com/ado/2009/11/edm", IsNullable = false)]
    public partial class Schema  : XmlRootEntity<Schema>
    {

        private SchemaEntityType[] _entityTypeField;

        private SchemaAssociation[] _associationField;

        private SchemaEntityContainer _entityContainerField;

        private string _namespaceField;

        private string _providerField;

        private ushort _providerManifestTokenField;

        private string _aliasField;

        private bool _useStrongSpatialTypesField;
        
        /// <remarks/>
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2009/02/edm/annotation")]
        public bool UseStrongSpatialTypes
        {
            get => _useStrongSpatialTypesField;
            set => _useStrongSpatialTypesField = value;
        }

        /// <remarks/>
        [XmlElement("EntityType")]
        public SchemaEntityType[] EntityType
        {
            get => _entityTypeField;
            set => _entityTypeField = value;
        }

        /// <remarks/>
        [XmlElement("Association")]
        public SchemaAssociation[] Association
        {
            get => _associationField;
            set => _associationField = value;
        }

        /// <remarks/>
        public SchemaEntityContainer EntityContainer
        {
            get => _entityContainerField;
            set => _entityContainerField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Namespace
        {
            get => _namespaceField;
            set => _namespaceField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Provider
        {
            get => _providerField;
            set => _providerField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public ushort ProviderManifestToken
        {
            get => _providerManifestTokenField;
            set => _providerManifestTokenField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Alias
        {
            get => _aliasField;
            set => _aliasField = value;
        }
    }
}