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


            // SQLite DB Process


            // Database File Process


            // Generate Code Files.




            return true;
        }



        private bool _CheckFiles(List<string> excelFileList)
        {
            if (null == excelFileList)
                return false;   // invalid parameter.

            mWorkFiles.Clear();

            foreach (string file in excelFileList)
            {
                if (!File.Exists(file))
                {
                    Logger.Log("File Not Found: " + file);
                    continue;
                }
                mWorkFiles.Add(file);
            }

            return mWorkFiles.Count > 0;
        }




    }
}
