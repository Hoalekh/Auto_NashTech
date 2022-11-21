using CoreFramework.CoreDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Automation.Pages;
using CoreFramework.CoreDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using Automation.ProjectTestSetUp;
using Automation.DAO;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Automation.Pages
{
    [TestFixture]
    public class UpdatePopUp: WebDriverAction
    {
        
        public UpdatePopUp(IWebDriver driver): base(driver)
        {

        }
        private String btnEdit = "//span[@id=\"edit-record-3\"]";

        private String btnSubmit = "//*[@id=\"submit\"]";
        private String FristName = "//*[@id=\"firstName\"]";
        private String LastName = "//*[@id=\"lastName\"]";
        private String Email = "//*[@id=\"userEmail\"]";
        private String Age = "//*[@id=\"age\"]";
        private String Salary = "//*[@id=\"salary\"]']";
        private String Department = "//*[@id=\"department\"]";
        public void ClickBtnEdit()
        {
            IsElementDisplay(btnEdit);

            String scrollElementIntoMiddle = "arguments[0].scrollIntoView({behavior: 'auto',block: 'center',inline: 'center'});";
            ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, FindElementByXpath(btnEdit));
            Click(btnEdit);


        }
        
        public void UpdateNameEmployee(string firstname)
        {
            IWebElement element = new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(FristName)));
            element.Click();
            element.Clear();
            SendKeys(FristName, firstname);
            Click(btnSubmit);

        }

        public void VerifyDataUpdate(string xpath, string title)
        {
            IsElementDisplay(xpath);
            if (title.Equals(GetText(xpath)))
            {
                Console.WriteLine(" Data is corrected");
            }
            else
            {
                Console.WriteLine("Data is not corrected. Expected: " + title +
                    "Text is displayed:" + GetText(xpath));

            }

        }

    }
}
