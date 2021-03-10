using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs")]
    public class MappingEntityContainerMappingEntitySetMappingEntityTypeMappingMappingFragmentScalarProperty
    {

        private string _nameField;

        private string _columnNameField;

        /// <remarks/>
        [XmlAttribute]
        public string Name
        {
            get => _nameField;
            set => _nameField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string ColumnName
        {
            get => _columnNameField;
            set => _columnNameField = value;
        }
    }
}