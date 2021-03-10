using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs")]
    public class MappingEntityContainerMappingEntitySetMappingEntityTypeMapping
    {

        private MappingEntityContainerMappingEntitySetMappingEntityTypeMappingMappingFragment _mappingFragmentField;

        private string _typeNameField;

        /// <remarks/>
        public MappingEntityContainerMappingEntitySetMappingEntityTypeMappingMappingFragment MappingFragment
        {
            get => _mappingFragmentField;
            set => _mappingFragmentField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string TypeName
        {
            get => _typeNameField;
            set => _typeNameField = value;
        }
    }
}