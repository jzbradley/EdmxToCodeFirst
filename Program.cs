using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using EdmxToCodeFirst.Ado;
using EdmxToCodeFirst.EntityFramework;

namespace EdmxToCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                var edmx = Edmx.Open("TestData/Test.edmx");
                var tableConfigurator = new Modeler(edmx.Runtime.StorageModels.Schema,"Test.EF","TestEntities");

                foreach (var dataSetModel in tableConfigurator.DataSetModels)
                {
                    dataSetModel.WriteFiles("Models");
                }
            }
            catch (Exception e)
            {
                Debugger.Break();
            }
        }

    }

    public class Modeler
    {
        public List<DataSetModel> DataSetModels { get; } 
        
        internal string Namespace { get; }
        internal Schema Schema { get; }
        internal SchemaEntityType EntityType { get; }
        internal SchemaEntityContainerEntitySet EntitySet { get; }

        public Modeler(Schema schema, string @namespace, string dataContextName)
        {
            DataSetModels = new List<DataSetModel>();

            Namespace = @namespace;
            Schema = schema;
            var tableClassModels = new List<TableClassModel>();
            foreach (var entityType in Schema.EntityType)
            {
                try
                {
                    EntityType = entityType;
                    EntitySet = Schema.EntityContainer.EntitySet.Single(es => es.Name == entityType.Name);
                    tableClassModels.Add(new TableClassModel(this));
                }
                catch (Exception e)
                {
                    Debugger.Break();
                }
            }

            if (tableClassModels.Count == 0) return;

            var nsGroups = tableClassModels
                .GroupBy(t=>t.Namespace);
                //.Select(g=>new
                //{
                //    Namespace = g.Key,
                //    Name = g.Key.Split('.').Last(),
                //    TableClassModels = g
                //});
            foreach (var nsGroup in nsGroups)
            {
                //var @namespace = nsGroup.Key;
                DataSetModels.Add(new DataSetModel(nsGroup, nsGroup.Key, dataContextName));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var dataSetModel in DataSetModels)
            {
                dataSetModel.ToString(sb);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string SqlToCodeName(string sqlName)
        {
            var splitChars = new[] {' ', '_'};
            var nameParts = sqlName
                .Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
            var leadingPart = nameParts[0];

            if (char.IsNumber(leadingPart[0])) throw new Exception($"Invalid name {sqlName}");

            for (var i = 0; i < nameParts.Length; i++)
            {
                var namePart = nameParts[i].ToArray();
                namePart[0] = char.ToUpper(namePart[0]);
                nameParts[i] = new string(namePart);
            }

            var codeName = string.Join("", nameParts);
            return codeName;
        }
    }

    public class DataSetModel
    {
        public DataSetModel(IEnumerable<TableClassModel> tableClasses, string @namespace, string name)
        {
            TableClassModels = tableClasses.ToList();
            Namespace = @namespace;
            Name = name;
        }

        public HashSet<string> Include { get; set; } = new HashSet<string>{"System.Data.Entity"};
        public string Namespace { get; set; }
        public string Name { get; set; }
        public List<TableClassModel> TableClassModels { get; set; }
        
        public void WriteFiles(string path)
        {
            Directory.CreateDirectory(path);
            var sb = new StringBuilder();
            WriteFile(sb);
            var schemaFileName = $"{path}/{Name}.cs";

            sb.WriteToFile(schemaFileName);
            foreach (var tableClassModel in TableClassModels)
            {
                sb.Clear();
                var tableFileName = $"{path}/{tableClassModel.ClassName}.cs";
                tableClassModel.WriteFile(sb);
                sb.WriteToFile(tableFileName);
            }
        }

        public override string ToString()
        {
            return ToString(new StringBuilder()).ToString();
        }

        internal StringBuilder ToString(StringBuilder sb)
        {
            sb.AppendLine($"schema {Namespace}.{Name}");
            foreach (var tableClassModel in TableClassModels)
            {
                tableClassModel.ToString(sb);
            }

            return sb;
        }

        public void WriteFile(StringBuilder sb)
        {
            sb.AppendLine($@"namespace {Namespace}
{{
{string.Join(Environment.NewLine, Include.Select(include=>$"    using {include};"))}

    public partial class {Name} : DbContext
    {{
        public {Name}()
            : base(""Name={Name}Connection"")
        {{
        }}
");
            var indent = 2;

            WriteSetDeclarations(sb, indent);
            
            WriteModelConfiguration(sb, indent);

            sb.Append(@"
    }
}");
        }

        private void WriteModelConfiguration(StringBuilder sb, int indent)
        {
            var padding = "".PadLeft(indent * 4, ' ');
            var configurator = "modelBuilder";
            sb.AppendLine($@"
{padding}protected override void OnModelCreating(DbModelBuilder {configurator})
{padding}{{");
            WriteTableConfiguration(sb, configurator, indent + 1);
            sb.AppendLine($@"
{padding}}}");
        }

        private void WriteTableConfiguration(StringBuilder sb, string configurator, int indent)
        {
            var padding = "".PadLeft(indent * 4, ' ');
            foreach (var tableClassModel in TableClassModels)
            {
                sb.AppendLine($@"{padding}{configurator}.Configurations.Add(new {tableClassModel.ClassName}.AdoConfigurationMap());");
            }
        }

        private void WriteSetDeclarations(StringBuilder sb, int indent)
        {
            var padding = "".PadLeft(indent * 4, ' ');
            foreach (var tableClassModel in TableClassModels)
                sb.AppendLine($@"{padding}public DbSet<{tableClassModel.ClassName}> {tableClassModel.ClassName}s {{ get; set; }}");
        }
    }
}
