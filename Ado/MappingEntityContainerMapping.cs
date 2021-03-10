using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs")]
    public class MappingEntityContainerMapping
    {

        private MappingEntityContainerMappingEntitySetMapping[] _entitySetMappingField;

        private string _storageEntityContainerField;

        private string _cdmEntityContainerField;

        /// <remarks/>
        [XmlElement("EntitySetMapping")]
        public MappingEntityContainerMappingEntitySetMapping[] EntitySetMapping
        {
            get => _entitySetMappingField;
            set => _entitySetMappingField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string StorageEntityContainer
        {
            get => _storageEntityContainerField;
            set => _storageEntityContainerField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string CdmEntityContainer
        {
            get => _cdmEntityContainerField;
            set => _cdmEntityContainerField = value;
        }
    }
}