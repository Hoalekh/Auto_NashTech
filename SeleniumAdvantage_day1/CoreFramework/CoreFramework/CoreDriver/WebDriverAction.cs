using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                TestContext.Write("Click into element" + e.ToString + "passed");
            }
            catch(Exception ex)
            {
                throw ex;
                TestContext.Write("Click into element" + e.ToString + "failed");
            }
        }
        public void Click(String locator)
        {
            
            try
            {
                FindElementByXpath(locator).Click();
                TestContext.Write("Click into element" + locator + "passed");
            }
            catch (Exception ex)
            {
                throw ex;
                TestContext.Write("Click into element" + locator + "failed");
            }
        }
        public void SendKeys(String locator, String key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                TestContext.Write("Send key into element" + locator + "passed");
            }
            catch (Exception ex)
            {
                throw ex;
                TestContext.Write("Send key into element" + locator + "failed");
            }
        }
        public void CheckTitle(string tilte)
        {

           
            string pageTitle = driver.Title;
            try
            {
                if (pageTitle.Equals(tilte))
                {
                    Console.WriteLine("Title of page is correct.");

                }
                else
                {
                    Console.WriteLine("Title of page is not correct.");
                    Console.WriteLine("Title of page is " + pageTitle);
                    Console.WriteLine("Title of requirment " + tilte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                TestContext.Write("CheckTitle is failed");
            } 

        }
        public void TestCaptureScreenGoogle()
        {
            // Sele command to take screenshot
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile($"C:\\Users\\hoale\\Desktop\\Auto_NashTech\\SeleniumAdvantage_day1\\CoreFramework\\CoreFramework\\CaptureScreen", ScreenshotImageFormat.Png);
          
        }

    }
}
