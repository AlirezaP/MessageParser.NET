using OfficeOpenXml;

namespace MessageParser.NET.Tools
{
   public class ExcelParser
    {
        private System.IO.FileInfo ExcelFile;
        private ExcelPackage excel;
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
        public ExcelWorksheets GetWorksheets()
        {
            return excel.Workbook.Worksheets;
        }

        public int GetWorksheetRowCount(int worksheetIndex)
        {
            ExcelWorksheet worksheet = excel.Workbook.Worksheets[worksheetIndex];
            return worksheet.Dimension.End.Row;
        }
        public int GetWorksheetColumnCount(int worksheetIndex)
        {
            ExcelWorksheet worksheet = excel.Workbook.Worksheets[worksheetIndex];
            return worksheet.Dimension.End.Column;
        }

        public ExcelWorksheet GetWorksheet(int worksheetIndex)
        {
            return excel.Workbook.Worksheets[worksheetIndex];
        }

        public ExcelWorksheet CreateNewSheet(string name)
        {
            var sheet = excel.Workbook.Worksheets.Add(name);
            return sheet;
        }

        public void AddColumn(ExcelWorksheet workSheet, string columnName)
        {
            int columnLengh = 0;
            if (workSheet.Dimension != null)
                columnLengh = workSheet.Dimension.End.Column;

            columnLengh++;
            workSheet.Cells[1, columnLengh].Value = columnName;

            // excel.Save();
        }

        public void AddRangeColumn(ExcelWorksheet workSheet, string[] columnsName)
        {
            int columnLengh = 0;
            if (workSheet.Dimension != null)
                columnLengh = workSheet.Dimension.End.Column;
            for (int i = 0; i < columnsName.Length; i++)
            {
                columnLengh++;
                workSheet.Cells[1, columnLengh].Value = columnsName[i];
            }

            // excel.Save();
        }

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

        public void AddData(ExcelWorksheet worksheet, string columnName, string value)
        {
            int column = 1;
            int rowLengh = 1;

            if (worksheet.Dimension != null)
            {
                rowLengh = worksheet.Dimension.End.Row;
                var columnLengh = worksheet.Dimension.End.Column;

                for (int i = 1; i <= columnLengh; i++)
                {
                    if (((string)worksheet.Cells[1, i].Value) == columnName)
                    {
                        column = i;
                        break;
                    }
                }
            }

            rowLengh++;
            worksheet.Cells[rowLengh, column].Value = value;
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
