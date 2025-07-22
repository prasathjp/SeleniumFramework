namespace NUnitFrameworkDemo.Utilities
{
    public class DataSource
    {

        public static object[] LoginDataSource()
        {
            string[] strArrLogin1 = new string[] { "aaaa", "aaaa123" };
            string[] strArrLogin2 = new string[] { "bbbb", "bbbb123" };

            object[] objCred = new object[2];
            objCred[0] = strArrLogin1;
            objCred[1] = strArrLogin2;
            return objCred;
        }

        /// <summary>
        /// Reads Excel file by excluding header and converts each row into object[]
        /// </summary>
        /// <returns>object[]</returns>
        public static object[] LoginDataSourceFromExcel()
        {
            object[] objCred = ExcelSource.GetSheetIntoObjectArray(AppDomain.CurrentDomain.BaseDirectory + @"TestData\LoginValidation.xlsx", "Credentials");

            return objCred;
        }
    }
}