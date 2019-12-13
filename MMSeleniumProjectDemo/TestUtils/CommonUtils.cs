using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo.TestUtils
{
    public class CommonUtils
    {
        public string Splitdata(String testData, int index)
        {
            try
            {
                string[] dataarray = testData.Split('|');
                if (index < dataarray.Length)
                {
                    return dataarray[index];
                }
                else
                {
                    Assert.Fail("The Test Data index is wrong/out of range");
                    return null;
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Error occured in Splitdata Method" + e.Message);
                return null;
            }
        }
    }
}
