using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx")]
    public class EdmxDesignerOptions
    {

        private EdmxDesignerOptionsDesignerProperty[] _designerInfoPropertySetField;

        /// <remarks/>
        [XmlArrayItem("DesignerProperty", IsNullable = false)]
        public EdmxDesignerOptionsDesignerProperty[] DesignerInfoPropertySet
        {
            get => _designerInfoPropertySetField;
            set => _designerInfoPropertySetField = value;
        }
    }
}