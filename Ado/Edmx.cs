using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx")]
    [XmlRoot(Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx", IsNullable = false)]
    public class Edmx : XmlRootEntity<Edmx>
    {

        private EdmxRuntime _runtimeField;

        private EdmxDesigner _designerField;

        private decimal _versionField;

        /// <remarks/>
        public EdmxRuntime Runtime
        {
            get => _runtimeField;
            set => _runtimeField = value;
        }

        /// <remarks/>
        public EdmxDesigner Designer
        {
            get => _designerField;
            set => _designerField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal Version
        {
            get => _versionField;
            set => _versionField = value;
        }
    }
}