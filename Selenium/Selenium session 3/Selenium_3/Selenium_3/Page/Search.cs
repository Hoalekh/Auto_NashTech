using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium_3.Page
{
    internal class Search
    {


        protected WebDriverWait? _wait;
        protected IWebDriver _driver;
        public Search(IWebDriver? driver)
        {
            _driver = driver;
        }
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            //_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
           

        }

        
        public void BrowserCommandTests(string a)
        {

            IWebElement searchBox = _driver.FindElement(By.XPath("//*[@class='gLFyf gsfi']"));
            searchBox.SendKeys(a);
            searchBox.SendKeys(Keys.Enter);
           

         }
        
      
        
   
    }

}
