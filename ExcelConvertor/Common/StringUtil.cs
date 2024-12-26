using System.Text.RegularExpressions;

namespace Bass.Tools.Common
{
    public static class StringUtil
    {
        private const int MAX_DATABASE_COLUME_NAME_LENGTH = 30;

        /// <summary>
        /// 엑셀 파일에서 첫번째 열의 값을 확인하여 해당 행를 무시해야 하는지 검사합니다. <br/>
        /// Check the values ​​in the first column of an Excel file to determine whether to ignore rows. <br/>
        /// </summary>
        /// <param name="firstColumnValue"></param>
        /// <returns></returns>
        public static bool IsIgnoreLine(this string firstColumnValue)
        {
            if (string.IsNullOrWhiteSpace(firstColumnValue))
                return true;    // null or empty. ignore.

            firstColumnValue = firstColumnValue.Trim();
            if (string.IsNullOrEmpty(firstColumnValue))
                return true;    // empty. ignore.

            if (firstColumnValue[0] == '#')
                return true;    // comment character. ignore.

            return false;
        }


        /// <summary>
        /// 프로그래밍 언어에서 클래스 이름으로 사용 가능한지 검사합니다. <br/>
        /// Check if the class name is available for programming language. <br/>
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static bool IsValidClassName(this string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                return false;

            return Regex.IsMatch(className, @"^[a-zA-Z_][a-zA-Z0-9_]*$");
        }

        /// <summary>
        /// 데이터베이스 컬럼명으로 사용 가능한지 검사합니다. <br/>
        /// Check if the database column name is available. <br/>
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool IsValidDatabaseColumnName(this string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                return false;

            if (columnName.Length > MAX_DATABASE_COLUME_NAME_LENGTH)
                return false;   // column name length too long

            return Regex.IsMatch(columnName, @"^[a-zA-Z_][a-zA-Z0-9_]*$");
        }

    }
}
