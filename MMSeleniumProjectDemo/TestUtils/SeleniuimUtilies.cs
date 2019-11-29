using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo.TestUtils
{
    public class SeleniuimUtilies
    {
        
         static List<TableDatacollection> _tabledatacollection = new List<TableDatacollection>();

        public static void ReadTable(IWebDriver d)
        {
            IWebElement table = d.FindElement(By.XPath("//table"));
            //Get All the column headers/columns from the table
            var columns = table.FindElements(By.TagName("th"));

            //Get the all the rows

            var rows = table.FindElements(By.TagName("tr"));


            int rowIndex = 0;

            foreach (var row in rows)
            {
                int columnIndex = 0;
                var columnsdata = row.FindElements(By.TagName("td"));

                foreach (var colvalue in columnsdata)
                {

                    _tabledatacollection.Add(new TableDatacollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[columnIndex].Text,
                        ColumnValue = colvalue.Text


                    });

                    columnIndex++;

                }
            
            rowIndex++;

        }
    }

        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _tabledatacollection
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();

            return data;
        }
    }

    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }
}
