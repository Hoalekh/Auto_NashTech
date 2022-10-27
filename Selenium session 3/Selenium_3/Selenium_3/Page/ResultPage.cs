using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium_3.Page
{
    internal class ResultPage
    {


        
        protected IWebDriver _driver;
        protected WebDriverWait? _wait;
        public ResultPage(IWebDriver? driver, WebDriverWait? wait)
        {
            _driver = driver;
            _wait = wait;
        }
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        }

        public void ClickTitle(string a)
        {
            Thread.Sleep(3000);

            IWebElement SearchResult = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(a)));
            //IWebElement searchButton = _driver.FindElement(By.XPath(target_xpath));
            SearchResult.Click();


        }

        public void Click(By by)
        {
            IWebElement e = _driver.FindElement(by);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            e.Click();
        }

    }

}
