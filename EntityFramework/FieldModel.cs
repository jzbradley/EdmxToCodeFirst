using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Xml;
using EdmxToCodeFirst.Ado;

namespace EdmxToCodeFirst.EntityFramework
{
    public sealed class XmlFieldModel : FieldModel<string> // NOTE: Untested
    {
        public XmlFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class TimeSpanFieldModel : FieldModel<TimeSpan>
    {
        public TimeSpanFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }


    public sealed class SingleFieldModel : FieldModel<float>
    {
        public SingleFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class Int64FieldModel : FieldModel<long>
    {
        public Int64FieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class Int32FieldModel : FieldModel<int>
    {
        public Int32FieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class Int16FieldModel : FieldModel<short>
    {
        public Int16FieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class GuidFieldModel : FieldModel<Guid>
    {
        public GuidFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class DoubleFieldModel : FieldModel<double>
    {
        public DoubleFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class DecimalFieldModel : FieldModel<decimal>
    {
        public DecimalFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class DateTimeOffsetFieldModel : FieldModel<DateTimeOffset>
    {
        public DateTimeOffsetFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class DateTimeFieldModel : FieldModel<DateTime>
    {
        public DateTimeFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public sealed class ByteFieldModel : FieldModel<byte>
    {
        public ByteFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }

    }

    public abstract class LengthFieldModel<T> : FieldModel<T>
    {
        protected LengthFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
        }
        public int MaxLength { get; set; }

        public bool IsFixedLength { get; set; }

        protected override void WriteCommands(StringBuilder sb, string padding)
        {
            base.WriteCommands(sb, padding);
            if (IsFixedLength)
                sb.Append($@"
{padding}.IsFixedLength()");
            if (MaxLength > 0 && MaxLength != int.MaxValue)
                sb.Append($@"
{padding}.HasMaxLength({MaxLength})");
        }
    }

    public class StringFieldModel : LengthFieldModel<string>
    {
        public StringFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword,
            IList<SqlTypeParameter> propertyTypeArguments) : base(modeler,property, propertyTypeKeyword, propertyTypeArguments)
        {
            switch (propertyTypeKeyword)
            {
                
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                    IsFixedLength = true;
                    MaxLength = property.MaxLengthSpecified ? property.MaxLength : 0;
                    return;
                case "varchar":
                case "nvarchar":
                    IsFixedLength = false;
                    MaxLength = property.MaxLengthSpecified ? property.MaxLength : 0;
                    return;
            }
        }

    }
    public sealed class BooleanFieldModel : FieldModel<bool>
    {
        public BooleanFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments) : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {

        }

    }


    public sealed class ByteArrayFieldModel : LengthFieldModel<byte[]>
    {
        public ByteArrayFieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword,
            IList<SqlTypeParameter> propertyTypeArguments) : base(modeler,property, propertyTypeKeyword, propertyTypeArguments)
        {
            switch (propertyTypeKeyword)
            {
                case "timestamp":
                case "rowversion":
                    IsFixedLength = true;
                    MaxLength = property.MaxLengthSpecified ? property.MaxLength : 8;
                    IsRowVersion = true;
                    return;
                case "binary":
                    IsFixedLength = true;
                    MaxLength = property.MaxLengthSpecified ? property.MaxLength : 1;
                    return;
                case "varbinary":
                    IsFixedLength = false;
                    MaxLength = property.MaxLengthSpecified
                        ? property.MaxLength
                        : int.MaxValue;
                    if (propertyTypeArguments.All(pt => pt.ConstantValue != SqlTypeParameter.Constant.Max)) return;
                    MaxLength = int.MaxValue;
                    return;
                case "image":
                    IsFixedLength = false;
                    MaxLength = int.MaxValue;
                    return;
            }
            /*
            this.Property(t => t.RowVersion)
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();
            */
        }


        public bool IsRowVersion { get; }

        protected override void WriteCommands(StringBuilder sb, string padding)
        {
            base.WriteCommands(sb, padding);
            if (IsRowVersion)
                sb.Append($@"
{padding}.IsRowVersion()");
        }
    }

    public abstract class FieldModel<T> : FieldModel
    {
        protected FieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments)
            : base(modeler, property, propertyTypeKeyword, propertyTypeArguments)
        {
            FieldType = typeof(T);
        }

    }

    public abstract class FieldModel
    {
        protected FieldModel(Modeler modeler, SchemaEntityTypeProperty property, string propertyTypeKeyword, IList<SqlTypeParameter> propertyTypeArguments)
        {
            ColumnName = property.Name;
            StoreGeneratedPattern = property.StoreGeneratedPattern;
            Nullable = !property.NullableSpecified||property.Nullable;

            FieldName = modeler.SqlToCodeName(ColumnName);

            ColumnType =
                $"{propertyTypeKeyword}{propertyTypeArguments.MapZeroOneOrMany(() => "", pt => $"({pt})",pts=>$"({string.Join(", ",pts)})")}";
        }


        internal StringBuilder ToString(StringBuilder sb)
        {
            sb.Append($"{ColumnName} {ColumnType} {(Nullable ? "NULL" : "NOT NULL")}");
            return sb;
        }

        public string FieldName { get; }
        public Type FieldType { get; protected set; }


        public string ColumnType { get; }
        public string ColumnName { get; }

        public bool Nullable { get; }

        public StoreGeneratedPattern StoreGeneratedPattern { get; }
        public void WritePropertyConfiguration(StringBuilder sb, int indent)
        {
            var padding = "".PadLeft(4 * indent, ' ');
            
            sb.Append($@"
{padding}Property(t=>t.{FieldName})");

            padding = padding.PadLeft(4, ' ');
            sb.Append($@"
{padding}.HasColumnName(""{ColumnName}"")");
            if (!Nullable)
                sb.Append($@"
{padding}.IsRequired()");

            WriteCommands(sb,padding);

            sb.AppendLine(";");
        }

        protected virtual void WriteCommands(StringBuilder sb, string padding) { }

        public override string ToString()
        {
            return ToString(new StringBuilder()).ToString();
        }

        public static IEnumerable<FieldModel> CreateFields(Modeler modeler)
        {
            
            foreach (var entityTypeProperty in modeler.EntityType.Property)
            {
                var propertyTypeKeyword =
                    new string(entityTypeProperty.Type.Trim().ToLower().TakeWhile(char.IsLetterOrDigit).ToArray());
                var propertyTypeArguments = SqlTypeParameter.ParseArgs(entityTypeProperty.Type
                    .Substring(propertyTypeKeyword.Length)
                    .Trim());
                if (propertyTypeArguments.Count == 0
                    && entityTypeProperty.MaxLengthSpecified)
                {
                    propertyTypeArguments.Add(entityTypeProperty.MaxLength);
                    //Debugger.Break();
                }
                
                switch (propertyTypeKeyword)
                {
                    case "bit":
                        yield return new BooleanFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;
                    case "decimal":
                    case "money":
                    case "numeric":
                    case "smallmoney":
                        yield return new DecimalFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;
                    case "binary":
                    case "image":
                    case "rowversion":
                    case "timestamp":
                    case "varbinary":
                        yield return new ByteArrayFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;

                    case "char":
                    case "nchar":
                    case "text":
                    case "ntext":
                    case "varchar":
                    case "nvarchar":
                        yield return new StringFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;

                    case "date":
                    case "datetime":
                    case "datetime2":
                    case "smalldatetime":
                        yield return new DateTimeFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;
                    case "datetimeoffset":
                        yield return new DateTimeOffsetFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;
                        
                    case "uniqueidentifier":
                        yield return new GuidFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;

                    case "tinyint":
                        yield return new ByteFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;
                    case "smallint":
                        yield return new Int16FieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;
                    case "int":
                        yield return new Int32FieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;
                    case "bigint":
                        yield return new Int64FieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;

                    case "float":
                        yield return new DoubleFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;
                    case "real":
                        yield return new SingleFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;
                    case "time":
                        yield return new TimeSpanFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;

                    case "xml":
                        yield return new XmlFieldModel(modeler, entityTypeProperty, propertyTypeKeyword, propertyTypeArguments);
                        continue;

                    default:
                        Debugger.Break();
                        throw new NotSupportedException(entityTypeProperty.Type + " is unsupported");
                }
            }
        }


        public StringBuilder WriteProperty(StringBuilder sb, int indent)
            => sb.Append($"public {FieldType.Name}{(FieldType.IsValueType && Nullable ? "?" : "")} {FieldName} {{ get; set; }}");
    }

    public struct SqlTypeParameter : IEquatable<SqlTypeParameter>
    {
        public static readonly SqlTypeParameter Invalid = new SqlTypeParameter(Constant.Invalid);
        public static readonly SqlTypeParameter Unspecified = new SqlTypeParameter(Constant.Unspecified);
        public static readonly SqlTypeParameter Max = new SqlTypeParameter(Constant.Max);

        public bool IsConstant => ConstantValue != Constant.Integer;

        public readonly Constant ConstantValue;
        public readonly int Value;

        private SqlTypeParameter(int value)
        {
            Value = value;
            ConstantValue = Constant.Integer;
        }

        private SqlTypeParameter(Constant constant)
        {
            ConstantValue = constant;
            Value = 0;
        }

        public static implicit operator SqlTypeParameter(int value) => new SqlTypeParameter(value);
        public static implicit operator SqlTypeParameter(Constant value)
        {
            if (value == Constant.Integer) throw new Exception("Invalid SqlTypeParameter cast.");
            return new SqlTypeParameter(value);
        }

        public static implicit operator SqlTypeParameter(int? value) => value == null ? Unspecified : new SqlTypeParameter((int)value);

        public static SqlTypeParameter Parse(string arg)
        {
            if (arg.Length == 0)
                return Unspecified;
            if (int.TryParse(arg, out var value))
                return new SqlTypeParameter(value);
            if (arg.ToLower() == "max")
                return Max;
            return Invalid;

        }

        public enum Constant
        {
            Invalid = -1,
            Unspecified = 0,
            Integer = 1,
            Max = int.MaxValue,
        }

        public bool Equals(SqlTypeParameter other)
        {
            switch (other.ConstantValue)
            {
                case Constant.Invalid:
                case Constant.Unspecified:
                case Constant.Max:
                    return other.ConstantValue == ConstantValue;
                case Constant.Integer:
                    return other.Value == Value;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is SqlTypeParameter other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (( ((int)ConstantValue-1) * 397)<<16) ^ Value;
            }
        }

        public static List<SqlTypeParameter> ParseArgs(string args)
        {
            return
                string.IsNullOrEmpty(args)
                ? new List<SqlTypeParameter>()
                : args
                  .Trim('(',')')
                  .Split(',')
                  .Select(Parse)
                  .ToList();
        }
    }
}