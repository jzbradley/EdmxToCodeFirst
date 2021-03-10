using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edmx")]
    public class EdmxRuntime
    {

        private EdmxRuntimeStorageModels _storageModelsField;

        private EdmxRuntimeConceptualModels _conceptualModelsField;

        private EdmxRuntimeMappings _mappingsField;

        /// <remarks/>
        public EdmxRuntimeStorageModels StorageModels
        {
            get => _storageModelsField;
            set => _storageModelsField = value;
        }

        /// <remarks/>
        public EdmxRuntimeConceptualModels ConceptualModels
        {
            get => _conceptualModelsField;
            set => _conceptualModelsField = value;
        }

        /// <remarks/>
        public EdmxRuntimeMappings Mappings
        {
            get => _mappingsField;
            set => _mappingsField = value;
        }
    }
}