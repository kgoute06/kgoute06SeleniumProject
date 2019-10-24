using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSeleniumProjectDemo.TestUtils;

namespace MMSeleniumProjectDemo
{
    [TestClass]
    public class Test
    {
        string appUrl2 = ConfigurationManager.AppSettings["AppUrl2"];
        string browser = ConfigurationManager.AppSettings["Browser"];
        string excelPath = ConfigurationManager.AppSettings["Excelpath"];
        string sheetName = ConfigurationManager.AppSettings["sheetName"];
        [TestMethod]
        public void TestMethod1()
        {
            DataTable table1 = new DataTable("patients");
            table1.Columns.Add("name");
            table1.Columns.Add("id");
            table1.Rows.Add("sam", 1);
            table1.Rows.Add("mark", 2);

            DataTable table2 = new DataTable("medications");
            table2.Columns.Add("id");
            table2.Columns.Add("medication");
            table2.Rows.Add(1, "atenolol");
            table2.Rows.Add(2, "amoxicillin");

            // Create a DataSet and put both tables in it.
            DataSet set = new DataSet("office");
            set.Tables.Add(table1);
            set.Tables.Add(table2);

            // Visualize DataSet.
            Console.WriteLine(set.GetXml());
        }
        [TestMethod]
        public void PrintDataTable()
        {
            DataTable data = GetTable();

            // ... Loop over all rows.
            foreach (DataRow row in data.Rows)
            {
                // ... Write value of first field as integer.
                Console.WriteLine(row.Table);
            }
        }

        [TestMethod]
        public void TestDataFileConnection()
        {
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6) + @"\Data\TestData.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", path);

            string subStringTest = "Krishna goute sathvik dhurvik";
            subStringTest = subStringTest.Substring(6);
            Console.WriteLine(subStringTest);




        }

       // Read Data from excel in selenium c# using from a cell
       [TestMethod]
        public void ReadExcelData1()
        {
         List<string> data1 =   ExcelDataReading_MicrosoftOfficeInteropExcel.ReadExecl_MicrosoftOfficeInteropExcel(excelPath, sheetName);


        }


        static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }

        [TestMethod]
        public void FileStreamTest()
        {
            FileStream fs = new FileStream(@"C:\Users\kgoute\Desktop\SeleniumDemo\\csharpfile.txt", FileMode.Create);
            fs.Close();
            Console.Write("File has been created and the Path is C:\\Users\\kgoute\\Desktop\\SeleniumDemo\\csharpfile.txt");


        }

        [TestMethod]
        public void FilestreamWriting()
        {
            FileStream fs = new FileStream(@"C: \Users\kgoute\Desktop\SeleniumDemo\\csharpfile1.txt", FileMode.Append);
            byte[] bdata = Encoding.Default.GetBytes("Hello, Welcome To Selenium Training batch!");
            fs.Write(bdata, 0, bdata.Length);
            fs.Close();
            Console.WriteLine("Hello, Welcome To Selenium Training batch!");

        }

        [TestMethod]
        public void FilestreamReading()
        {
            string data;
            FileStream fsSource = new FileStream("D:\\csharpfile.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fsSource))
            {
                data = sr.ReadToEnd();
            }
            Console.WriteLine(data);


        }

        [TestMethod]

   

 

        public void GetPathofProject()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

        }

       


    }
}
