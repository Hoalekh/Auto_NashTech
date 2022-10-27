using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_3.Page
{
    internal class ResultPages
    {


        protected IWebDriver _driver;
        public ResultPages(IWebDriver? driver)
        {
            _driver = driver;
        }
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);

        }

        public void CheckTitle(string a)
        {
            Thread.Sleep(3000);
            string pageTitle = _driver.Title;

            if (pageTitle.Equals(a))
            {
                Console.WriteLine("Title of form is correct: ");

            }
            else
            {
                Console.WriteLine("Title of form is not correct");
                Console.WriteLine(pageTitle + " auto");
                Console.WriteLine(a);
            }

        }
    }
}
