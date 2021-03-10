using System;
using System.ComponentModel;
using System.Data.Metadata.Edm;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl")]
    public class SchemaEntityTypeProperty
    {

        private string _nameField;

        private string _typeField;

        private StoreGeneratedPattern _storeGeneratedPatternField;

        private bool _nullableField;

        private bool _nullableFieldSpecified;

        private ushort _maxLengthField;

        private bool _maxLengthFieldSpecified;

        /// <remarks/>
        [XmlAttribute]
        public string Name
        {
            get => _nameField;
            set => _nameField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public string Type
        {
            get => _typeField;
            set => _typeField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public StoreGeneratedPattern StoreGeneratedPattern
        {
            get => _storeGeneratedPatternField;
            set => _storeGeneratedPatternField = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public bool Nullable
        {
            get => _nullableField;
            set => _nullableField = value;
        }

        /// <remarks/>
        [XmlIgnore]
        public bool NullableSpecified
        {
            get => _nullableFieldSpecified;
            set => _nullableFieldSpecified = value;
        }

        /// <remarks/>
        [XmlAttribute]
        public ushort MaxLength
        {
            get => _maxLengthField;
            set => _maxLengthField = value;
        }

        /// <remarks/>
        [XmlIgnore]
        public bool MaxLengthSpecified
        {
            get => _maxLengthFieldSpecified;
            set => _maxLengthFieldSpecified = value;
        }
        
        public override string ToString()
        {
            return $"{Name} {Type}{(MaxLengthSpecified?"("+MaxLength+")":"")} {(!NullableSpecified||Nullable ? "NULL" : "NOT NULL")}";
        }
    }
}