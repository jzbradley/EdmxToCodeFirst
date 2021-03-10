using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx")]
    public class EdmxRuntimeMappings
    {

        private Mapping _mappingField;

        /// <remarks/>
        [XmlElement(Namespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs")]
        public Mapping Mapping
        {
            get => _mappingField;
            set => _mappingField = value;
        }
    }
}