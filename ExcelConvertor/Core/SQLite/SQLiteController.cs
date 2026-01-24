using Bass.Tools.Config;
using Bass.Tools.Log;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Bass.Tools.Core.SQLite
{
    public class SQLiteController : AWorkController
    {
        private const string SQLITE_EXPORT_FOLDER = "SQLite";


        public override bool Process(List<WorkData> datas)
        {
            if (!ConfigManager.Setting.CreateSQLiteDB)
                return true;    // Skip SQLite DB Process.

            if (datas.Count == 0)
                return false;   // no data.

            CheckExportFolder(SQLITE_EXPORT_FOLDER);

            if (!RemoveFiles(SQLITE_EXPORT_FOLDER))
                return false;


            foreach (var data in datas)
            {
                if (!_CreateDB(data))
                    return false;
            }

            return true;
        }


        private bool _CreateDB(WorkData data)
        {
            if (null == data)
                return false;

            if (string.IsNullOrWhiteSpace(data.SheetName))
                return false;

            string fileName;
            switch (ConfigManager.Setting.SQLiteDBFileOption)
            {
                case EExportFileOption.EachFile:
                    fileName = Path.Combine(ConfigManager.Setting.ExportFolder, SQLITE_EXPORT_FOLDER, $"{data.SheetName}.db");
                    break;
                case EExportFileOption.SingleFile:
                    var dbFileName = ConfigManager.Setting.SQLiteDBFileName;
                    if (string.IsNullOrWhiteSpace(dbFileName))
                        dbFileName = "ConvertDatas";
                    fileName = Path.Combine(ConfigManager.Setting.ExportFolder, SQLITE_EXPORT_FOLDER, $"{dbFileName}.db");
                    break;
                default:
                    return false;
            }

            string connectionString = $"Data Source=\"{fileName}\";Version=3;";

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                try
                {
                    con.Open();
                    // Create table if not exists.
                    using (var stmt = con.CreateCommand())
                    {
                        stmt.CommandText = data.GetSQLiteCreateTableQuery();
                        stmt.ExecuteNonQuery();
                    }

                    // insert datas
                    using (var tran = con.BeginTransaction())
                    {
                        using (var stmt = con.CreateCommand())
                        {
                            stmt.CommandText = data.GetSQLiteInsertQuery();
                            foreach (var rowDatas in data.Datas)
                            {
                                for (int i = 0; i < data.HeaderInfo.Count; i++)
                                {
                                    stmt.Parameters.AddWithValue($"@{data.HeaderInfo[i].ColumnName}", rowDatas[i]);
                                }
                                stmt.ExecuteNonQuery();
                                stmt.Parameters.Clear();
                            }
                        }

                        tran.Commit();
                    }
                }
                catch (Exception e)
                {
                    Logger.Log($"Create SQLite DB Error : {e.Message}");
                    Logger.Trace(e);
                    return false;
                }
            }

            return true;
        }
    }
}
