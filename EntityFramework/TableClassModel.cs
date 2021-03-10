using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdmxToCodeFirst.EntityFramework
{
    public class TableClassModel
    {
        public HashSet<string> Include { get; } = new HashSet<string>
        {
            "System",
            "System.Data.Entity.ModelConfiguration",
            "System.ComponentModel.DataAnnotations",
            "System.ComponentModel.DataAnnotations.Schema"
        };
        public string SchemaName { get; }
        public string TableName { get; }

        public List<FieldModel> Fields { get; }

        public List<FieldModel> PrimaryKey { get; }

        public string Namespace { get; }
        public string ClassName { get; }

        private TableClassModel()
        {
            Fields = new List<FieldModel>();
            PrimaryKey = new List<FieldModel>();
        }

        public TableClassModel(Modeler modeler)
            : this()
        {
            Namespace = modeler.Namespace;

            var entitySet = modeler.EntitySet;
            SchemaName = entitySet.Schema;
            TableName = entitySet.Name;

            var className = modeler.SqlToCodeName(TableName);
            ClassName = className;

            Fields = FieldModel.CreateFields(modeler).ToList();
        }

        public override string ToString()
        {
            return ToString(new StringBuilder()).ToString();
        }

        internal StringBuilder ToString(StringBuilder sb)
        {
            var p = "".PadLeft(4, ' ');
            sb.AppendLine($"{p}{ClassName} : Table [{SchemaName}].[{TableName}]");
            sb.AppendLine(
                $"{p}{p}Key {PrimaryKey.MapZeroOneOrMany(() => "<none>", key => key.FieldName, keys => string.Join(", ", keys))}");
            foreach (var fieldModel in Fields)
            {
                fieldModel
                    .ToString(sb.Append(p).Append(p))
                    .AppendLine();
            }

            return sb;
        }


        public void WriteFile(StringBuilder sb)
        {
            sb.Append($@"namespace {Namespace}
{{
{string.Join(Environment.NewLine, Include.Select(include=>$"    using {include};"))}

    public partial class {ClassName}
    {{
");
            var indent = 2;

            WritePropertyDeclarations(sb, indent);

            WriteModelConfiguration(sb, indent);

            sb.AppendLine(@"
    }
}");
        }

        private void WriteModelConfiguration(StringBuilder sb, int indent)
        {
            var padding = "".PadLeft(4 * indent, ' ');
            var p = "".PadLeft(4, ' ');
            sb.AppendLine($@"
{padding}public class AdoConfigurationMap  : EntityTypeConfiguration<{ClassName}>
{padding}{{
{padding}{p}public AdoConfigurationMap()
{padding}{p}{{");
            WriteTableMapping(sb, indent + 2);
            WriteKeyConfiguration(sb, indent + 2);
            WritePropertyConfigurations(sb, indent + 2);
            sb.AppendLine($@"
{padding}{p}}}
{padding}}}");
        }

        private void WriteTableMapping(StringBuilder sb, int indent)
        {
            var padding = "".PadLeft(4 * indent, ' ');
            sb.AppendLine(string.IsNullOrEmpty(SchemaName)
                ? $@"{padding}ToTable(""{TableName}"");"
                : $@"{padding}ToTable(""{TableName}"", ""{SchemaName}"");");
        }

        private void WriteKeyConfiguration(StringBuilder sb, int indent)
        {
            var padding = "".PadLeft(4 * indent, ' ');
            if (PrimaryKey== null || PrimaryKey.Count == 0)
                return;
            if (PrimaryKey.Count == 1)
            {
                var keyField = PrimaryKey.Single();
                sb.AppendLine($@"{padding}.HasKey(t=>t.{keyField.FieldName});");
                return;
            }
            sb.AppendLine($@"{padding}.HasKey(t=>new {{");
            var p = "".PadLeft(4, ' ');
            foreach (var keyPart in PrimaryKey)
                sb.AppendLine($@"{padding}{p}t.{keyPart.FieldName},");
            sb.AppendLine($@"{padding}}});");
        }

        private void WritePropertyConfigurations(StringBuilder sb, int indent)
        {
            foreach (var fieldModel in Fields)
            {
                fieldModel.WritePropertyConfiguration(sb, indent);
            }
        }

        private void WritePropertyDeclarations(StringBuilder sb, int indent)
        {
            var padding = "".PadLeft(indent * 4, ' ');
            foreach (var field in Fields)
            {
                field.WriteProperty(sb.Append(padding), indent)
                    .AppendLine();
            }
        }
    }
}