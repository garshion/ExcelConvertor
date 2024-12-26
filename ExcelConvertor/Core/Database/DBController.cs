using Bass.Tools.Config;
using Bass.Tools.ExcelConvertor.Common;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bass.Tools.Core.Database
{
    public class DBController : AWorkController
    {
        private const string MYSQL_EXPORT_FOLDER = "MySQL";
        private const string MSSQL_EXPORT_FOLDER = "MSSQL";
        private const string SINGLE_FILE_NAME = "ConvertDatas.sql";

        private const int MAX_INSERT_AT_ONCE = 1000;

        public override bool Process(List<WorkData> datas)
        {

            if (ConfigManager.Setting.CreateMySQLScheme)
            {
                _Process(datas, ETargetType.MySQL);
            }

            if (ConfigManager.Setting.CreateMSSQLScheme)
            {
                _Process(datas, ETargetType.MSSQL);
            }

            return true;
        }

        private void _Process(List<WorkData> datas, ETargetType type)
        {
            string exportFolder = string.Empty;
            switch (type)
            {
                case ETargetType.MySQL:
                    if (!ConfigManager.Setting.CreateMySQLScheme)
                        return;
                    exportFolder = MYSQL_EXPORT_FOLDER;
                    break;
                case ETargetType.MSSQL:
                    if (!ConfigManager.Setting.CreateMSSQLScheme)
                        return;
                    exportFolder = MSSQL_EXPORT_FOLDER;
                    break;
                default:
                    return; // Invalid Type.
            }

            CheckExportFolder(exportFolder);
            RemoveFiles(exportFolder);

            StringBuilder sb = new StringBuilder();
            foreach (var data in datas)
            {
                _DropAndCreateTable(sb, data, type);
                _InsertData(sb, data, type);

                if (ConfigManager.Setting.DatabaseScriptFileOption == EExportFileOption.EachFile)
                {
                    string fileName = Path.Combine(ConfigManager.Setting.ExportFolder, exportFolder, $"{data.SheetName}.sql");
                    File.WriteAllText(fileName, sb.ToString());
                    sb.Clear();
                }
            }

            if (ConfigManager.Setting.DatabaseScriptFileOption == EExportFileOption.SingleFile)
            {
                string fileName = Path.Combine(ConfigManager.Setting.ExportFolder, exportFolder, SINGLE_FILE_NAME);
                File.WriteAllText(fileName, sb.ToString());
            }
        }


        private void _DropAndCreateTable(StringBuilder sb, WorkData data, ETargetType type)
        {
            string tableOwner = string.Empty;
            switch (type)
            {
                case ETargetType.MySQL:
                    break;
                case ETargetType.MSSQL:
                    tableOwner = "dbo.";
                    break;
                default:
                    return; // Invalid Type.
            }

            sb.AppendLine($"DROP TABLE IF EXISTS {(tableOwner + data.SheetName).DBNaming(type)};");
            sb.AppendLine();
            sb.AppendLine($"CREATE TABLE {data.SheetName.DBNaming(type)} (");

            List<string> pkColumnList = new List<string>();
            foreach (var header in data.HeaderInfo)
            {
                if (header.PrimaryKey)
                    pkColumnList.Add(header.ColumnName);
            }

            bool bFirst = true;
            foreach (var header in data.HeaderInfo)
            {
                if (bFirst)
                    bFirst = false;
                else
                    sb.AppendLine(",");

                sb.AppendLine($"{header.ColumnName.DBNaming(type)} {header.DataType.GetTypeString(type)}");
            }

            // primary key 
            if (pkColumnList.Count > 0)
            {
                sb.Append(", PRIMARY KEY (");
                bFirst = true;
                foreach (var pk in pkColumnList)
                {
                    if (bFirst)
                        bFirst = false;
                    else
                        sb.Append(", ");
                    sb.Append(pk.DBNaming(type));
                }
                sb.AppendLine(")");
            }

            sb.AppendLine(");");
            sb.AppendLine();
        }

        private void _InsertData(StringBuilder sb, WorkData data, ETargetType type)
        {
            if (!ConfigManager.Setting.CreateDataInsertScript)
                return; // Skip Data Insert Script.

            switch (type)
            {
                case ETargetType.MySQL:
                case ETargetType.MSSQL:
                    break;
                default:
                    return; // Invalid Type.
            }

            int nAddCount = 0;

            foreach (var dataList in data.Datas)
            {
                nAddCount++;
                bool bFirst = true;

                if (nAddCount % MAX_INSERT_AT_ONCE == 1)
                {
                    if (nAddCount > 0)
                    {
                        sb.AppendLine(";");
                        sb.AppendLine();
                    }

                    sb.Append($"INSERT INTO {data.SheetName.DBNaming(type)} (");
                    bFirst = true;
                    foreach (var header in data.HeaderInfo)
                    {
                        if (bFirst)
                            bFirst = false;
                        else
                            sb.Append(", ");
                        sb.Append($"{header.ColumnName.DBNaming(type)}");
                    }
                    sb.AppendLine(") VALUES ");
                }

                if (nAddCount % MAX_INSERT_AT_ONCE != 1)
                {
                    sb.AppendLine(",");
                }

                sb.Append("(");

                bFirst = true;
                for (int i = 0; i < data.HeaderInfo.Count; i++)
                {
                    if (bFirst)
                        bFirst = false;
                    else
                        sb.Append(", ");

                    switch (data.HeaderInfo[i].DataType.Type)
                    {
                        case EDataType.String:
                        case EDataType.Date:
                        case EDataType.DateTime:
                            sb.Append($"'{dataList[i]}'");
                            break;
                        case EDataType.Bool:
                            {
                                bool bValue = false;
                                switch (type)
                                {
                                    case ETargetType.MySQL:
                                        {
                                            bool.TryParse(dataList[i], out bValue);
                                            sb.Append(bValue ? "b'1'" : "b'0'");
                                        }
                                        break;
                                    case ETargetType.MSSQL:
                                        {
                                            sb.Append(bValue ? "1" : "0");
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        default:
                            sb.Append($"{dataList[i]}");
                            break;
                    }

                }
                sb.Append(")");

                if (nAddCount % MAX_INSERT_AT_ONCE == 0)
                {
                    sb.AppendLine(";");
                }
            }

            if (nAddCount % MAX_INSERT_AT_ONCE != 0)
            {
                sb.AppendLine(";");
            }
        }


    }
}
