using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo.TestUtils
{
    public interface ITestDataReader
    {

        String getDataAsString(String columnName);

        String getDataAsString(String columnName, String rowName);


    }
}
