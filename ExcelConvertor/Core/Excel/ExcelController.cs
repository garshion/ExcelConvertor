using Bass.Tools.Common;
using Bass.Tools.Config;
using Bass.Tools.Log;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bass.Tools.Core.Excel
{
    public class ExcelController
    {
        // <SheetName, Data>
        public Dictionary<string, WorkData> ExcelSheetDatas { get; set; } = new Dictionary<string, WorkData>();


        public void Reset()
        {
            foreach (var data in ExcelSheetDatas.Values)
            {
                data.Reset();
            }

            ExcelSheetDatas.Clear();
        }

        /// <summary>
        /// 엑셀 파일을 읽어서 작업용 데이터로 변환합니다. <br/>
        /// Read Excel files and convert them into working data. <br/>
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool ReadFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;   // invalid filename.

            string fileFullPath = Path.Combine(ConfigManager.Setting.ExcelFileFolder, fileName);

            if (!File.Exists(fileFullPath))
            {
                Logger.Log($"File ({fileName}) Not Exists : ");
                return false;
            }

            // Copy to temp file to avoid file lock issue (e.g., Excel is opening the file)
            string tempFilePath = Path.Combine(Path.GetTempPath(), $"ExcelConvertor_{Guid.NewGuid()}{Path.GetExtension(fileName)}");

            try
            {
                File.Copy(fileFullPath, tempFilePath, true);

                using (var workbook = new XLWorkbook(tempFilePath))
                {
                    foreach (var sheet in workbook.Worksheets)
                    {
                        if (sheet.Name.First() == '#')
                            continue;   // comment sheet. ignore

                        if (!sheet.Name.IsValidClassName())
                            continue;   // cannot convert classname. ignore.

                        if (!_ReadSheetData(sheet))
                        {
                            Logger.Log($"File ({fileName}) Read Sheet ({sheet.Name}) Error!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log($"Read Excel File ({fileName}) Error : {e.Message}");
                Logger.Trace(e);
                return false;
            }
            finally
            {
                // Delete temp file
                if (File.Exists(tempFilePath))
                {
                    try
                    {
                        File.Delete(tempFilePath);
                    }
                    catch
                    {
                        // Ignore delete error
                    }
                }
            }

            return true;
        }


        private bool _ReadSheetData(IXLWorksheet sheet)
        {
            if (null == sheet)
                return false;   // invalid parameter.

            WorkData sheetData = new WorkData();

            // Read Sheet Data
            if (!sheetData.ReadSheetData(sheet))
                return false;

            // Check SameName Sheet Data
            if (ExcelSheetDatas.ContainsKey(sheet.Name))
            {
                if (!ExcelSheetDatas[sheet.Name].MergeData(sheetData))
                {
                    Logger.Log($"Same SheetName ({sheet.Name}) Exists. But, Data Structure is Different!");
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
