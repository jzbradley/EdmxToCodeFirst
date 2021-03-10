using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs")]
    public class MappingEntityContainerMappingEntitySetMapping
    {

        private MappingEntityContainerMappingEntitySetMappingEntityTypeMapping _entityTypeMappingField;

        private string _nameField;

        /// <remarks/>
        public MappingEntityContainerMappingEntitySetMappingEntityTypeMapping EntityTypeMapping
        {
            get => _entityTypeMappingField;
            set => _entityTypeMappingField = value;
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