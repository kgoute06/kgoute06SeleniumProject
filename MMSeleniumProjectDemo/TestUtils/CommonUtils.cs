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

        public void SendanEmail()
        {
            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();

            Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            oMsg.HTMLBody = "Selenium Webdriver Test Execution Report";
            //Add an attachment.
            String attach = "Attachment to add to the Mail";
            int x = (int)oMsg.Body.Length + 1;
            int y = (int)Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue;

            //Attach the file here
            Microsoft.Office.Interop.Outlook.Attachment oAttach = oMsg.Attachments.Add(@"c:\sagar\reports.html", y, x, attach);
            //here you can add the Subject of mail item
            oMsg.Subject = "Automation Reports of Test Execution";
            // Here you can Add the mail id to which you want to send mail.
            Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMsg.Recipients;

            Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add("Kistaiah.goute@optum.com");
            oRecip.Resolve();
        }

    }
}
