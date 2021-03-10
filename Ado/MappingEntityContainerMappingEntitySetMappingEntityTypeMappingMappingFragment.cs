using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs")]
    public class MappingEntityContainerMappingEntitySetMappingEntityTypeMappingMappingFragment
    {

        private MappingEntityContainerMappingEntitySetMappingEntityTypeMappingMappingFragmentScalarProperty[] _scalarPropertyField;

        private string _storeEntitySetField;

        /// <remarks/>
        [XmlElement("ScalarProperty")]
        public MappingEntityContainerMappingEntitySetMappingEntityTypeMappingMappingFragmentScalarProperty[] ScalarProperty
        {
            get => _scalarPropertyField;
            set => _scalarPropertyField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string StoreEntitySet
        {
            get => _storeEntitySetField;
            set => _storeEntitySetField = value;
        }
    }
}