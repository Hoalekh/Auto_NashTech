using Automation.Pages;
using CoreFramework.CoreDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using Automation.ProjectTestSetUp;
namespace Automation.Pages
{
    public class ElementPage : WebDriverAction
    {
        public ElementPage(IWebDriver? driver) : base(driver)
    {
    }



    public string getElementPath = "elements";

    public void GetToElement()
    {
       
        GoToUrl(Constant.BASE_URL + getElementPath);

    }
    public void VerifyElement(string xpath, string title)
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
