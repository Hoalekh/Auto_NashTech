using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium2
{
    [TestFixture]
    public class Tests
    {
        protected WebDriverWait? _wait;
        protected IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        }

        [Test]
        public void BrowserCommandTests()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Console.WriteLine($"the website is opened successfully");
            String target_xpath = "//*[@id=\"contact-link\"]/a";
            IWebElement SearchResult = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(target_xpath)));
            //IWebElement searchButton = _driver.FindElement(By.XPath(target_xpath));
            SearchResult.Click();
            Thread.Sleep(1000);
            
            String actual = _driver.FindElement(By.XPath("//*[@id=\"center_column\"]/h1")).Text;
            String title = "CUSTOMER SERVICE - CONTACT US";
            if (actual.Equals(title))
            {
                Console.WriteLine("Title of form is correct: ");
                
            }
            else
            {
                Console.WriteLine("Title of form is not correct");
                Console.WriteLine(actual);
            }
                
            _driver.Navigate().Back();
            String actual1 = _driver.Title;
            String title1 = "My Store";
            Thread.Sleep(1000);
            if (actual1.Equals(title1))
            {
                Console.WriteLine("Title of webpage is correct: ");
                Console.WriteLine(title1);
            }
            else
            {
                Console.WriteLine("Title of webpage is not correct");
                Console.WriteLine(actual1);
            }
               
            
            _driver.Navigate().Forward();
            Thread.Sleep(3000);
            _driver.Close();
                    
    

        }
        public IWebElement ReturnWebElement(By by)
        {
            IWebElement e = _driver.FindElement(by);
            _wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementIsVisible(by));
            return e;
        }


        public IWebElement ReturnWeb(By by)
        {
            IWebElement e = _driver.FindElement(by);
            _wait.Until(SeleniumExtras.WaitHelpers.
                    ExpectedConditions.ElementToBeClickable(by));
            return e;
        }


        public IWebElement ReturnWeb2(By by)
        {
            IWebElement e = _driver.FindElement(by);
            _wait.Until(SeleniumExtras.WaitHelpers.
                    ExpectedConditions.ElementToBeSelected(by));
            return e;
        }

        public void Click(By by)
        {
            IWebElement e = _driver.FindElement(by);
            
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            e.Click();
        }

    }
}