using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bass.Tools.ExcelConvertor.Common
{
    /// <summary>
    /// 프로그램에서 사용하는 데이터 타입
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
    /// 출력 타겟 종류
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
        /// Excel 에 정의된 타입으로무터 변환할 타입과 크기를 가져옵니다.
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
                    return new DataType(EDataType.Date, 10);    // YYYY-MM-DD
                case "bool":
                case "boolean":
                case "bit":
                    return new DataType(EDataType.Bool, sizeof(bool));
                default:
                    break;
            }

            // nvarchar(10) varchar(20) 형태의 문자열인 경우
            string pattern = @"(n?varchar)\((\d+)\)";
            var match = Regex.Match(strType, pattern);
            if (match.Success)
            {
                try
                {
                    string num = match.Groups[2].Value;

                    // 숫자가 아닌 경우
                    if (!int.TryParse(num, out int size))
                        return new DataType();

                    // 비정상 크기
                    if (size <= 0)
                        return new DataType();

                    return new DataType(EDataType.String, size);
                }
                catch
                {
                    // 오류 발생시 아래에서 처리
                }
            }

            return new DataType();
        }


        public static string GetProgrammingDefaultValue(this EDataType type, ETargetType target)
        {
            switch (target)
            {
                case ETargetType.CSharp:
                case ETargetType.CPlusPlus:
                    break;
                default:
                    return string.Empty;
            }

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
                                return "std::string()";
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
                                return "std::string()";
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            return string.Empty;
        }


        /// <summary>
        /// 데이터 타입을 대상 타입에 맞는 자료형 문자열로 변환합니다.
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
                                return "std::string";
                            case EDataType.DateTime:
                                return "std::string";
                            case EDataType.Date:
                                return "std::string";
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

            return string.Empty;
        }

    }
}
