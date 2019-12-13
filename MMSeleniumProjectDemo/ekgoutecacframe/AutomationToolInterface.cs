//using OpenQA.Selenium;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using OptumAutomationFramework.FrameworkComponents.Interface;
//using OptumAutomationFramework.FrameworkComponents.TestDataManagement;

//namespace eCACAutomationTests.WebDriverImpl
//{
//    public abstract class AutomationToolInterface
//    {
//        // Text Box Operations
//        public abstract void EnterText(ILocator locator, TestData testData);       
//        // Click Operations
       
//        public abstract void ClickElement(ILocator locator, TestData testData);
//        public abstract void ClickFirstElement(ILocator locator, TestData testData);        
//        public abstract void ClickElementWithSendKeys(ILocator locator);
//        public abstract void ClickLink(ILocator locator, TestData testData);
//        public abstract void RightClick(ILocator locator);
//        public abstract void highlightElement(ILocator locator);
//        // Wait Operations
//        public abstract void WaitTillElementAppears(ILocator locator, int timeout);
//        public abstract void WaitTillElementDisappears(ILocator locator, int timeout);
//        // Select Operations
//        public abstract void UnselectAllCheckboxes(ILocator locator, TestData testData);
//        public abstract void SelectSingleCheckbox(ILocator locator, TestData testData);
//        public abstract void UnselectSingleCheckbox(ILocator locator, TestData testData);
//        public abstract void SelectRadioButton(ILocator locator, TestData testData);
//        public abstract void SelectItemFromListBox(ILocator locator, TestData testData);
//        public abstract void SelectItemFromDropdown(ILocator locator, TestData testData);
//        public abstract List<String> FindChildElementText(ILocator locator);
//        public abstract Hashtable GetCheckboxEnabledProperty(ILocator locator);

//        // Get Operations
//        public abstract string GetCurrentPageTitle();
//        public abstract string getCssProperty(ILocator locator, TestData testData);
//        public abstract string GetText(ILocator locator, TestData testData);
//        public abstract IList<string> GetTextAsList(ILocator locator, TestData testData);
//        public abstract string GetElementPropertyValue(ILocator locator, TestData testData);
//        public abstract int getRowCountWebTable(ILocator locator,bool waitForElement=true);      
//        // Other Operations
//        public abstract void OpenURL(TestData testData);
        
//        public abstract void switchContext();
//        public abstract Boolean isElementPresent(ILocator locator);
//        public abstract Boolean isElementPresentNow(ILocator locator);
//        public abstract Boolean isElementVisible(ILocator locator);
//        public abstract Boolean isElementVisibleNow(ILocator locator);
//        public abstract Boolean isElementEnabled(ILocator locator);       
//        public abstract void SwitchWindow();
       
//        public abstract void swithcToChildWindow();
//        public abstract void swithcToParentWindow();
//        public abstract void getParentAndChildWindowHandles();
//        public abstract void MoveToElement(ILocator locator, TestData testData);
//        public abstract void Doubleclick(ILocator locator);
//        public abstract string GetElementText(ILocator locator);
       
       
//        //Close operations
//        public abstract void CloseBrowser();
//        public abstract void ClickMRN(ILocator mrncolumn, TestData testData, string mrn);
//       // public abstract void ClickRadio(ILocator locator, TestData testData);
//        public abstract void CloseDriverInstances();
//        public abstract void Quit();

//        public abstract string GetAttributeValueCodeSummarycodeTitleTooltip(ILocator locator);
       
//    }
//}
