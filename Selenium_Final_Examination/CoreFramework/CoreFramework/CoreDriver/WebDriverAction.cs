using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using CoreFramework.Reporter;

namespace CoreFramework.CoreDriver
{
    public class WebDriverAction
    {
        public IWebDriver driver;
        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }
        public By ByXpath(String locator)
        {
            return By.XPath(locator);
        }
        public String getTitle()
        {
            return driver.Title;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            HtmlReport.Pass("Go to Url: "+url);
        }
        public IWebElement FindElementByXpath(String locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            hightlightElement(e);
            return e;
        }
        public IList<IWebElement> FindElementsByXpath(String locator)
        {
            return driver.FindElements(ByXpath(locator));
        }
        public IWebElement hightlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border='2px solid red'",element);
            return element;
        }

        public void Click(IWebElement e)
        {
            try
            {
                hightlightElement(e);
                e.Click();
                TestContext.Write("Click into element " + e.ToString + " passed ");
                HtmlReport.Pass("Click into element " + e.ToString + " passed ");
            }
            catch(Exception ex)
            {
                
                TestContext.Write("Click into element " + e.ToString + " failed ");
                HtmlReport.Fail("Click into element failed ", TakeScreenshot());
                throw ex;
            }
        }
        public void Click(String locator)
        {
            
            try
            {
                FindElementByXpath(locator).Click();
                TestContext.Write("Click into element " + locator + " passed. ");
                HtmlReport.Pass("Click into element" + locator + " passed ");
            }
            catch (Exception ex)
            {
               
                TestContext.Write("Click into element " + locator + " failed ");
                HtmlReport.Fail("Click into element " + locator + " failed ", TakeScreenshot());
                throw ex;
            }
        }
         public void IsElementDisplay(String locator)
        {
            
            try
            {
                FindElementByXpath(locator);
                TestContext.Write("Find element " + locator + " passed. ");
                HtmlReport.Pass("Find element " + locator + " passed. ");
            }
            catch (Exception ex)
            {
               
                TestContext.Write("Find element " + locator + " failed. ");
                HtmlReport.Fail("Find element " + locator + " failed", TakeScreenshot());
                throw ex;
            }
        }
        public void SendKeys(String locator, String key)
        {
            try
            {

                FindElementByXpath(locator).SendKeys(key);
                TestContext.Write("Send key into element" + locator + "passed. ");

                HtmlReport.Pass("senkey into element" + locator + "passed. ");
            }
            catch (Exception ex)
            {
               
                TestContext.Write("Send key into element" + locator + "failed. ");

                HtmlReport.Fail("senkey into element" + locator + "failed", TakeScreenshot());
                throw ex;
            }
        }

      
        public string TakeScreenshot()
       {
            string path = HtmlReportDirectory.SCREENSHOT_PATH+("/screenshot_"+DateTime.Now.ToString("yyyyMMddHHmmss"))+".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path,ScreenshotImageFormat.Png);
            return path;
        }

        public void Back()
        {
            driver.Navigate().Back();
        }

        public String GetText(string locator)
        {
            try
            {
                string element = FindElementByXpath(locator).Text;
                HtmlReport.Pass("Text is correct: " +locator);
                return element;

            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Text is not correct: "+ locator, TakeScreenshot());
                throw ex;
            }
           

        }
    }
}
