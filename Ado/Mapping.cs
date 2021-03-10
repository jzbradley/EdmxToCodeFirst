using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs")]
    [XmlRoot(Namespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs", IsNullable = false)]
    public class Mapping : XmlRootEntity<Mapping>
    {

        private MappingEntityContainerMapping _entityContainerMappingField;

        private string _spaceField;

        /// <remarks/>
        public MappingEntityContainerMapping EntityContainerMapping
        {
            get => _entityContainerMappingField;
            set => _entityContainerMappingField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Space
        {
            get => _spaceField;
            set => _spaceField = value;
        }
    }
}