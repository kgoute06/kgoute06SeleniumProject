using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo.TestUtils
{
    public class TextTestDataReader : ITestDataReader
    {
        Hashtable dataTable = new Hashtable();

        public TextTestDataReader(String filename)
        {
            var lines = File.ReadLines(filename);
            foreach (String line in lines)
            {
                String[] lineSplit = line.Split(':');
                String key = lineSplit[0].Trim();
                String value = lineSplit[1].Trim();
                dataTable.Add(key, value);
            }
        }
        public string getDataAsString(string columnName)
        {
            return dataTable[columnName].ToString();
        }

        public string getDataAsString(string columnName, string rowName)
        {
            return dataTable[columnName].ToString();
        }

        public List<string> getDataAsList(string columnName)
        {
            List<string> dataAsList = new List<string>();

            String dataRow = dataTable[columnName].ToString();
            String[] splitRow = dataRow.Split(',');
            int i = 0;
            while (i < splitRow.Length)
            {
                dataAsList.Add(splitRow[i]);
                i++;
            }

            return dataAsList;
        }
    }
}
