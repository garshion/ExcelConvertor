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
        public override bool Process(List<WorkData> datas)
        {
            if (!ConfigManager.Setting.CreateSQLiteDB)
                return true;    // Skip SQLite DB Process.

            if (datas.Count == 0)
                return false;   // no data.

            // Export folder check (no subfolder, direct to ExportFolder)
            if (!Directory.Exists(ConfigManager.Setting.ExportFolder))
                Directory.CreateDirectory(ConfigManager.Setting.ExportFolder);

            // Delete existing DB file before creating new one
            _DeleteExistingDBFile();

            foreach (var data in datas)
            {
                if (!_CreateDB(data))
                    return false;
            }

            return true;
        }

        private void _DeleteExistingDBFile()
        {
            try
            {
                switch (ConfigManager.Setting.SQLiteDBFileOption)
                {
                    case EExportFileOption.SingleFile:
                        var dbFileName = ConfigManager.Setting.SQLiteDBFileName;
                        if (string.IsNullOrWhiteSpace(dbFileName))
                            dbFileName = "ConvertDatas";
                        string singleFilePath = Path.Combine(ConfigManager.Setting.ExportFolder, $"{dbFileName}.db");
                        if (File.Exists(singleFilePath))
                            File.Delete(singleFilePath);
                        break;

                    case EExportFileOption.EachFile:
                        // Delete all .db files in export folder
                        string[] dbFiles = Directory.GetFiles(ConfigManager.Setting.ExportFolder, "*.db", SearchOption.TopDirectoryOnly);
                        foreach (var file in dbFiles)
                        {
                            File.Delete(file);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Logger.Log($"Delete existing DB file error: {e.Message}");
            }
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
                    fileName = Path.Combine(ConfigManager.Setting.ExportFolder, $"{data.SheetName}.db");
                    break;
                case EExportFileOption.SingleFile:
                    var dbFileName = ConfigManager.Setting.SQLiteDBFileName;
                    if (string.IsNullOrWhiteSpace(dbFileName))
                        dbFileName = "ConvertDatas";
                    fileName = Path.Combine(ConfigManager.Setting.ExportFolder, $"{dbFileName}.db");
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
