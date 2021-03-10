using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx")]
    public class EdmxDesigner
    {

        private EdmxDesignerConnection _connectionField;

        private EdmxDesignerOptions _optionsField;

        private object _diagramsField;

        /// <remarks/>
        public EdmxDesignerConnection Connection
        {
            get => _connectionField;
            set => _connectionField = value;
        }

        /// <remarks/>
        public EdmxDesignerOptions Options
        {
            get => _optionsField;
            set => _optionsField = value;
        }

        /// <remarks/>
        public object Diagrams
        {
            get => _diagramsField;
            set => _diagramsField = value;
        }
    }
}