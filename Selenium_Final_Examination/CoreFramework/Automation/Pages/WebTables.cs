using Automation.Pages;
using CoreFramework.CoreDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using Automation.ProjectTestSetUp;
using System.Xml.Linq;

namespace Automation.Pages
{
    public class WebTables : WebDriverAction
    {
        public WebTables(IWebDriver? driver) : base(driver)
        {
        }

        private String itmWebTables  = "//span[text()='Web Tables']";

       
        public void CliclItmWebTables()
        {
            IsElementDisplay(itmWebTables);

            String scrollElementIntoMiddle = "arguments[0].scrollIntoView({behavior: 'auto',block: 'center',inline: 'center'});";
            ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, FindElementByXpath(itmWebTables));
            Click(itmWebTables);
        }
        public void VerifyDisplay(string xpath, string title)
        {
            if (title.Equals(GetText(xpath)))
            {
                Console.WriteLine("Title web redirected correctly");
            }
            else
            {
                Console.WriteLine("Title web did not redirect correctly");
            }

        }



    }
}