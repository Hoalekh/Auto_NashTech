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
using Automation.DAO;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Automation.Pages
{
    internal class AddNewEmployee : WebDriverAction
    {


        public AddNewEmployee(IWebDriver? driver) : base(driver)
        {

        }
        private String btnAdd = "//button[text()='Add']";
        private String btnSubmit = "//*[@id=\"submit\"]";
        private String FristName = "//*[@id=\"firstName\"]";
        private String LastName = "//*[@id=\"lastName\"]";
        private String Email = "//*[@id=\"userEmail\"]";
        private String Age = "//*[@id=\"age\"]";
        private String Salary = "//*[@id=\"salary\"]";
        private String Department = "//*[@id=\"department\"]";

        public void ClickBtnAdd()
        {
            IsElementDisplay(btnAdd);

            String scrollElementIntoMiddle = "arguments[0].scrollIntoView({behavior: 'auto',block: 'center',inline: 'center'});";
            ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, FindElementByXpath(btnAdd));
            Click(btnAdd);


        }
        public void AddEmployee(string firstname, string lastname, string email, string age
             , string salary, string depatment)
        {
            IWebElement element = new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(FristName)));
            SendKeys(FristName, firstname);
            SendKeys(LastName, lastname);
            SendKeys(Email, email);
            SendKeys(Age, age);
            SendKeys(Salary, salary);
            SendKeys(Department, depatment);
            Click(btnSubmit);
         }
        public void VerifyDataNew(string firstname, string lastname, string email, string age
             , string salary, string depatment)
        {
            IsElementDisplay(firstname);
            if (firstname.Equals(GetText(firstname)))
            {
                Console.WriteLine(" Data is corrected");
            }
            else
            {
                Console.WriteLine("Data is not corrected. Expected: " +firstname, 
                    lastname, email, age, salary,depatment+

                    " Text is displayed:" + GetText(firstname));

            }

        }
    }
}
