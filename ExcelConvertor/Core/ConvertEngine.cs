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
using System.Text;
using System.Threading.Tasks;

namespace Bass.Tools.Core
{
    public class ConvertEngine
    {
        private List<string> mWorkFiles = new List<string>();

        // Controllers
        private ExcelController mExcelController = new ExcelController();
        private SQLiteController mSQLiteController = new SQLiteController();
        private DBController mDBController = new DBController();
        private ProgrammingController mProgrammingController = new ProgrammingController();


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

            // Read Excel File And Combine Data.
            if(!_ReadExcelFiles())
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

            foreach(var file in mWorkFiles)
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
