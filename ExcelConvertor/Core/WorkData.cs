using Bass.Tools.Common;
using Bass.Tools.Log;
using ClosedXML.Excel;
using System.Collections.Generic;

namespace Bass.Tools.Core
{
    public class WorkData
    {
        public string SheetName = string.Empty;

        public List<WorkDataHeaderInfo> HeaderInfo { get; set; } = new List<WorkDataHeaderInfo>();

        public List<List<string>> Datas { get; set; } = new List<List<string>>();


        private int mRowCount = 0;
        private int mColCount = 0;

        private int mNameRow = 0;
        private int mTypeRow = 0;


        public void Reset()
        {
            SheetName = string.Empty;
            HeaderInfo.Clear();
            Datas.Clear();

            mRowCount = 0;
            mColCount = 0;
            mNameRow = 0;
            mTypeRow = 0;
        }

        public bool IsValidHeader()
        {
            if (HeaderInfo.Count == 0)
                return false;   // No Header Data

            foreach (var header in HeaderInfo)
            {
                if (string.IsNullOrEmpty(header.ColumnName))
                    return false;   // Empty Column Name

                if (HeaderInfo.Exists(x => x.ColumnName.ToLower().Equals(header.ColumnName.ToLower())))
                    return false;   // Same Name Column Exists
            }

            return true;    // OK
        }


        /// <summary>
        /// Merge Same Sheet Data
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool MergeData(WorkData other)
        {
            if (null == other)
                return false;   // invalid parameter.

            if (!SheetName.Equals(other.SheetName))
                return false;   // not matched sheet name.

            if (!_CheckSameSpecStructure(other))
                return false;   // Different Structure.

            Datas.AddRange(other.Datas);
            return true;
        }

        /// <summary>
        /// 두 데이터의 사양이 동일한지 확인합니다. <br/>
        /// Verify that the specifications of both data are identical. <br/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool _CheckSameSpecStructure(WorkData other)
        {
            if (null == other)
                return false;   // invalid parameter.

            if (HeaderInfo.Count != other.HeaderInfo.Count)
                return false;   // Different Column Count.


            // 동일한 순서가 아니라면 다른 구조로 간주함.
            // If the order is not the same, they are considered different structures.
            for (int i = 0; i < HeaderInfo.Count; i++)
            {
                if (HeaderInfo[i].ColumnName != other.HeaderInfo[i].ColumnName)
                    return false;

                if (!HeaderInfo[i].DataType.IsSame(other.HeaderInfo[i].DataType))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Load Excel Sheet Data And Parse.
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public bool ReadSheetData(IXLWorksheet sheet)
        {
            if (null == sheet)
                return false;   // Invalid Parameter.

            if (!_SetSheetName(sheet))
                return false;

            if (!_SetSheetSize(sheet))
                return false;

            if (!_GetDataAndTypeRow(sheet))
                return false;

            if (!_GetHeaderInfo(sheet))
                return false;

            if (!_ReadData(sheet))
                return false;

            return true;
        }

        private bool _SetSheetName(IXLWorksheet sheet)
        {
            if (null == sheet)
                return false;

            if (!sheet.Name.IsValidClassName())
                return false;

            SheetName = sheet.Name;
            return true;
        }

        private bool _SetSheetSize(IXLWorksheet sheet)
        {
            var lastCell = sheet.LastCellUsed();
            mColCount = lastCell.Address.ColumnNumber;
            mRowCount = lastCell.Address.RowNumber;

            if (mRowCount < 2)
                return false;   // invalid row count.

            return true;
        }

        private bool _GetDataAndTypeRow(IXLWorksheet sheet)
        {
            if (mRowCount < 2
                || mColCount <= 0)
                return false;   // invalid data

            for (int i = 1; i <= mRowCount; ++i)
            {
                var dataValue = sheet.Cell(i, 1).Value.ToString();

                if (dataValue.IsIgnoreLine())
                    continue;   // 주석 및 비어있는 라인이므로 무시

                if (mNameRow == 0)
                {
                    mNameRow = i;
                    continue;
                }
                else
                {
                    mTypeRow = i;
                    break;
                }
            }

            if (mNameRow == 0
                || mTypeRow == 0)
                return false;   // 이름이나 타입이 없음

            return true;
        }

        private bool _GetHeaderInfo(IXLWorksheet sheet)
        {
            if (null == sheet)
                return false;

            if (mNameRow == 0
                || mTypeRow == 0)
                return false;   // 이름이나 타입이 없음

            for (int i = 1; i <= mColCount; ++i)
            {
                var name = sheet.Cell(mNameRow, i).Value.ToString();
                if (!name.IsValidDatabaseColumnName())
                    continue;

                var type = sheet.Cell(mTypeRow, i).Value.ToString();

                var header = new WorkDataHeaderInfo();

                if (header.SetData(name, type, i))
                {

                    if (HeaderInfo.Exists(x => x.ColumnName.Equals(header.ColumnName)))
                    {
                        Logger.Log("Duplicated Column Name : " + name);
                        return false;
                    }

                    HeaderInfo.Add(header);
                }
            }

            return HeaderInfo.Count > 0;
        }

        private bool _ReadData(IXLWorksheet sheet)
        {
            for (int row = mTypeRow + 1; row <= mRowCount; ++row)
            {
                List<string> rowData = new List<string>();
                bool bOK = true;

                var checkIgnore = sheet.Cell(row, 1).Value.ToString();
                if (checkIgnore.StartsWith("#"))
                    continue;   // 주석


                foreach (var header in HeaderInfo)
                {
                    var cell = sheet.Cell(row, header.ColumnIndex);
                    string cellData;

                    if (cell.DataType == XLDataType.DateTime)
                    {
                        cellData = cell.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        cellData = cell.Value.ToString();
                    }

                    //var cellData = sheet.Cell(row, header.ColumnIndex).Value.ToString();
                    if (!header.IsValidColumnData(cellData))
                    {
                        Logger.Log($"Read Data - Invalid Data Type. Sheet ({SheetName}) Row ({row}) Column ({header.ColumnName}/{header.ColumnIndex})");
                        bOK = false;
                        break;
                    }

                    rowData.Add(cellData);
                }

                if (bOK)
                    Datas.Add(rowData);
            }

            return true;
        }

    }
}
