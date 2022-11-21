using OpenQA.Selenium;
using Automation.ProjectTestSetUp;
using Automation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Common
{
    public class CommonFlow
    {
        public static void LoginFlow(IWebDriver _driver)
        {
            UpdatePopUp loginPage = new UpdatePopUp(_driver);

          

        }
    }
}
