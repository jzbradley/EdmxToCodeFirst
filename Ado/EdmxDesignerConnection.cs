using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx")]
    public class EdmxDesignerConnection
    {

        private EdmxDesignerConnectionDesignerInfoPropertySet _designerInfoPropertySetField;

        /// <remarks/>
        public EdmxDesignerConnectionDesignerInfoPropertySet DesignerInfoPropertySet
        {
            get => _designerInfoPropertySetField;
            set => _designerInfoPropertySetField = value;
        }
    }
}