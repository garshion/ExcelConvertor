namespace Bass.Tools.ExcelConvertor
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExcelDeselectAll = new System.Windows.Forms.Button();
            this.btnExcelSelectAll = new System.Windows.Forms.Button();
            this.btnExcelFileListRefresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListExistsExcelFiles = new System.Windows.Forms.CheckedListBox();
            this.btnExcelFileFolderOpen = new System.Windows.Forms.Button();
            this.btnBrowseExcelFileFolder = new System.Windows.Forms.Button();
            this.txtExcelFileFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenExportFolder = new System.Windows.Forms.Button();
            this.btnBrowseExportFolder = new System.Windows.Forms.Button();
            this.txtExportFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioSQLiteDBFileExportEachFile = new System.Windows.Forms.RadioButton();
            this.radioSQLiteDBFileExportSingle = new System.Windows.Forms.RadioButton();
            this.checkCreateSQLiteDB = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioDBScriptFileExportEachFile = new System.Windows.Forms.RadioButton();
            this.radioDBScriptFileExportSingle = new System.Windows.Forms.RadioButton();
            this.checkCreateDataInsertScript = new System.Windows.Forms.CheckBox();
            this.checkCreateMSSQLScheme = new System.Windows.Forms.CheckBox();
            this.checkCreateMySQLScheme = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioSourceCodeFileExportEachFile = new System.Windows.Forms.RadioButton();
            this.radioSourceCodeFileExportSingle = new System.Windows.Forms.RadioButton();
            this.checkExportCPPSource = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioUseClass = new System.Windows.Forms.RadioButton();
            this.radioUseStruct = new System.Windows.Forms.RadioButton();
            this.checkExportCSSource = new System.Windows.Forms.CheckBox();
            this.txtNamespaceString = new System.Windows.Forms.TextBox();
            this.checkUseNamespace = new System.Windows.Forms.CheckBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExcelDeselectAll);
            this.groupBox1.Controls.Add(this.btnExcelSelectAll);
            this.groupBox1.Controls.Add(this.btnExcelFileListRefresh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkedListExistsExcelFiles);
            this.groupBox1.Controls.Add(this.btnExcelFileFolderOpen);
            this.groupBox1.Controls.Add(this.btnBrowseExcelFileFolder);
            this.groupBox1.Controls.Add(this.txtExcelFileFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(534, 526);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel Import";
            // 
            // btnExcelDeselectAll
            // 
            this.btnExcelDeselectAll.Location = new System.Drawing.Point(111, 495);
            this.btnExcelDeselectAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcelDeselectAll.Name = "btnExcelDeselectAll";
            this.btnExcelDeselectAll.Size = new System.Drawing.Size(96, 18);
            this.btnExcelDeselectAll.TabIndex = 8;
            this.btnExcelDeselectAll.Text = "Deselect All";
            this.btnExcelDeselectAll.UseVisualStyleBackColor = true;
            // 
            // btnExcelSelectAll
            // 
            this.btnExcelSelectAll.Location = new System.Drawing.Point(9, 495);
            this.btnExcelSelectAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcelSelectAll.Name = "btnExcelSelectAll";
            this.btnExcelSelectAll.Size = new System.Drawing.Size(96, 18);
            this.btnExcelSelectAll.TabIndex = 7;
            this.btnExcelSelectAll.Text = "Select All";
            this.btnExcelSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnExcelFileListRefresh
            // 
            this.btnExcelFileListRefresh.Location = new System.Drawing.Point(432, 495);
            this.btnExcelFileListRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcelFileListRefresh.Name = "btnExcelFileListRefresh";
            this.btnExcelFileListRefresh.Size = new System.Drawing.Size(96, 18);
            this.btnExcelFileListRefresh.TabIndex = 6;
            this.btnExcelFileListRefresh.Text = "Refresh";
            this.btnExcelFileListRefresh.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Excel Files to Convert";
            // 
            // checkedListExistsExcelFiles
            // 
            this.checkedListExistsExcelFiles.FormattingEnabled = true;
            this.checkedListExistsExcelFiles.Location = new System.Drawing.Point(8, 103);
            this.checkedListExistsExcelFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListExistsExcelFiles.Name = "checkedListExistsExcelFiles";
            this.checkedListExistsExcelFiles.Size = new System.Drawing.Size(521, 388);
            this.checkedListExistsExcelFiles.TabIndex = 4;
            // 
            // btnExcelFileFolderOpen
            // 
            this.btnExcelFileFolderOpen.Location = new System.Drawing.Point(331, 64);
            this.btnExcelFileFolderOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcelFileFolderOpen.Name = "btnExcelFileFolderOpen";
            this.btnExcelFileFolderOpen.Size = new System.Drawing.Size(96, 18);
            this.btnExcelFileFolderOpen.TabIndex = 3;
            this.btnExcelFileFolderOpen.Text = "Open Folder";
            this.btnExcelFileFolderOpen.UseVisualStyleBackColor = true;
            // 
            // btnBrowseExcelFileFolder
            // 
            this.btnBrowseExcelFileFolder.Location = new System.Drawing.Point(432, 64);
            this.btnBrowseExcelFileFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowseExcelFileFolder.Name = "btnBrowseExcelFileFolder";
            this.btnBrowseExcelFileFolder.Size = new System.Drawing.Size(96, 18);
            this.btnBrowseExcelFileFolder.TabIndex = 2;
            this.btnBrowseExcelFileFolder.Text = "Browse..";
            this.btnBrowseExcelFileFolder.UseVisualStyleBackColor = true;
            // 
            // txtExcelFileFolder
            // 
            this.txtExcelFileFolder.Location = new System.Drawing.Point(8, 39);
            this.txtExcelFileFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExcelFileFolder.Name = "txtExcelFileFolder";
            this.txtExcelFileFolder.ReadOnly = true;
            this.txtExcelFileFolder.Size = new System.Drawing.Size(521, 21);
            this.txtExcelFileFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel File Folder";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenExportFolder);
            this.groupBox2.Controls.Add(this.btnBrowseExportFolder);
            this.groupBox2.Controls.Add(this.txtExportFolder);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(562, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(534, 101);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            // 
            // btnOpenExportFolder
            // 
            this.btnOpenExportFolder.Location = new System.Drawing.Point(331, 64);
            this.btnOpenExportFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenExportFolder.Name = "btnOpenExportFolder";
            this.btnOpenExportFolder.Size = new System.Drawing.Size(96, 18);
            this.btnOpenExportFolder.TabIndex = 3;
            this.btnOpenExportFolder.Text = "Open Folder";
            this.btnOpenExportFolder.UseVisualStyleBackColor = true;
            // 
            // btnBrowseExportFolder
            // 
            this.btnBrowseExportFolder.Location = new System.Drawing.Point(432, 64);
            this.btnBrowseExportFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowseExportFolder.Name = "btnBrowseExportFolder";
            this.btnBrowseExportFolder.Size = new System.Drawing.Size(96, 18);
            this.btnBrowseExportFolder.TabIndex = 2;
            this.btnBrowseExportFolder.Text = "Browse..";
            this.btnBrowseExportFolder.UseVisualStyleBackColor = true;
            // 
            // txtExportFolder
            // 
            this.txtExportFolder.Location = new System.Drawing.Point(8, 39);
            this.txtExportFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExportFolder.Name = "txtExportFolder";
            this.txtExportFolder.ReadOnly = true;
            this.txtExportFolder.Size = new System.Drawing.Size(521, 21);
            this.txtExportFolder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Export Folder";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioSQLiteDBFileExportEachFile);
            this.groupBox3.Controls.Add(this.radioSQLiteDBFileExportSingle);
            this.groupBox3.Controls.Add(this.checkCreateSQLiteDB);
            this.groupBox3.Location = new System.Drawing.Point(562, 142);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(262, 125);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SQLite Database Option";
            // 
            // radioSQLiteDBFileExportEachFile
            // 
            this.radioSQLiteDBFileExportEachFile.AutoSize = true;
            this.radioSQLiteDBFileExportEachFile.Location = new System.Drawing.Point(8, 99);
            this.radioSQLiteDBFileExportEachFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioSQLiteDBFileExportEachFile.Name = "radioSQLiteDBFileExportEachFile";
            this.radioSQLiteDBFileExportEachFile.Size = new System.Drawing.Size(112, 16);
            this.radioSQLiteDBFileExportEachFile.TabIndex = 2;
            this.radioSQLiteDBFileExportEachFile.Text = "Each Sheet File";
            this.radioSQLiteDBFileExportEachFile.UseVisualStyleBackColor = true;
            // 
            // radioSQLiteDBFileExportSingle
            // 
            this.radioSQLiteDBFileExportSingle.AutoSize = true;
            this.radioSQLiteDBFileExportSingle.Checked = true;
            this.radioSQLiteDBFileExportSingle.Location = new System.Drawing.Point(8, 79);
            this.radioSQLiteDBFileExportSingle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioSQLiteDBFileExportSingle.Name = "radioSQLiteDBFileExportSingle";
            this.radioSQLiteDBFileExportSingle.Size = new System.Drawing.Size(82, 16);
            this.radioSQLiteDBFileExportSingle.TabIndex = 1;
            this.radioSQLiteDBFileExportSingle.TabStop = true;
            this.radioSQLiteDBFileExportSingle.Text = "Single File";
            this.radioSQLiteDBFileExportSingle.UseVisualStyleBackColor = true;
            // 
            // checkCreateSQLiteDB
            // 
            this.checkCreateSQLiteDB.AutoSize = true;
            this.checkCreateSQLiteDB.Checked = true;
            this.checkCreateSQLiteDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCreateSQLiteDB.Location = new System.Drawing.Point(8, 19);
            this.checkCreateSQLiteDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkCreateSQLiteDB.Name = "checkCreateSQLiteDB";
            this.checkCreateSQLiteDB.Size = new System.Drawing.Size(122, 16);
            this.checkCreateSQLiteDB.TabIndex = 0;
            this.checkCreateSQLiteDB.Text = "Create SQLite DB";
            this.checkCreateSQLiteDB.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioDBScriptFileExportEachFile);
            this.groupBox4.Controls.Add(this.radioDBScriptFileExportSingle);
            this.groupBox4.Controls.Add(this.checkCreateDataInsertScript);
            this.groupBox4.Controls.Add(this.checkCreateMSSQLScheme);
            this.groupBox4.Controls.Add(this.checkCreateMySQLScheme);
            this.groupBox4.Location = new System.Drawing.Point(833, 142);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(262, 125);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Database Scripts Option";
            // 
            // radioDBScriptFileExportEachFile
            // 
            this.radioDBScriptFileExportEachFile.AutoSize = true;
            this.radioDBScriptFileExportEachFile.Location = new System.Drawing.Point(8, 99);
            this.radioDBScriptFileExportEachFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioDBScriptFileExportEachFile.Name = "radioDBScriptFileExportEachFile";
            this.radioDBScriptFileExportEachFile.Size = new System.Drawing.Size(112, 16);
            this.radioDBScriptFileExportEachFile.TabIndex = 4;
            this.radioDBScriptFileExportEachFile.Text = "Each Sheet File";
            this.radioDBScriptFileExportEachFile.UseVisualStyleBackColor = true;
            // 
            // radioDBScriptFileExportSingle
            // 
            this.radioDBScriptFileExportSingle.AutoSize = true;
            this.radioDBScriptFileExportSingle.Checked = true;
            this.radioDBScriptFileExportSingle.Location = new System.Drawing.Point(8, 79);
            this.radioDBScriptFileExportSingle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioDBScriptFileExportSingle.Name = "radioDBScriptFileExportSingle";
            this.radioDBScriptFileExportSingle.Size = new System.Drawing.Size(82, 16);
            this.radioDBScriptFileExportSingle.TabIndex = 3;
            this.radioDBScriptFileExportSingle.TabStop = true;
            this.radioDBScriptFileExportSingle.Text = "Single File";
            this.radioDBScriptFileExportSingle.UseVisualStyleBackColor = true;
            // 
            // checkCreateDataInsertScript
            // 
            this.checkCreateDataInsertScript.AutoSize = true;
            this.checkCreateDataInsertScript.Location = new System.Drawing.Point(8, 59);
            this.checkCreateDataInsertScript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkCreateDataInsertScript.Name = "checkCreateDataInsertScript";
            this.checkCreateDataInsertScript.Size = new System.Drawing.Size(161, 16);
            this.checkCreateDataInsertScript.TabIndex = 2;
            this.checkCreateDataInsertScript.Text = "Create Data Insert Script";
            this.checkCreateDataInsertScript.UseVisualStyleBackColor = true;
            // 
            // checkCreateMSSQLScheme
            // 
            this.checkCreateMSSQLScheme.AutoSize = true;
            this.checkCreateMSSQLScheme.Location = new System.Drawing.Point(8, 39);
            this.checkCreateMSSQLScheme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkCreateMSSQLScheme.Name = "checkCreateMSSQLScheme";
            this.checkCreateMSSQLScheme.Size = new System.Drawing.Size(159, 16);
            this.checkCreateMSSQLScheme.TabIndex = 1;
            this.checkCreateMSSQLScheme.Text = "Create MSSQL Scheme";
            this.checkCreateMSSQLScheme.UseVisualStyleBackColor = true;
            // 
            // checkCreateMySQLScheme
            // 
            this.checkCreateMySQLScheme.AutoSize = true;
            this.checkCreateMySQLScheme.Location = new System.Drawing.Point(8, 19);
            this.checkCreateMySQLScheme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkCreateMySQLScheme.Name = "checkCreateMySQLScheme";
            this.checkCreateMySQLScheme.Size = new System.Drawing.Size(158, 16);
            this.checkCreateMySQLScheme.TabIndex = 0;
            this.checkCreateMySQLScheme.Text = "Create MySQL Scheme";
            this.checkCreateMySQLScheme.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioSourceCodeFileExportEachFile);
            this.groupBox5.Controls.Add(this.radioSourceCodeFileExportSingle);
            this.groupBox5.Controls.Add(this.checkExportCPPSource);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.checkExportCSSource);
            this.groupBox5.Controls.Add(this.txtNamespaceString);
            this.groupBox5.Controls.Add(this.checkUseNamespace);
            this.groupBox5.Location = new System.Drawing.Point(562, 295);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(534, 153);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Source Code Option";
            // 
            // radioSourceCodeFileExportEachFile
            // 
            this.radioSourceCodeFileExportEachFile.AutoSize = true;
            this.radioSourceCodeFileExportEachFile.Location = new System.Drawing.Point(8, 125);
            this.radioSourceCodeFileExportEachFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioSourceCodeFileExportEachFile.Name = "radioSourceCodeFileExportEachFile";
            this.radioSourceCodeFileExportEachFile.Size = new System.Drawing.Size(112, 16);
            this.radioSourceCodeFileExportEachFile.TabIndex = 6;
            this.radioSourceCodeFileExportEachFile.Text = "Each Sheet File";
            this.radioSourceCodeFileExportEachFile.UseVisualStyleBackColor = true;
            // 
            // radioSourceCodeFileExportSingle
            // 
            this.radioSourceCodeFileExportSingle.AutoSize = true;
            this.radioSourceCodeFileExportSingle.Checked = true;
            this.radioSourceCodeFileExportSingle.Location = new System.Drawing.Point(8, 105);
            this.radioSourceCodeFileExportSingle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioSourceCodeFileExportSingle.Name = "radioSourceCodeFileExportSingle";
            this.radioSourceCodeFileExportSingle.Size = new System.Drawing.Size(82, 16);
            this.radioSourceCodeFileExportSingle.TabIndex = 5;
            this.radioSourceCodeFileExportSingle.TabStop = true;
            this.radioSourceCodeFileExportSingle.Text = "Single File";
            this.radioSourceCodeFileExportSingle.UseVisualStyleBackColor = true;
            // 
            // checkExportCPPSource
            // 
            this.checkExportCPPSource.AutoSize = true;
            this.checkExportCPPSource.Location = new System.Drawing.Point(8, 85);
            this.checkExportCPPSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkExportCPPSource.Name = "checkExportCPPSource";
            this.checkExportCPPSource.Size = new System.Drawing.Size(164, 16);
            this.checkExportCPPSource.TabIndex = 4;
            this.checkExportCPPSource.Text = "Create C++ Source Code";
            this.checkExportCPPSource.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioUseClass);
            this.groupBox6.Controls.Add(this.radioUseStruct);
            this.groupBox6.Location = new System.Drawing.Point(271, 74);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(257, 66);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Data Option";
            // 
            // radioUseClass
            // 
            this.radioUseClass.AutoSize = true;
            this.radioUseClass.Checked = true;
            this.radioUseClass.Location = new System.Drawing.Point(8, 39);
            this.radioUseClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioUseClass.Name = "radioUseClass";
            this.radioUseClass.Size = new System.Drawing.Size(82, 16);
            this.radioUseClass.TabIndex = 1;
            this.radioUseClass.TabStop = true;
            this.radioUseClass.Text = "Use Class";
            this.radioUseClass.UseVisualStyleBackColor = true;
            // 
            // radioUseStruct
            // 
            this.radioUseStruct.AutoSize = true;
            this.radioUseStruct.Location = new System.Drawing.Point(8, 19);
            this.radioUseStruct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioUseStruct.Name = "radioUseStruct";
            this.radioUseStruct.Size = new System.Drawing.Size(81, 16);
            this.radioUseStruct.TabIndex = 0;
            this.radioUseStruct.Text = "Use Struct";
            this.radioUseStruct.UseVisualStyleBackColor = true;
            // 
            // checkExportCSSource
            // 
            this.checkExportCSSource.AutoSize = true;
            this.checkExportCSSource.Location = new System.Drawing.Point(8, 64);
            this.checkExportCSSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkExportCSSource.Name = "checkExportCSSource";
            this.checkExportCSSource.Size = new System.Drawing.Size(158, 16);
            this.checkExportCSSource.TabIndex = 2;
            this.checkExportCSSource.Text = "Create C# Source Code";
            this.checkExportCSSource.UseVisualStyleBackColor = true;
            // 
            // txtNamespaceString
            // 
            this.txtNamespaceString.Location = new System.Drawing.Point(8, 39);
            this.txtNamespaceString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNamespaceString.Name = "txtNamespaceString";
            this.txtNamespaceString.Size = new System.Drawing.Size(521, 21);
            this.txtNamespaceString.TabIndex = 1;
            // 
            // checkUseNamespace
            // 
            this.checkUseNamespace.AutoSize = true;
            this.checkUseNamespace.Location = new System.Drawing.Point(8, 19);
            this.checkUseNamespace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkUseNamespace.Name = "checkUseNamespace";
            this.checkUseNamespace.Size = new System.Drawing.Size(119, 16);
            this.checkUseNamespace.TabIndex = 0;
            this.checkUseNamespace.Text = "Use Namespace";
            this.checkUseNamespace.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(841, 467);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(255, 56);
            this.btnConvert.TabIndex = 10;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            // 
            // btnShowLog
            // 
            this.btnShowLog.Location = new System.Drawing.Point(562, 467);
            this.btnShowLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(255, 56);
            this.btnShowLog.TabIndex = 11;
            this.btnShowLog.Text = "Show Log";
            this.btnShowLog.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 545);
            this.Controls.Add(this.btnShowLog);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Excel Convertor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListExistsExcelFiles;
        private System.Windows.Forms.Button btnExcelFileFolderOpen;
        private System.Windows.Forms.Button btnBrowseExcelFileFolder;
        private System.Windows.Forms.TextBox txtExcelFileFolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenExportFolder;
        private System.Windows.Forms.Button btnBrowseExportFolder;
        private System.Windows.Forms.TextBox txtExportFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExcelFileListRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioSQLiteDBFileExportEachFile;
        private System.Windows.Forms.RadioButton radioSQLiteDBFileExportSingle;
        private System.Windows.Forms.CheckBox checkCreateSQLiteDB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioDBScriptFileExportEachFile;
        private System.Windows.Forms.RadioButton radioDBScriptFileExportSingle;
        private System.Windows.Forms.CheckBox checkCreateDataInsertScript;
        private System.Windows.Forms.CheckBox checkCreateMSSQLScheme;
        private System.Windows.Forms.CheckBox checkCreateMySQLScheme;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkUseNamespace;
        private System.Windows.Forms.CheckBox checkExportCPPSource;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioUseClass;
        private System.Windows.Forms.RadioButton radioUseStruct;
        private System.Windows.Forms.CheckBox checkExportCSSource;
        private System.Windows.Forms.TextBox txtNamespaceString;
        private System.Windows.Forms.RadioButton radioSourceCodeFileExportEachFile;
        private System.Windows.Forms.RadioButton radioSourceCodeFileExportSingle;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnShowLog;
        private System.Windows.Forms.Button btnExcelDeselectAll;
        private System.Windows.Forms.Button btnExcelSelectAll;
    }
}
