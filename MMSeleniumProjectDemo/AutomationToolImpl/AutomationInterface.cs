using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACSUTestAutomation.AutomationToolImpl
{
    public abstract class AutomationInterface
    {
        public abstract void EnterTextbyLocator(string locatorName, string pathFindlocator, string testData="");
        public abstract void OpenURL(string appUrl);
        public abstract void CloseandQuitApp();
        public abstract void ClickElement(string locatorName, string pathFindlocator);
        public abstract string TakeScreenshot(string screenShotName);
        public abstract bool SelectingCheckBox_RadioButton(string locatorName, string pathFindlocator, string message = ""); 
        public abstract string DropdownSelectByText(string locatorName, string pathFindlocator, string dropdownTextName);

        public abstract List<string> MultipleDropdownSelectByText(string locatorName, string pathFindlocator, string dropdownTextName1,string dropdownTextName2);
        public abstract string GetElementText(string locatorName, string pathFindlocator);
        public abstract void CustomImplicitWait(int seconds);

        public abstract void SwitchToFrame(string frameName);
        public abstract string GetTextOnAlert();
        public abstract string PromptAlert(string TestdataforPromptTextbox);

        public abstract void SwitchBetweenDifferentWindows(string windowTitle, int timeout = 90);

        public abstract string GetTextFromTable(string locatorName, string pathFindlocator,string expectedText);
     

       





    }

}
