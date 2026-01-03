using Bass.Tools.Config;
using System.Text.RegularExpressions;

namespace Bass.Tools.ExcelConvertor.Common
{
    /// <summary>
    /// 데이터 처리에 사용되는 데이터 타입. <br/>
    /// Data type used for data processing.<br/>
    /// </summary>
    public enum EDataType : int
    {
        None = 0,

        Int8,
        Int16,
        Int32,
        Int64,

        Float,
        Double,

        String,

        DateTime,
        Date,

        Bool,

        Max,
    }

    /// <summary>
    /// 출력 대상 종류. <br/>
    /// Export Target Type <br/>
    /// </summary>
    public enum ETargetType : int
    {
        None = 0,

        SQLite,
        MSSQL,
        MySQL,
        CSharp,
        CPlusPlus,

        Max,
    }


    public static class Enums_Extension
    {
        public static bool IsValid(this EDataType type)
        {
            switch (type)
            {
                case EDataType.Int8:
                case EDataType.Int16:
                case EDataType.Int32:
                case EDataType.Int64:
                case EDataType.Float:
                case EDataType.Double:
                case EDataType.String:
                case EDataType.DateTime:
                case EDataType.Date:
                case EDataType.Bool:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsValid(this ETargetType type)
        {
            switch (type)
            {
                case ETargetType.SQLite:
                case ETargetType.MSSQL:
                case ETargetType.MySQL:
                case ETargetType.CSharp:
                case ETargetType.CPlusPlus:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 대상이 프로그래밍 언어 타입인지 확인합니다. <br/>
        /// Checks if the target is a programming language type. <br/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsProgrammingLanguageType(this ETargetType type)
        {
            switch (type)
            {
                case ETargetType.CSharp:
                case ETargetType.CPlusPlus:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Excel 에 정의된 타입으로부터 변환할 타입과 크기를 가져옵니다. <br/>
        /// Gets the type and size to convert from a type defined in Excel. <br/>
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        public static DataType ToDataType(this string strType)
        {
            switch (strType.ToLower())
            {
                case "int8":
                case "tinyint":
                case "byte":
                    return new DataType(EDataType.Int8, sizeof(byte));
                case "int16":
                case "short":
                case "smallint":
                    return new DataType(EDataType.Int16, sizeof(short));
                case "int32":
                case "int":
                    return new DataType(EDataType.Int32, sizeof(int));
                case "int64":
                case "long":
                case "bigint":
                    return new DataType(EDataType.Int64, sizeof(long));
                case "float":
                case "single":
                case "float32":
                    return new DataType(EDataType.Float, sizeof(float));
                case "double":
                case "float64":
                case "real":
                    return new DataType(EDataType.Double, sizeof(double));
                case "string":
                case "text":
                    return new DataType(EDataType.String, 0);
                case "datetime":
                    return new DataType(EDataType.DateTime, 22);    // YYYY-MM-DD HH:MM:SS.SSS 
                case "date":
                    return new DataType(EDataType.Date, 10);        // YYYY-MM-DD
                case "bool":
                case "boolean":
                case "bit":
                    return new DataType(EDataType.Bool, sizeof(bool));
                default:
                    break;
            }

            // varchar pattern like nvarchar(10) varchar(20).
            string pattern = @"(n?varchar)\((\d+)\)";
            var match = Regex.Match(strType, pattern);

            if (match.Success)
            {
                try
                {
                    // ex) group[0] : varchar(10), group[1] : varchar, group[2] : 10
                    string num = match.Groups[2].Value;

                    if (!int.TryParse(num, out int size))
                        return new DataType(); // invalid data type

                    if (size <= 0)
                        return new DataType(); // invalid size data

                    return new DataType(EDataType.String, size);
                }
                catch
                {
                }
            }

            return new DataType();  // invalid data type
        }

        /// <summary>
        /// 해당 타입에 해당되는 프로그래밍 언어 타입의 기본값을 가져옵니다. <br/>
        /// Gets the default value for the programming language type corresponding to the type. <br/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetProgrammingDefaultValue(this EDataType type, ETargetType target)
        {
            if (!target.IsProgrammingLanguageType())
                return string.Empty;    // Not Programming Language Type

            switch (type)
            {
                case EDataType.Int8:
                case EDataType.Int16:
                case EDataType.Int32:
                case EDataType.Int64:
                    return "0";
                case EDataType.Float:
                    return "0.0f";
                case EDataType.Double:
                    return "0.0";
                case EDataType.Bool:
                    return "false";
                case EDataType.String:
                    {
                        switch (target)
                        {
                            case ETargetType.CSharp:
                                return "string.Empty";
                            case ETargetType.CPlusPlus:
                                return _GetCppStringDefaultValue();
                            default:
                                break;
                        }
                    }
                    break;
                case EDataType.DateTime:
                case EDataType.Date:
                    {
                        switch (target)
                        {
                            case ETargetType.CSharp:
                                return "DateTime.MinValue";
                            case ETargetType.CPlusPlus:
                                return _GetCppStringDefaultValue();
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            return string.Empty;    // Invalid type
        }


        /// <summary>
        /// 대상에 적합한 데이터 유형 문자열로 대상 유형을 변환합니다. <br/>
        /// Converts the type to a string of the appropriate data type for the target.<br/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string ToTargetDataType(this EDataType type, ETargetType target)
        {
            if (!type.IsValid()
                || !target.IsValid())
                return string.Empty;

            switch (target)
            {
                case ETargetType.SQLite:
                    switch (type)
                    {
                        case EDataType.Int8:
                            return "INTEGER";
                        case EDataType.Int16:
                            return "INTEGER";
                        case EDataType.Int32:
                            return "INTEGER";
                        case EDataType.Int64:
                            return "INTEGER";
                        case EDataType.Float:
                            return "REAL";
                        case EDataType.Double:
                            return "REAL";
                        case EDataType.String:
                            return "TEXT";
                        case EDataType.DateTime:
                            return "TEXT";
                        case EDataType.Date:
                            return "TEXT";
                        case EDataType.Bool:
                            return "INTEGER";
                        default:
                            break;
                    }
                    break;
                case ETargetType.MySQL:
                    {
                        switch (type)
                        {
                            case EDataType.Int8:
                                return "TINYINT";
                            case EDataType.Int16:
                                return "SMALLINT";
                            case EDataType.Int32:
                                return "INT";
                            case EDataType.Int64:
                                return "BIGINT";
                            case EDataType.Float:
                                return "FLOAT";
                            case EDataType.Double:
                                return "DOUBLE";
                            case EDataType.String:
                                return "VARCHAR";
                            case EDataType.DateTime:
                                return "DATETIME";
                            case EDataType.Date:
                                return "DATE";
                            case EDataType.Bool:
                                return "BIT";
                            default:
                                break;
                        }
                    }
                    break;
                case ETargetType.MSSQL:
                    {
                        switch (type)
                        {
                            case EDataType.Int8:
                                return "TINYINT";
                            case EDataType.Int16:
                                return "SMALLINT";
                            case EDataType.Int32:
                                return "INT";
                            case EDataType.Int64:
                                return "BIGINT";
                            case EDataType.Float:
                                return "FLOAT";
                            case EDataType.Double:
                                return "REAL";
                            case EDataType.String:
                                return "NVARCHAR";
                            case EDataType.DateTime:
                                return "DATETIME";
                            case EDataType.Date:
                                return "DATE";
                            case EDataType.Bool:
                                return "BIT";
                            default:
                                break;
                        }
                    }
                    break;
                case ETargetType.CSharp:
                    {
                        switch (type)
                        {
                            case EDataType.Int8:
                                return "sbyte";
                            case EDataType.Int16:
                                return "short";
                            case EDataType.Int32:
                                return "int";
                            case EDataType.Int64:
                                return "long";
                            case EDataType.Float:
                                return "float";
                            case EDataType.Double:
                                return "double";
                            case EDataType.String:
                                return "string";
                            case EDataType.DateTime:
                                return "DateTime";
                            case EDataType.Date:
                                return "Date";
                            case EDataType.Bool:
                                return "bool";
                            default:
                                break;
                        }
                    }
                    break;
                case ETargetType.CPlusPlus:
                    {
                        switch (type)
                        {
                            case EDataType.Int8:
                                return "char";
                            case EDataType.Int16:
                                return "short";
                            case EDataType.Int32:
                                return "int";
                            case EDataType.Int64:
                                return "long long";
                            case EDataType.Float:
                                return "float";
                            case EDataType.Double:
                                return "double";
                            case EDataType.String:
                                return _GetCppStringTypeName();
                            case EDataType.DateTime:
                                return _GetCppStringTypeName();
                            case EDataType.Date:
                                return _GetCppStringTypeName();
                            case EDataType.Bool:
                                return "bool";
                            default:
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }

            return string.Empty;    // invalid target or type
        }

        private static string _GetCppStringTypeName()
        {
            switch (ConfigManager.Setting.CppStringType)
            {
                case ECppStringType.StdString:
                    return "std::string";
                case ECppStringType.StdWString:
                    return "std::wstring";
                case ECppStringType.StdU8String:
                    return "std::u8string";
                default:
                    return "std::wstring";
            }
        }

        private static string _GetCppStringDefaultValue()
        {
            switch (ConfigManager.Setting.CppStringType)
            {
                case ECppStringType.StdString:
                    return "std::string()";
                case ECppStringType.StdWString:
                    return "std::wstring()";
                case ECppStringType.StdU8String:
                    return "std::u8string()";
                default:
                    return "std::wstring()";
            }
        }

    }
}
