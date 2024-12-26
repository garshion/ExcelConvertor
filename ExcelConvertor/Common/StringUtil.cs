using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bass.Tools.Common
{
    public static class StringUtil
    {
        private const int MAX_DATABASE_COLUME_NAME_LENGTH = 30;

        public static bool IsIgnoreLine(this string firstColumnValue)
        {
            if (string.IsNullOrWhiteSpace(firstColumnValue))
                return true;    // null 이거나 비어있으니 무시

            firstColumnValue = firstColumnValue.Trim();
            if(string.IsNullOrEmpty(firstColumnValue))
                return true;    // 비어있으면 무시

            if(firstColumnValue[0] == '#')
                return true;    // 주석 줄이므로 무시

            return false;
        }



        public static bool IsValidClassName(this string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                return false;

            return Regex.IsMatch(className, @"^[a-zA-Z_][a-zA-Z0-9_]*$");
        }

        public static bool IsValidDatabaseColumnName(this string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                return false;

            if (columnName.Length > MAX_DATABASE_COLUME_NAME_LENGTH)
                return false;

            return Regex.IsMatch(columnName, @"^[a-zA-Z_][a-zA-Z0-9_]*$");
        }

    }
}
