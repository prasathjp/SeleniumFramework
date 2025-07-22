using ClosedXML.Excel;

namespace NUnitFrameworkDemo.Utilities
{
    public class ExcelSource
    {
        public static object[] GetSheetIntoObjectArray(string excelFileName, string excelSheetName)
        {
            object[] objCred = null;
            XLWorkbook xlsFile = null;
            IXLWorksheet workSheet = null;
            IXLRange sheetRange = null;
            int rowCount = 0;
            int colCount = 0;

            try
            {
                xlsFile = new XLWorkbook(excelFileName);
                workSheet = xlsFile.Worksheet(excelSheetName);
                sheetRange = workSheet.RangeUsed();

                rowCount = sheetRange.RowCount();
                colCount = sheetRange.ColumnCount();

                //Set the array size as total number of rows excluding header. It counts as the total number of testcases
                objCred = new object[rowCount - 1];

                for (int row = 2; row <= rowCount; row++)
                {
                    string[] cellData = new string[colCount];
                    for (int col = 1; col <= colCount; col++)
                    {
                        string cellValue = sheetRange.Cell(row, col).GetString();
                        cellData[col - 1] = cellValue;
                    }
                    objCred[row - 2] = cellData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing Excel as Data Source : " + ex.Message);
            }
            finally
            {
                xlsFile.Dispose();
            }

            return objCred;
        }
    }
}
