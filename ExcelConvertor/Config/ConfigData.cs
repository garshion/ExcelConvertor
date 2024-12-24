using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool ExportSQLiteDB { get; set; } = true;
        public EExportFileOption SQLiteDBFileOption { get; set; } = EExportFileOption.SingleFile;


        // Database Script Option
        public bool ExportMySQLScheme { get; set; } = false;
        public bool ExportMSSQLScheme { get; set; } = false;
        public bool ExportInsertData { get; set; } = false;

        public EExportFileOption DatabaseScriptFileOption { get; set; } = EExportFileOption.SingleFile;

        // Source Code Option
        public bool UseNamespace { get; set; } = false;
        public string NamespaceData { get; set; } = string.Empty;
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
            ExportSQLiteDB = true;
            SQLiteDBFileOption = EExportFileOption.SingleFile;

            ExportMySQLScheme = false;
            ExportMSSQLScheme = false;
            ExportInsertData = false;
            DatabaseScriptFileOption = EExportFileOption.SingleFile;

            UseNamespace = false;
            NamespaceData = string.Empty;
            ExportCSSourceCode = false;
            ExportCPPSourceCode = false;

            SourceCodeFileOption = EExportFileOption.SingleFile;
            SourceCodeDataOption = ESourceCodeDataOption.Class;
        }

    }
}
