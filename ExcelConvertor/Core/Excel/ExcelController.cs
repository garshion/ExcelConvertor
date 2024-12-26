using Bass.Tools.Common;
using Bass.Tools.Config;
using Bass.Tools.Log;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bass.Tools.Core.Excel
{
    public class ExcelController
    {
        // <SheetName, Data>
        public Dictionary<string, WorkData> ExcelSheetDatas { get; set; } = new Dictionary<string, WorkData>();



        // 시트별로 읽고....
        // 같은 시트 데이터가 있는지 검사
        // 있으면 데이터 타입 검사
        // 데이터 타입이 다르면 에러 방출하고
        // 데이터 같으면 머지


        public bool ReadFile(string fileName)
        {
            string fileFullPath = Path.Combine(ConfigManager.Setting.ExcelFileFolder, fileName);

            if (!File.Exists(fileFullPath))
            {
                Logger.Log("File Not Exists : " + fileName);
                return false;
            }

            try
            {
                using (var workbook = new XLWorkbook(fileFullPath))
                {
                    foreach (var sheet in workbook.Worksheets)
                    {
                        if (sheet.Name.First() == '#')
                            continue;   // 주석 시트 (첫글자가 #인 시트는 무시)

                        if (!sheet.Name.IsValidClassName())
                            continue;   // 클래스명으로 사용할 수 없는 시트는 무시

                        _ReadSheetData(sheet);
                    }
                }

            }
            catch (Exception e)
            {
                Logger.Log("Read Excel File Error : " + e.Message);
                Logger.Trace(e);
                return false;
            }




            return true;
        }


        private bool _ReadSheetData(IXLWorksheet sheet)
        {
            if (null == sheet)
                return false;

            WorkData sheetData = new WorkData();
            // Read Sheet Data
            if (!sheetData.ReadSheetData(sheet))
                return false;

            // Check SameName Sheet Data
            if (ExcelSheetDatas.ContainsKey(sheet.Name))
            {
                if (!ExcelSheetDatas[sheet.Name].MergeData(sheetData))
                {
                    Logger.Log("Different Data Structure : " + sheet.Name);
                    return false;
                }
            }
            else
            {
                ExcelSheetDatas.Add(sheet.Name, sheetData);
            }

            return true;
        }






    }
}
