using System.IO;
using System.Xml.Serialization;

namespace EdmxToCodeFirst.Ado
{
    public abstract class XmlRootEntity<T>
    {
        private static XmlSerializer Serializer;

        public static T Open(string filename)
        {
            var serializer = Serializer ?? new XmlSerializer(typeof(T));
            using (var stream = File.OpenRead(filename))
            {
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}