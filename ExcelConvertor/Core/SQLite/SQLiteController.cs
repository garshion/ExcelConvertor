using Bass.Tools.Config;
using Bass.Tools.Log;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bass.Tools.Core.SQLite
{
    public class SQLiteController
    {
        private const string SQLITE_EXPORT_FOLDER = "SQLite";
        private const string SQLITE_SINGLE_DB_FILE = "ConvertDatas.db";


        public bool Process(List<WorkData> datas)
        {
            if (!ConfigManager.Setting.CreateSQLiteDB)
                return true;    // Skip SQLite DB Process.

            if (datas.Count == 0)
                return false;   // no data.

            _CheckFolder();

            if (!_RemoveFiles())
                return false;


            foreach (var data in datas)
            {
                if (!_CreateDB(data))
                    return false;
            }

            return true;
        }

        private void _CheckFolder()
        {
            string exportFolder = Path.Combine(ConfigManager.Setting.ExportFolder, SQLITE_EXPORT_FOLDER);
            if (!Directory.Exists(exportFolder))
                Directory.CreateDirectory(exportFolder);
        }


        private bool _RemoveFiles()
        {
            string exportFolder = Path.Combine(ConfigManager.Setting.ExportFolder, SQLITE_EXPORT_FOLDER);
            if (!Directory.Exists(exportFolder))
                return false;

            var files = Directory.GetFiles(exportFolder);
            foreach (var file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception e)
                {
                    Logger.Log("Delete File Error : " + e.Message);
                    Logger.Trace(e);
                }
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
                    fileName = Path.Combine(ConfigManager.Setting.ExportFolder, SQLITE_EXPORT_FOLDER, SQLITE_SINGLE_DB_FILE);
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
                    // 테이블이 존재하지 않는다면 생성
                    using (var stmt = con.CreateCommand())
                    {
                        stmt.CommandText = data.GetSQLiteCreateTableQuery();
                        stmt.ExecuteNonQuery();
                    }

                    // 데이터 삽입
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
                    Logger.Log("Create SQLite DB Error : " + e.Message);
                    Logger.Trace(e);
                    return false;
                }
            }

            return true;
        }
    }
}
