using System;

namespace Bass.Tools.Config
{
    /// <summary>
    /// Program File Setting
    /// </summary>
    public class ConfigData
    {
        // Excel Import
        public string ExcelFileFolder { get; set; } = string.Empty;

        // Export
        public string ExportFolder { get; set; } = string.Empty;

        // SQLite Databse Option
        public bool CreateSQLiteDB { get; set; } = true;
        public EExportFileOption SQLiteDBFileOption { get; set; } = EExportFileOption.SingleFile;


        // Database Script Option
        public bool CreateMySQLScheme { get; set; } = false;
        public bool CreateMSSQLScheme { get; set; } = false;
        public bool CreateDataInsertScript { get; set; } = false;

        public EExportFileOption DatabaseScriptFileOption { get; set; } = EExportFileOption.SingleFile;

        // Source Code Option
        public bool UseNamespace { get; set; } = false;
        public string NamespaceString { get; set; } = string.Empty;
        public bool ExportCSSourceCode { get; set; } = false;
        public bool ExportCPPSourceCode { get; set; } = false;
        public EExportFileOption SourceCodeFileOption { get; set; } = EExportFileOption.SingleFile;
        public ESourceCodeDataOption SourceCodeDataOption { get; set; } = ESourceCodeDataOption.Class;


        public ConfigData()
        {
        }

        public void SetDefault()
        {
            ExcelFileFolder = Environment.CurrentDirectory;
            ExportFolder = Environment.CurrentDirectory + "\\Export\\";
            CreateSQLiteDB = true;
            SQLiteDBFileOption = EExportFileOption.SingleFile;

            CreateMySQLScheme = false;
            CreateMSSQLScheme = false;
            CreateDataInsertScript = false;
            DatabaseScriptFileOption = EExportFileOption.SingleFile;

            UseNamespace = false;
            NamespaceString = string.Empty;
            ExportCSSourceCode = false;
            ExportCPPSourceCode = false;

            SourceCodeFileOption = EExportFileOption.SingleFile;
            SourceCodeDataOption = ESourceCodeDataOption.Class;
        }

    }
}
