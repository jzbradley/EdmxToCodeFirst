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
    public class SchemaEntityTypeKey
    {

        private SchemaEntityTypeKeyPropertyRef[] _propertyRefField;

        /// <remarks/>
        public SchemaEntityTypeKeyPropertyRef[] PropertyRef
        {
            get => _propertyRefField;
            set => _propertyRefField = value;
        }

        public override string ToString() => PropertyRef == null ? "(Empty)" : $"KEY ({string.Join(",",(IEnumerable<object>)PropertyRef)})";
    }
}