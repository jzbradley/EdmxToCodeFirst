using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx")]
    public class EdmxDesignerConnectionDesignerInfoPropertySet
    {

        private EdmxDesignerConnectionDesignerInfoPropertySetDesignerProperty _designerPropertyField;

        /// <remarks/>
        public EdmxDesignerConnectionDesignerInfoPropertySetDesignerProperty DesignerProperty
        {
            get => _designerPropertyField;
            set => _designerPropertyField = value;
        }
    }
}