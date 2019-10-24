using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace MMSeleniumProjectDemo.TestUtils
{
    public class ExcelDataReading_MicrosoftOfficeInteropExcel
    {

        public static List<string> ReadExecl_MicrosoftOfficeInteropExcel(string fileName, string sheetName)
        {
            List<string> rowValue = new List<string>();
            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook wsBook = excelapp.Workbooks.Open(fileName);
            Excel._Worksheet wSheet = wsBook.Sheets[sheetName];
            Excel.Range range1 = wSheet.UsedRange;
            int wsheetRowCount = range1.Rows.Count;
            int wsheetColumnCount = range1.Columns.Count;
            for (int i = 2; i <= wsheetRowCount; i++)
            {
                for (int j = 1; i <= wsheetColumnCount; j++)
                {
                    rowValue.Add(range1.Cells[i, j]).ToString();
                }
            }

            Console.WriteLine(rowValue[0] + " - " + rowValue[1] + " - " + rowValue[2]);
            rowValue.Clear();

            return rowValue;

        }

    }
}
