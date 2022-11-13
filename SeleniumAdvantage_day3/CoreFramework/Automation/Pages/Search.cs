using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Automation.Pages;

using System.Collections.Generic;
using CoreFramework.CoreDriver;

namespace Automation.Pages
{
    internal class Search : WebDriverAction
    {


        public Search(IWebDriver? driver) : base(driver)
        {
           
        }
        

        private readonly String _Xpath = "//*[@class='gLFyf gsfi']";
        public void BrowserCommandTests(string key)
        {
            
            IWebElement searchBox = driver.FindElement(By.XPath(_Xpath));
            SendKeys(_Xpath, key);
           
            searchBox.SendKeys(Keys.Enter);
           

         }
        
      
        
   
    }

}
