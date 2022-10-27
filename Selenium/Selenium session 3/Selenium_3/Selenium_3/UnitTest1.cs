using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using Selenium_3.Page;

namespace Selenium_3
{
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
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");
            string xpathpage = "(//div[@id='search']//a/h3)[1]";
            string key = "Waiting for you anh yeu em hoho";
           
            Search googleSearch = new Search(_driver);
            ResultPages titlePage = new ResultPages(_driver);
            FirstResultPage resultFirstPage = new FirstResultPage(_driver,_wait);
            googleSearch.BrowserCommandTests(key);
            titlePage.CheckTitle(key);
            resultFirstPage.FirstResult(xpathpage);

        }
    }
}