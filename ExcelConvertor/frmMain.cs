using Bass.Tools.Config;
using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Bass.Tools.ExcelConvertor
{
    public partial class frmMain : Form
    {
        private bool mSettingLock = false;

        private bool mAllControlEnable = true;




        public frmMain()
        {
            InitializeComponent();
            _AddControlEvent();

            ConfigManager.Load();
            _OnLoadConfig();
        }

        #region Config Load/Save

        private void _OnLoadConfig()
        {
            mSettingLock = true;
            txtExcelFileFolder.Text = ConfigManager.Setting.ExcelFileFolder;
            txtExportFolder.Text = ConfigManager.Setting.ExportFolder;
            txtNamespaceString.Text = ConfigManager.Setting.NamespaceString;

            checkCreateSQLiteDB.Checked = ConfigManager.Setting.CreateSQLiteDB;
            checkCreateMySQLScheme.Checked = ConfigManager.Setting.CreateMySQLScheme;
            checkCreateMSSQLScheme.Checked = ConfigManager.Setting.CreateMSSQLScheme;
            checkCreateDataInsertScript.Checked = ConfigManager.Setting.CreateDataInsertScript;
            checkUseNamespace.Checked = ConfigManager.Setting.UseNamespace;
            checkExportCSSource.Checked = ConfigManager.Setting.ExportCSSourceCode;
            checkExportCPPSource.Checked = ConfigManager.Setting.ExportCPPSourceCode;

            if (ConfigManager.Setting.SQLiteDBFileOption == EExportFileOption.SingleFile)
                radioSQLiteDBFileExportSingle.Checked = true;
            else
                radioSQLiteDBFileExportEachFile.Checked = true;

            if (ConfigManager.Setting.DatabaseScriptFileOption == EExportFileOption.SingleFile)
                radioDBScriptFileExportSingle.Checked = true;
            else
                radioDBScriptFileExportEachFile.Checked = true;

            if (ConfigManager.Setting.SourceCodeFileOption == EExportFileOption.SingleFile)
                radioSourceCodeFileExportSingle.Checked = true;
            else
                radioSourceCodeFileExportEachFile.Checked = true;

            if (ConfigManager.Setting.SourceCodeDataOption == ESourceCodeDataOption.Class)
                radioUseClass.Checked = true;
            else
                radioUseStruct.Checked = true;

            mSettingLock = false;
        }

        #endregion


        #region Form Control Enable/Disable

        private void _ApplyControlEnable(bool enable)
        {
            if (mAllControlEnable == enable)
                return;

            mAllControlEnable = enable;

            txtExcelFileFolder.Enabled = enable;
            txtExportFolder.Enabled = enable;
            btnBrowseExcelFileFolder.Enabled = enable;
            btnBrowseExportFolder.Enabled = enable;
            btnExcelFileFolderOpen.Enabled = enable;
            btnExcelFileListRefresh.Enabled = enable;
            btnExcelSelectAll.Enabled = enable;
            btnExcelDeselectAll.Enabled = enable;
            btnOpenExportFolder.Enabled = enable;
            btnShowLog.Enabled = enable;
            btnConvert.Enabled = enable;
            checkCreateSQLiteDB.Enabled = enable;
            checkCreateMySQLScheme.Enabled = enable;
            checkCreateMSSQLScheme.Enabled = enable;
            checkCreateDataInsertScript.Enabled = enable;
            checkUseNamespace.Enabled = enable;
            checkExportCSSource.Enabled = enable;
            checkExportCPPSource.Enabled = enable;
            radioSQLiteDBFileExportSingle.Enabled = enable;
            radioSQLiteDBFileExportEachFile.Enabled = enable;
            radioDBScriptFileExportSingle.Enabled = enable;
            radioDBScriptFileExportEachFile.Enabled = enable;
            radioSourceCodeFileExportSingle.Enabled = enable;
            radioSourceCodeFileExportEachFile.Enabled = enable;
            radioUseClass.Enabled = enable;
            radioUseStruct.Enabled = enable;
            txtNamespaceString.Enabled = enable;

            if (enable)
                _UpdateControlEnable();
        }

        private void _UpdateControlEnable()
        {
            if (!mAllControlEnable)
                return;

            // SQLite Database Option
            if (checkCreateSQLiteDB.Checked)
            {
                radioSQLiteDBFileExportSingle.Enabled = true;
                radioSQLiteDBFileExportEachFile.Enabled = true;
            }
            else
            {
                radioSQLiteDBFileExportSingle.Enabled = false;
                radioSQLiteDBFileExportEachFile.Enabled = false;
            }

            // Database Script Option
            if (checkCreateMySQLScheme.Checked
                || checkCreateMSSQLScheme.Checked
                || checkCreateDataInsertScript.Checked)
            {
                radioDBScriptFileExportSingle.Enabled = true;
                radioDBScriptFileExportEachFile.Enabled = true;
            }
            else
            {
                radioDBScriptFileExportSingle.Enabled = false;
                radioDBScriptFileExportEachFile.Enabled = false;
            }

            // Namespace Option
            if (checkUseNamespace.Checked)
            {
                txtNamespaceString.Enabled = true;
            }
            else
            {
                txtNamespaceString.Enabled = false;
            }

            if (checkExportCPPSource.Checked
                || checkExportCSSource.Checked)
            {
                radioSourceCodeFileExportSingle.Enabled = true;
                radioSourceCodeFileExportEachFile.Enabled = true;

                radioUseClass.Enabled = true;
                radioUseStruct.Enabled = true;
            }
            else
            {
                radioSourceCodeFileExportSingle.Enabled = false;
                radioSourceCodeFileExportEachFile.Enabled = false;

                radioUseClass.Enabled = false;
                radioUseStruct.Enabled = false;
            }

        }



        #endregion



        #region form Control Event Function

        private void _AddControlEvent()
        {
            // Button Actions
            btnExcelFileListRefresh.Click += _ApplySetting;
            btnExcelFileFolderOpen.Click += _ApplySetting;
            btnBrowseExcelFileFolder.Click += _ApplySetting;
            btnExcelSelectAll.Click += _ApplySetting;
            btnExcelDeselectAll.Click += _ApplySetting;
            btnOpenExportFolder.Click += _ApplySetting;
            btnBrowseExportFolder.Click += _ApplySetting;
            btnShowLog.Click += _ApplySetting;
            btnConvert.Click += _ApplySetting;

            // CheckBox Actions
            checkCreateSQLiteDB.CheckedChanged += _ApplySetting;
            checkCreateMySQLScheme.CheckedChanged += _ApplySetting;
            checkCreateMSSQLScheme.CheckedChanged += _ApplySetting;
            checkCreateDataInsertScript.CheckedChanged += _ApplySetting;
            checkUseNamespace.CheckedChanged += _ApplySetting;
            checkExportCSSource.CheckedChanged += _ApplySetting;
            checkExportCPPSource.CheckedChanged += _ApplySetting;

            // RadioButton Actions
            radioDBScriptFileExportEachFile.CheckedChanged += _ApplySetting;
            radioDBScriptFileExportSingle.CheckedChanged += _ApplySetting;
            radioSourceCodeFileExportEachFile.CheckedChanged += _ApplySetting;
            radioSourceCodeFileExportSingle.CheckedChanged += _ApplySetting;
            radioSQLiteDBFileExportEachFile.CheckedChanged += _ApplySetting;
            radioSQLiteDBFileExportSingle.CheckedChanged += _ApplySetting;
            radioUseClass.CheckedChanged += _ApplySetting;
            radioUseStruct.CheckedChanged += _ApplySetting;

            // textBox Actions
            txtNamespaceString.TextChanged += _ApplySetting;
            txtExcelFileFolder.TextChanged += _ApplySetting;
            txtExportFolder.TextChanged += _ApplySetting;
        }


        private void _ApplySetting(object sender, EventArgs e)
        {
            if (mSettingLock)
                return;

            mSettingLock = true;

            ConfigManager.Setting.ExcelFileFolder = txtExcelFileFolder.Text;
            ConfigManager.Setting.ExportFolder = txtExportFolder.Text;
            ConfigManager.Setting.CreateSQLiteDB = checkCreateSQLiteDB.Checked;

            if (radioSQLiteDBFileExportSingle.Checked)
                ConfigManager.Setting.SQLiteDBFileOption = EExportFileOption.SingleFile;
            else
                ConfigManager.Setting.SQLiteDBFileOption = EExportFileOption.EachFile;

            ConfigManager.Setting.CreateMySQLScheme = checkCreateMySQLScheme.Checked;
            ConfigManager.Setting.CreateMSSQLScheme = checkCreateMSSQLScheme.Checked;
            ConfigManager.Setting.CreateDataInsertScript = checkCreateDataInsertScript.Checked;

            if (radioDBScriptFileExportSingle.Checked)
                ConfigManager.Setting.DatabaseScriptFileOption = EExportFileOption.SingleFile;
            else
                ConfigManager.Setting.DatabaseScriptFileOption = EExportFileOption.EachFile;

            ConfigManager.Setting.UseNamespace = checkUseNamespace.Checked;
            ConfigManager.Setting.NamespaceString = txtNamespaceString.Text;
            ConfigManager.Setting.ExportCSSourceCode = checkExportCSSource.Checked;
            ConfigManager.Setting.ExportCPPSourceCode = checkExportCPPSource.Checked;

            if (radioSourceCodeFileExportSingle.Checked)
                ConfigManager.Setting.SourceCodeFileOption = EExportFileOption.SingleFile;
            else
                ConfigManager.Setting.SourceCodeFileOption = EExportFileOption.EachFile;

            if (radioUseClass.Checked)
                ConfigManager.Setting.SourceCodeDataOption = ESourceCodeDataOption.Class;
            else
                ConfigManager.Setting.SourceCodeDataOption = ESourceCodeDataOption.Struct;


            ConfigManager.Save();

            mSettingLock = false;

            _UpdateControlEnable();
        }

        #endregion

    }
}
