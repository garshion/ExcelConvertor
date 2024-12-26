using Bass.Tools.ExcelConvertor.Common;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bass.Tools.Core.SQLite
{
    public static class WorkData_SQLiteExtension
    {

        /// <summary>
        /// Create SQLite Table Query
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetSQLiteCreateTableQuery(this WorkData data)
        {
            if (null == data)
                return string.Empty;

            if (data.HeaderInfo.Count == 0)
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append($"CREATE TABLE IF NOT EXISTS {data.SheetName} (");


            List<string> pkColumnList = new List<string>();
            foreach (var header in data.HeaderInfo)
            {
                if (header.PrimaryKey)
                    pkColumnList.Add(header.ColumnName);
            }

            // Column Setting
            bool bFirst = true;
            foreach (var header in data.HeaderInfo)
            {
                if (bFirst)
                {
                    bFirst = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(header.ColumnName);
                sb.Append(" ");
                sb.Append(header.DataType.GetTypeString(ETargetType.SQLite));
            }

            // Primary Key Setting
            bFirst = true;
            if (pkColumnList.Count > 0)
            {
                sb.Append(", PRIMARY KEY (");
                foreach (var pk in pkColumnList)
                {
                    if (bFirst)
                    {
                        bFirst = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    sb.Append(pk);
                }
                sb.Append(")");
            }
            sb.Append(");");

            return sb.ToString();
        }

        public static string GetSQLiteInsertQuery(this WorkData data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"INSERT INTO {data.SheetName} (");

            bool bFirst = true;
            foreach (var header in data.HeaderInfo)
            {
                if (bFirst)
                {
                    bFirst = false;
                }
                else
                {
                    sb.Append(", ");
                }
                sb.Append(header.ColumnName);
            }

            sb.Append(") VALUES (");

            bFirst = true;
            foreach (var header in data.HeaderInfo)
            {
                if (bFirst)
                {
                    bFirst = false;
                }
                else
                {
                    sb.Append(", ");
                }
                sb.Append($"@{header.ColumnName}");
            }

            sb.Append(");");
            return sb.ToString();
        }





    }
}
