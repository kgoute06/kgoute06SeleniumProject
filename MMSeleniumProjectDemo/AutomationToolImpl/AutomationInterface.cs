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
        public abstract void OpenURL(string appUrl);
        public abstract void EnterTextbyLocator(string locatorName, string pathFindlocator, string testData="");
        
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

        public abstract void ScrollPage(string scrolloption);
        public abstract void ClickFirstElement(string locatorName, string pathFindlocator);

        public abstract void WaitTillElementAppears(string locatorName, string pathFindlocator, int timeout);
        public abstract void WaitTillElementIsClickable(string locatorName, string pathFindlocator, int timeout);
        public abstract void UnselectAllCheckboxes(string locatorName, string pathFindlocator);
        public abstract void SelectSingleCheckbox(string locatorName, string pathFindlocator);

        /// <summary>
        /// check if the driver is active or closed and return true or false accordingly
        /// </summary>
        /// <returns></returns>
        public abstract bool isChildWindowClosed();

        public abstract void Doubleclick(string locatorName, string pathFindlocator);

        public abstract String GetCurrentPageURL();

        public abstract void CloseDriverInstances();
        public abstract List<String> FindChildElementText(string locatorName, string pathFindlocator);









    }

}
