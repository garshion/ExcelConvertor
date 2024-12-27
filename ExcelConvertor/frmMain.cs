using Bass.Tools.Config;
using Bass.Tools.Core;
using Bass.Tools.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Bass.Tools.ExcelConvertor
{
    public partial class frmMain : Form
    {
        private bool mSettingLock = false;
        private bool mAllControlEnable = true;

        private ConvertEngine mConvertEngine = new ConvertEngine();

        public frmMain()
        {
            InitializeComponent();
            _AddControlEvent();

            ConfigManager.Load();
            _OnLoadConfig();
            _UpdateControlEnable();

#if !DEBUG
            btnShowLog.Visible = false;
#endif

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

            _ExcelFileFolderRefresh();

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
            btnExcelFileListRefresh.Click += BtnExcelFileListRefresh_Click;
            btnExcelFileFolderOpen.Click += BtnExcelFileFolderOpen_Click;

            btnBrowseExcelFileFolder.Click += BtnBrowseExcelFileFolder_Click;
            btnExcelSelectAll.Click += BtnExcelSelectAll_Click;
            btnExcelDeselectAll.Click += BtnExcelDeselectAll_Click;
            btnOpenExportFolder.Click += BtnOpenExportFolder_Click;
            btnBrowseExportFolder.Click += BtnBrowseExportFolder_Click;
            btnShowLog.Click += BtnShowLog_Click;
            btnConvert.Click += BtnConvert_Click;

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

        #region Button Click Event

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            _ApplyControlEnable(false);

            if (!Logger.DeleteLogFile())
            {
                MessageBox.Show("Delete Log File Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ApplyControlEnable(true);
                return;
            }

            List<string> workFileList = new List<string>();
            {
                foreach (var item in checkedListExistsExcelFiles.CheckedItems)
                {
                    workFileList.Add(item.ToString());
                }
            }

            if (workFileList.Count == 0)
            {
                MessageBox.Show("No Excel Files Selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ApplyControlEnable(true);
                return;
            }

            mConvertEngine.Process(workFileList);
            Logger.SaveLog();
            _ApplyControlEnable(true);

            MessageBox.Show("Convert Complete.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnShowLog_Click(object sender, EventArgs e)
        {
            if (File.Exists(Logger.LOG_FILE_NAME))
            {
                Process.Start("notepad.exe", Logger.LOG_FILE_NAME);
            }
        }

        private void BtnBrowseExportFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (Directory.Exists(txtExportFolder.Text))
            {
                dlg.SelectedPath = txtExportFolder.Text;
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (txtExcelFileFolder.Text != dlg.SelectedPath)
                    txtExportFolder.Text = dlg.SelectedPath;
            }
        }

        private void BtnOpenExportFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtExportFolder.Text))
            {
                Process.Start("explorer.exe", txtExportFolder.Text);
            }
        }

        private void BtnExcelDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListExistsExcelFiles.Items.Count; i++)
            {
                checkedListExistsExcelFiles.SetItemChecked(i, false);
            }
        }

        private void BtnExcelSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListExistsExcelFiles.Items.Count; i++)
            {
                checkedListExistsExcelFiles.SetItemChecked(i, true);
            }
        }

        private void BtnBrowseExcelFileFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (Directory.Exists(txtExcelFileFolder.Text))
            {
                dlg.SelectedPath = txtExcelFileFolder.Text;
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (txtExcelFileFolder.Text != dlg.SelectedPath)
                {
                    txtExcelFileFolder.Text = dlg.SelectedPath;
                    _ExcelFileFolderRefresh();
                }
            }
        }

        private void BtnExcelFileFolderOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtExcelFileFolder.Text))
            {
                Process.Start("explorer.exe", txtExcelFileFolder.Text);
            }
        }

        private void BtnExcelFileListRefresh_Click(object sender, EventArgs e)
        {
            _ExcelFileFolderRefresh();
        }

        #endregion  // Button Click Event


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

        #endregion // form Control Event Function


        #region Functions

        private void _ExcelFileFolderRefresh()
        {
            if (!Directory.Exists(txtExcelFileFolder.Text))
                return;

            checkedListExistsExcelFiles.Items.Clear();
            string[] xlsxFiles = Directory.GetFiles(txtExcelFileFolder.Text, "*.xlsx", SearchOption.TopDirectoryOnly);
            string[] xlsFiles = Directory.GetFiles(txtExcelFileFolder.Text, "*.xls", SearchOption.TopDirectoryOnly);

            List<string> files = new List<string>();
            files.AddRange(xlsxFiles);
            files.AddRange(xlsFiles);
            files.Sort();

            foreach (string file in files)
            {
                checkedListExistsExcelFiles.Items.Add(Path.GetFileName(file), CheckState.Checked);
            }
        }



        #endregion // Functions



    }
}
