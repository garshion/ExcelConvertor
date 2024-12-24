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
            this.label1 = new System.Windows.Forms.Label();
            this.txtExcelFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseExcelFileFolder = new System.Windows.Forms.Button();
            this.btnExcelFileFolderOpen = new System.Windows.Forms.Button();
            this.checkedListExistsExcelFiles = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenExportFolder = new System.Windows.Forms.Button();
            this.btnBrowseExportFolder = new System.Windows.Forms.Button();
            this.txtExportFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExcelFileListRefresh = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkCreateSQLiteDB = new System.Windows.Forms.CheckBox();
            this.radioSQLiteDBFileExportSingle = new System.Windows.Forms.RadioButton();
            this.radioSQLiteDBFileExportEachFile = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkCreateMySQLScheme = new System.Windows.Forms.CheckBox();
            this.checkCreateMSSQLScheme = new System.Windows.Forms.CheckBox();
            this.checkCreateDataInsertScript = new System.Windows.Forms.CheckBox();
            this.radioDBScriptFileExportEachFile = new System.Windows.Forms.RadioButton();
            this.radioDBScriptFileExportSingle = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioUseStruct = new System.Windows.Forms.RadioButton();
            this.radioUseClass = new System.Windows.Forms.RadioButton();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.radioSourceCodeFileExportEachFile = new System.Windows.Forms.RadioButton();
            this.radioSourceCodeFileExportSingle = new System.Windows.Forms.RadioButton();
            this.progressWork = new System.Windows.Forms.ProgressBar();
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
            this.groupBox1.Controls.Add(this.btnExcelFileListRefresh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkedListExistsExcelFiles);
            this.groupBox1.Controls.Add(this.btnExcelFileFolderOpen);
            this.groupBox1.Controls.Add(this.btnBrowseExcelFileFolder);
            this.groupBox1.Controls.Add(this.txtExcelFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(610, 657);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel Import";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel File Folder";
            // 
            // txtExcelFolder
            // 
            this.txtExcelFolder.Location = new System.Drawing.Point(9, 49);
            this.txtExcelFolder.Name = "txtExcelFolder";
            this.txtExcelFolder.Size = new System.Drawing.Size(595, 25);
            this.txtExcelFolder.TabIndex = 1;
            // 
            // btnBrowseExcelFileFolder
            // 
            this.btnBrowseExcelFileFolder.Location = new System.Drawing.Point(494, 80);
            this.btnBrowseExcelFileFolder.Name = "btnBrowseExcelFileFolder";
            this.btnBrowseExcelFileFolder.Size = new System.Drawing.Size(110, 23);
            this.btnBrowseExcelFileFolder.TabIndex = 2;
            this.btnBrowseExcelFileFolder.Text = "Browse..";
            this.btnBrowseExcelFileFolder.UseVisualStyleBackColor = true;
            // 
            // btnExcelFileFolderOpen
            // 
            this.btnExcelFileFolderOpen.Location = new System.Drawing.Point(378, 80);
            this.btnExcelFileFolderOpen.Name = "btnExcelFileFolderOpen";
            this.btnExcelFileFolderOpen.Size = new System.Drawing.Size(110, 23);
            this.btnExcelFileFolderOpen.TabIndex = 3;
            this.btnExcelFileFolderOpen.Text = "Open Folder";
            this.btnExcelFileFolderOpen.UseVisualStyleBackColor = true;
            // 
            // checkedListExistsExcelFiles
            // 
            this.checkedListExistsExcelFiles.FormattingEnabled = true;
            this.checkedListExistsExcelFiles.Location = new System.Drawing.Point(9, 129);
            this.checkedListExistsExcelFiles.Name = "checkedListExistsExcelFiles";
            this.checkedListExistsExcelFiles.Size = new System.Drawing.Size(595, 524);
            this.checkedListExistsExcelFiles.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenExportFolder);
            this.groupBox2.Controls.Add(this.btnBrowseExportFolder);
            this.groupBox2.Controls.Add(this.txtExportFolder);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(642, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 126);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            // 
            // btnOpenExportFolder
            // 
            this.btnOpenExportFolder.Location = new System.Drawing.Point(378, 80);
            this.btnOpenExportFolder.Name = "btnOpenExportFolder";
            this.btnOpenExportFolder.Size = new System.Drawing.Size(110, 23);
            this.btnOpenExportFolder.TabIndex = 3;
            this.btnOpenExportFolder.Text = "Open Folder";
            this.btnOpenExportFolder.UseVisualStyleBackColor = true;
            // 
            // btnBrowseExportFolder
            // 
            this.btnBrowseExportFolder.Location = new System.Drawing.Point(494, 80);
            this.btnBrowseExportFolder.Name = "btnBrowseExportFolder";
            this.btnBrowseExportFolder.Size = new System.Drawing.Size(110, 23);
            this.btnBrowseExportFolder.TabIndex = 2;
            this.btnBrowseExportFolder.Text = "Browse..";
            this.btnBrowseExportFolder.UseVisualStyleBackColor = true;
            // 
            // txtExportFolder
            // 
            this.txtExportFolder.Location = new System.Drawing.Point(9, 49);
            this.txtExportFolder.Name = "txtExportFolder";
            this.txtExportFolder.Size = new System.Drawing.Size(595, 25);
            this.txtExportFolder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Export Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Excel Files to Convert";
            // 
            // btnExcelFileListRefresh
            // 
            this.btnExcelFileListRefresh.Location = new System.Drawing.Point(262, 80);
            this.btnExcelFileListRefresh.Name = "btnExcelFileListRefresh";
            this.btnExcelFileListRefresh.Size = new System.Drawing.Size(110, 23);
            this.btnExcelFileListRefresh.TabIndex = 6;
            this.btnExcelFileListRefresh.Text = "Refresh";
            this.btnExcelFileListRefresh.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioSQLiteDBFileExportEachFile);
            this.groupBox3.Controls.Add(this.radioSQLiteDBFileExportSingle);
            this.groupBox3.Controls.Add(this.checkCreateSQLiteDB);
            this.groupBox3.Location = new System.Drawing.Point(642, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 156);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SQLite Database Option";
            // 
            // checkCreateSQLiteDB
            // 
            this.checkCreateSQLiteDB.AutoSize = true;
            this.checkCreateSQLiteDB.Checked = true;
            this.checkCreateSQLiteDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCreateSQLiteDB.Location = new System.Drawing.Point(9, 24);
            this.checkCreateSQLiteDB.Name = "checkCreateSQLiteDB";
            this.checkCreateSQLiteDB.Size = new System.Drawing.Size(143, 19);
            this.checkCreateSQLiteDB.TabIndex = 0;
            this.checkCreateSQLiteDB.Text = "Create SQLite DB";
            this.checkCreateSQLiteDB.UseVisualStyleBackColor = true;
            // 
            // radioSQLiteDBFileExportSingle
            // 
            this.radioSQLiteDBFileExportSingle.AutoSize = true;
            this.radioSQLiteDBFileExportSingle.Checked = true;
            this.radioSQLiteDBFileExportSingle.Location = new System.Drawing.Point(9, 99);
            this.radioSQLiteDBFileExportSingle.Name = "radioSQLiteDBFileExportSingle";
            this.radioSQLiteDBFileExportSingle.Size = new System.Drawing.Size(92, 19);
            this.radioSQLiteDBFileExportSingle.TabIndex = 1;
            this.radioSQLiteDBFileExportSingle.TabStop = true;
            this.radioSQLiteDBFileExportSingle.Text = "Single File";
            this.radioSQLiteDBFileExportSingle.UseVisualStyleBackColor = true;
            // 
            // radioSQLiteDBFileExportEachFile
            // 
            this.radioSQLiteDBFileExportEachFile.AutoSize = true;
            this.radioSQLiteDBFileExportEachFile.Location = new System.Drawing.Point(9, 124);
            this.radioSQLiteDBFileExportEachFile.Name = "radioSQLiteDBFileExportEachFile";
            this.radioSQLiteDBFileExportEachFile.Size = new System.Drawing.Size(128, 19);
            this.radioSQLiteDBFileExportEachFile.TabIndex = 2;
            this.radioSQLiteDBFileExportEachFile.Text = "Each Sheet File";
            this.radioSQLiteDBFileExportEachFile.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioDBScriptFileExportEachFile);
            this.groupBox4.Controls.Add(this.radioDBScriptFileExportSingle);
            this.groupBox4.Controls.Add(this.checkCreateDataInsertScript);
            this.groupBox4.Controls.Add(this.checkCreateMSSQLScheme);
            this.groupBox4.Controls.Add(this.checkCreateMySQLScheme);
            this.groupBox4.Location = new System.Drawing.Point(952, 178);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 156);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Database Scripts Option";
            // 
            // checkCreateMySQLScheme
            // 
            this.checkCreateMySQLScheme.AutoSize = true;
            this.checkCreateMySQLScheme.Location = new System.Drawing.Point(9, 24);
            this.checkCreateMySQLScheme.Name = "checkCreateMySQLScheme";
            this.checkCreateMySQLScheme.Size = new System.Drawing.Size(181, 19);
            this.checkCreateMySQLScheme.TabIndex = 0;
            this.checkCreateMySQLScheme.Text = "Create MySQL Scheme";
            this.checkCreateMySQLScheme.UseVisualStyleBackColor = true;
            // 
            // checkCreateMSSQLScheme
            // 
            this.checkCreateMSSQLScheme.AutoSize = true;
            this.checkCreateMSSQLScheme.Location = new System.Drawing.Point(9, 49);
            this.checkCreateMSSQLScheme.Name = "checkCreateMSSQLScheme";
            this.checkCreateMSSQLScheme.Size = new System.Drawing.Size(183, 19);
            this.checkCreateMSSQLScheme.TabIndex = 1;
            this.checkCreateMSSQLScheme.Text = "Create MSSQL Scheme";
            this.checkCreateMSSQLScheme.UseVisualStyleBackColor = true;
            // 
            // checkCreateDataInsertScript
            // 
            this.checkCreateDataInsertScript.AutoSize = true;
            this.checkCreateDataInsertScript.Location = new System.Drawing.Point(9, 74);
            this.checkCreateDataInsertScript.Name = "checkCreateDataInsertScript";
            this.checkCreateDataInsertScript.Size = new System.Drawing.Size(185, 19);
            this.checkCreateDataInsertScript.TabIndex = 2;
            this.checkCreateDataInsertScript.Text = "Create Data Insert Script";
            this.checkCreateDataInsertScript.UseVisualStyleBackColor = true;
            // 
            // radioDBScriptFileExportEachFile
            // 
            this.radioDBScriptFileExportEachFile.AutoSize = true;
            this.radioDBScriptFileExportEachFile.Location = new System.Drawing.Point(9, 124);
            this.radioDBScriptFileExportEachFile.Name = "radioDBScriptFileExportEachFile";
            this.radioDBScriptFileExportEachFile.Size = new System.Drawing.Size(128, 19);
            this.radioDBScriptFileExportEachFile.TabIndex = 4;
            this.radioDBScriptFileExportEachFile.Text = "Each Sheet File";
            this.radioDBScriptFileExportEachFile.UseVisualStyleBackColor = true;
            // 
            // radioDBScriptFileExportSingle
            // 
            this.radioDBScriptFileExportSingle.AutoSize = true;
            this.radioDBScriptFileExportSingle.Checked = true;
            this.radioDBScriptFileExportSingle.Location = new System.Drawing.Point(9, 99);
            this.radioDBScriptFileExportSingle.Name = "radioDBScriptFileExportSingle";
            this.radioDBScriptFileExportSingle.Size = new System.Drawing.Size(92, 19);
            this.radioDBScriptFileExportSingle.TabIndex = 3;
            this.radioDBScriptFileExportSingle.TabStop = true;
            this.radioDBScriptFileExportSingle.Text = "Single File";
            this.radioDBScriptFileExportSingle.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioSourceCodeFileExportEachFile);
            this.groupBox5.Controls.Add(this.radioSourceCodeFileExportSingle);
            this.groupBox5.Controls.Add(this.checkBox7);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.checkBox6);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.checkBox5);
            this.groupBox5.Location = new System.Drawing.Point(642, 369);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(610, 191);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Source Code Option";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(9, 24);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(133, 19);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "Use Namespace";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(595, 25);
            this.textBox2.TabIndex = 1;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(9, 80);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(183, 19);
            this.checkBox6.TabIndex = 2;
            this.checkBox6.Text = "Create C# Source Code";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioUseClass);
            this.groupBox6.Controls.Add(this.radioUseStruct);
            this.groupBox6.Location = new System.Drawing.Point(310, 93);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(294, 82);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Data Option";
            // 
            // radioUseStruct
            // 
            this.radioUseStruct.AutoSize = true;
            this.radioUseStruct.Location = new System.Drawing.Point(9, 24);
            this.radioUseStruct.Name = "radioUseStruct";
            this.radioUseStruct.Size = new System.Drawing.Size(94, 19);
            this.radioUseStruct.TabIndex = 0;
            this.radioUseStruct.Text = "Use Struct";
            this.radioUseStruct.UseVisualStyleBackColor = true;
            // 
            // radioUseClass
            // 
            this.radioUseClass.AutoSize = true;
            this.radioUseClass.Checked = true;
            this.radioUseClass.Location = new System.Drawing.Point(9, 49);
            this.radioUseClass.Name = "radioUseClass";
            this.radioUseClass.Size = new System.Drawing.Size(93, 19);
            this.radioUseClass.TabIndex = 1;
            this.radioUseClass.TabStop = true;
            this.radioUseClass.Text = "Use Class";
            this.radioUseClass.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(9, 106);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(191, 19);
            this.checkBox7.TabIndex = 4;
            this.checkBox7.Text = "Create C++ Source Code";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // radioSourceCodeFileExportEachFile
            // 
            this.radioSourceCodeFileExportEachFile.AutoSize = true;
            this.radioSourceCodeFileExportEachFile.Location = new System.Drawing.Point(9, 156);
            this.radioSourceCodeFileExportEachFile.Name = "radioSourceCodeFileExportEachFile";
            this.radioSourceCodeFileExportEachFile.Size = new System.Drawing.Size(128, 19);
            this.radioSourceCodeFileExportEachFile.TabIndex = 6;
            this.radioSourceCodeFileExportEachFile.Text = "Each Sheet File";
            this.radioSourceCodeFileExportEachFile.UseVisualStyleBackColor = true;
            // 
            // radioSourceCodeFileExportSingle
            // 
            this.radioSourceCodeFileExportSingle.AutoSize = true;
            this.radioSourceCodeFileExportSingle.Checked = true;
            this.radioSourceCodeFileExportSingle.Location = new System.Drawing.Point(9, 131);
            this.radioSourceCodeFileExportSingle.Name = "radioSourceCodeFileExportSingle";
            this.radioSourceCodeFileExportSingle.Size = new System.Drawing.Size(92, 19);
            this.radioSourceCodeFileExportSingle.TabIndex = 5;
            this.radioSourceCodeFileExportSingle.TabStop = true;
            this.radioSourceCodeFileExportSingle.Text = "Single File";
            this.radioSourceCodeFileExportSingle.UseVisualStyleBackColor = true;
            // 
            // progressWork
            // 
            this.progressWork.Location = new System.Drawing.Point(642, 642);
            this.progressWork.Name = "progressWork";
            this.progressWork.Size = new System.Drawing.Size(610, 23);
            this.progressWork.TabIndex = 9;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(961, 566);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(291, 70);
            this.btnConvert.TabIndex = 10;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            // 
            // btnShowLog
            // 
            this.btnShowLog.Location = new System.Drawing.Point(642, 566);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(291, 70);
            this.btnShowLog.TabIndex = 11;
            this.btnShowLog.Text = "Show Log";
            this.btnShowLog.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnShowLog);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.progressWork);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.TextBox txtExcelFolder;
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
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioUseClass;
        private System.Windows.Forms.RadioButton radioUseStruct;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton radioSourceCodeFileExportEachFile;
        private System.Windows.Forms.RadioButton radioSourceCodeFileExportSingle;
        private System.Windows.Forms.ProgressBar progressWork;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnShowLog;
    }
}
