using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx")]
    public class EdmxRuntimeConceptualModels
    {

        private Schema _schemaField;

        /// <remarks/>
        [XmlElement(Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
        public Schema Schema
        {
            get => _schemaField;
            set => _schemaField = value;
        }
    }
}