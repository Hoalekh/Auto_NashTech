using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Pages;

using System.Collections.Generic;
using CoreFramework.CoreDriver;

namespace Automation.Pages
{
    internal class ResultPages : WebDriverAction
    {


        public ResultPages(IWebDriver? driver) : base(driver)
        {

        }
       
        public void CheckTitlePage(string key)
        {
            Thread.Sleep(3000);
            string pageTitle = driver.Title;

           CheckTitle(pageTitle);

        }
        public void FirstResult(string xpathpage)
        {
            //IWebElement searchButton = _driver.FindElement(By.XPath(target_xpath));
            Click(xpathpage);


        }

    }
}
