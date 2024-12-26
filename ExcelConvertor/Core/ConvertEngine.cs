using Bass.Tools.Config;
using Bass.Tools.Core.Database;
using Bass.Tools.Core.Excel;
using Bass.Tools.Core.Programming;
using Bass.Tools.Core.SQLite;
using Bass.Tools.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bass.Tools.Core
{
    public class ConvertEngine
    {
        private List<string> mWorkFiles { get; set; } = new List<string>();

        // Controllers
        private ExcelController mExcelController { get; } = new ExcelController();
        private SQLiteController mSQLiteController { get; } = new SQLiteController();
        private DBController mDBController { get; } = new DBController();
        private ProgrammingController mProgrammingController { get; } = new ProgrammingController();


        /// <summary>
        /// 입력받은 엑셀 파일 목록을 처리합니다. <br/>
        /// Processes a list of input Excel files. <br/>
        /// </summary>
        /// <param name="excelFileList"></param>
        /// <returns></returns>
        public bool Process(List<string> excelFileList)
        {
            if (null == excelFileList
                || excelFileList.Count == 0)
            {
                Logger.Log("Excel File List is Empty.");
                return false;
            }

            // Check File Exists.
            if (!_CheckFiles(excelFileList))
            {
                Logger.Log("No Valid Excel Files.");
                return false;
            }

            mExcelController.Reset();

            // Read Excel File And Combine Data.
            if (!_ReadExcelFiles())
            {
                Logger.Log("Read Excel Files Error.");
                return false;
            }

            var datas = mExcelController.ExcelSheetDatas.Values.ToList();


            // SQLite DB Process
            if (!mSQLiteController.Process(datas))
            {
                Logger.Log("SQLite Process Error.");
            }

            // Database File Process
            if (!mDBController.Process(datas))
            {
                Logger.Log("Database Process Error.");
            }

            // Generate Code Files.
            if (!mProgrammingController.Process(datas))
            {
                Logger.Log("Programming Process Error.");
            }


            GC.Collect();
            return true;
        }



        private bool _CheckFiles(List<string> excelFileList)
        {
            if (null == excelFileList)
                return false;   // invalid parameter.

            mWorkFiles.Clear();

            foreach (string file in excelFileList)
            {
                string fullPath = Path.Combine(ConfigManager.Setting.ExcelFileFolder, file);
                if (!File.Exists(fullPath))
                {
                    Logger.Log("File Not Found: " + file);
                    continue;
                }
                mWorkFiles.Add(file);
            }

            return mWorkFiles.Count > 0;
        }

        private bool _ReadExcelFiles()
        {
            if (mWorkFiles.Count == 0)
                return false; // no files.

            foreach (var file in mWorkFiles)
            {
                if (!mExcelController.ReadFile(file))
                {
                    Logger.Log("Read Excel File Error : " + file);
                }
                else
                {
                    Logger.Log("Read Excel File Success : " + file);
                }
            }

            return true;
        }

    }
}
