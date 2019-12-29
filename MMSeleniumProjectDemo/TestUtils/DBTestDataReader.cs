using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo.TestUtils
{
    public class DBTestDataReader : ITestDataReader
    {

        private Hashtable identifiersTable = null;
        private String queryString = null;
        private String dbType = null;
        private DataTable dTable = null;
        private String fileName;

        public DBTestDataReader(string fileName)
        {

            this.fileName = fileName;
        }

        private void getQueryDetails(String key)
        {

  

            if (fileName.Contains(".txt"))
            {
                ITestDataReader tdReader = new TextTestDataReader(fileName);
                dbType = tdReader.getDataAsString(key + "_dbtype");
                queryString = tdReader.getDataAsString(key + "_query");
            }
        }



        public String getDataAsString(String columnName)
        {

            String dataString = "";

            TestDataUtils tdUtils = new TestDataUtils();
            dataString = tdUtils.getDataAsStringByColumnName(dTable, columnName);

            return dataString;
        }



        public List<String> getDataAsList(String columnName)
        {

            List<String> dataList = null;

            TestDataUtils tdUtils = new TestDataUtils();
            dataList = tdUtils.getDataAsListByColumnName(dTable, columnName);

            return dataList;
        }

        public string getDataAsString(string columnName, string rowName)
        {
            throw new NotImplementedException();
        }
    }
}
