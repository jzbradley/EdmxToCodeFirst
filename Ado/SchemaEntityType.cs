using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaEntityType
    {
        private SchemaEntityTypeKey _keyField;

        private SchemaEntityTypeProperty[] _propertyField;

        private string _nameField;

        /// <remarks/>
        public SchemaEntityTypeKey Key
        {
            get => _keyField;
            set => _keyField = value;
        }

        /// <remarks/>
        [XmlElement("Property")]
        public SchemaEntityTypeProperty[] Property
        {
            get => _propertyField;
            set => _propertyField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Name
        {
            get => _nameField;
            set => _nameField = value;
        }

        public override string ToString()
        {
            return $"ENTITY {Name} ({string.Join(", ", (IEnumerable<object>) Property)}, PRIMARY {Key})";
        }
    }
}