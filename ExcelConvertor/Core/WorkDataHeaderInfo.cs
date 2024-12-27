using Bass.Tools.ExcelConvertor.Common;
using System;

namespace Bass.Tools.Core
{
    public class WorkDataHeaderInfo
    {
        public int ColumnIndex { get; set; } = 0;
        public string ColumnName { get; set; } = string.Empty;
        public DataType DataType { get; set; } = new DataType();
        public bool PrimaryKey { get; set; } = false;

        public bool SetData(string name, string type, int index)
        {
            char[] seps = { ' ' };
            string[] tokens = type.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            switch (tokens.Length)
            {
                case 1:
                    {
                        var getType = tokens[0].ToDataType();
                        if (getType.Type.IsValid())
                        {
                            DataType = getType;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    break;
                case 2:
                    {
                        if (tokens[0].ToLower().Equals("pk"))
                        {
                            PrimaryKey = true;
                        }

                        var getType = tokens[1].ToDataType();
                        if (getType.Type.IsValid())
                        {
                            DataType = getType;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    break;
                default:
                    return false;
            }

            ColumnIndex = index;
            ColumnName = name;

            return true;
        }

        public bool IsValidColumnData(string colunmData)
        {
            switch (DataType.Type)
            {
                case EDataType.Int8:
                    return sbyte.TryParse(colunmData, out var _);
                case EDataType.Int16:
                    return short.TryParse(colunmData, out var _);
                case EDataType.Int32:
                    return int.TryParse(colunmData, out var _);
                case EDataType.Int64:
                    return long.TryParse(colunmData, out var _);
                case EDataType.Float:
                    return float.TryParse(colunmData, out var _);
                case EDataType.Double:
                    return double.TryParse(colunmData, out var _);
                case EDataType.String:
                    return true;
                case EDataType.Bool:
                    return bool.TryParse(colunmData, out var _);
                case EDataType.Date:
                case EDataType.DateTime:
                    return DateTime.TryParse(colunmData, out var _);
                default:
                    return false;
            }
        }
    }
}
