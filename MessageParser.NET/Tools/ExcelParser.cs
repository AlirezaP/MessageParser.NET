using OfficeOpenXml;

namespace MessageParser.NET.Tools
{
   public class ExcelParser
    {
        private System.IO.FileInfo ExcelFile;
        public ExcelPackage excel;
        public ExcelParser(string excelPath)
        {
            ExcelFile = new System.IO.FileInfo(excelPath);
            excel = new ExcelPackage(ExcelFile);
        }

        public ExcelParser(byte[] buf)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buf);
            excel = new ExcelPackage(ms);
        }

        /// <summary>
        /// Get All Sheets
        /// </summary>
        /// <returns></returns>
        public ExcelWorksheets GetWorksheets()
        {
            return excel.Workbook.Worksheets;
        }

        /// <summary>
        /// Get Count Of Rows For Specified Sheet
        /// </summary>
        /// <param name="worksheetIndex">Index Of Sheet</param>
        /// <returns></returns>
        public int GetWorksheetRowCount(int worksheetIndex)
        {
            ExcelWorksheet worksheet = excel.Workbook.Worksheets[worksheetIndex];
            return worksheet.Dimension.End.Row;
        }

        /// <summary>
        /// Get Count Of Columns For Specified Sheet
        /// </summary>
        /// <param name="worksheetIndex">Index Of Sheet</param>
        /// <returns></returns>
        public int GetWorksheetColumnCount(int worksheetIndex)
        {
            ExcelWorksheet worksheet = excel.Workbook.Worksheets[worksheetIndex];
            return worksheet.Dimension.End.Column;
        }

        /// <summary>
        /// Assign Specified Sheet
        /// </summary>
        /// <param name="worksheetIndex">Index Of Sheet</param>
        /// <returns></returns>
        public ExcelWorksheet GetWorksheet(int worksheetIndex)
        {
            return excel.Workbook.Worksheets[worksheetIndex];
        }

        /// <summary>
        /// Create New Sheet In Current WorkBook
        /// </summary>
        /// <param name="name">Sheet Name</param>
        /// <returns></returns>
        public ExcelWorksheet CreateNewSheet(string name)
        {
            var sheet = excel.Workbook.Worksheets.Add(name);
            return sheet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workSheet">Index Of Sheet</param>
        /// <param name="columnName">Column Name</param>
        public void AddColumn(ExcelWorksheet workSheet, string columnName)
        {
            int columnLengh = 0;
            if (workSheet.Dimension != null)
                columnLengh = workSheet.Dimension.End.Column;

            columnLengh++;
            workSheet.Cells[1, columnLengh].Value = columnName;

            // excel.Save();
        }

        /// <summary>
        /// Add Columns Array To Specified Sheet
        /// </summary>
        /// <param name="workSheet">Index Of Sheet</param>
        /// <param name="columnsNames">Columns Name</param>
        public void AddRangeColumn(ExcelWorksheet workSheet, string[] columnsNames)
        {
            int columnLengh = 0;
            if (workSheet.Dimension != null)
                columnLengh = workSheet.Dimension.End.Column;
            foreach (string columnName in columnsNames)
            {
                columnLengh++;
                workSheet.Cells[1, columnLengh].Value = columnName;
            }

            // excel.Save();
        }

        /// <summary>
        /// Add Rows Array To Specified Column
        /// </summary>
        /// <param name="workSheet">Index Of Sheet</param>
        /// <param name="columnName">Column Name</param>
        /// <param name="rows">Rows Value</param>
        public void AddRangeRows(ExcelWorksheet workSheet, string columnName, string[] rows)
        {
            int columnLengh = 0;
            int rowsLengh = 0;
            if (workSheet.Dimension != null)
            {
                columnLengh = workSheet.Dimension.End.Column;
                rowsLengh = workSheet.Dimension.End.Row;
            }
            else
                return;


            int colIndex = ColumnIndex(workSheet, columnName);

            for (int i = 0; i < rows.Length; i++)
            {
                columnLengh++;
                workSheet.Cells[rowsLengh + i + 1, colIndex].Value = rows[i];
            }

            // excel.Save();
        }

        /// <summary>
        /// Add Value To Specified Column
        /// </summary>
        /// <param name="worksheet">Index Of Sheet</param>
        /// <param name="column">Column Index</param>
        /// <param name="value"></param>
        public void AddData(ExcelWorksheet worksheet, int column, string value)
        {
            int rowLengh = 0;
            if (worksheet.Dimension != null)
            {
                rowLengh = worksheet.Dimension.End.Row;
            }

            rowLengh++;
            worksheet.Cells[rowLengh, column].Value = value;
        }

        /// <summary>
        /// Add Value To Specified Column
        /// </summary>
        /// <param name="worksheet">Index Of Sheet</param>
        /// <param name="columnName">Column Name</param>
        /// <param name="value"></param>
        public void AddData(ExcelWorksheet worksheet, string columnName, string value)
        {
            int column = 1;
            int rowLengh = 1;

            if (worksheet.Dimension != null)
            {
                rowLengh = worksheet.Dimension.End.Row;
                var columnLengh = worksheet.Dimension.End.Column;

                column = ColumnIndex(worksheet, columnName);
            }

            rowLengh++;
            worksheet.Cells[rowLengh, column].Value = value;
        }

        /// <summary>
        /// Get Column Index With Name
        /// </summary>
        /// <param name="worksheet">Index Of Sheet</param>
        /// <param name="columnName">Column Name</param>
        /// <returns></returns>
        public int ColumnIndex(ExcelWorksheet worksheet, string columnName)
        {
            if (worksheet.Dimension != null)
            {
                var columnLengh = worksheet.Dimension.End.Column;

                for (int i = 1; i <= columnLengh; i++)
                {
                    if (((string)worksheet.Cells[1, i].Value) == columnName)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public void Save()
        {
            excel.Save();
        }

        public void Save(string path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            excel.SaveAs(file);
        }

        public void Close()
        {
            excel.Dispose();
        }
    }
}
