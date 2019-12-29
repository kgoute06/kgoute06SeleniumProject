using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo.TestUtils
{
   public  class TestDataUtils
    {
        public List<String> getDataAsListByColumnName(DataTable dTable, String columnName)
        {
            List<String> dataList = new List<string>();

            foreach (DataRow oDataRow in dTable.Rows)
            {
                dataList.Add(oDataRow[columnName].ToString());
            }

            return dataList;

        }

        public String getDataAsStringByColumnName(DataTable dTable, String columnName)
        {

            String dataString = "";
            DataRow oDataRow = dTable.Rows[0];

            dataString = oDataRow[columnName].ToString();

            return dataString;
        }

    }
}
