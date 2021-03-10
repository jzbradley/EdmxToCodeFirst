using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx")]
    public class EdmxDesignerOptionsDesignerProperty
    {

        private string _nameField;

        private string _valueField;

        /// <remarks/>
        [XmlAttribute]
        public string Name
        {
            get => _nameField;
            set => _nameField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Value
        {
            get => _valueField;
            set => _valueField = value;
        }
    }
}