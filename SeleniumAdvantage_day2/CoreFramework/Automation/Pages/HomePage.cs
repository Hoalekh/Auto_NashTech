using Automation.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
namespace Automation.Pages
{
    public class HomePage : HeaderPage
    {
        public HomePage(IWebDriver? driver) : base(driver)
        {
        }

        private readonly By videoTitles = By.XPath("//*[@id='video-title']");
        private readonly String _username = "//input[@name='5uid']";
        public void inputUserName(string UserName)
        {
            SendKeys(_username, UserName);
        }
        public IList<IWebElement>? GetVideoTitles()
        {
            return _driver?.FindElements(videoTitles);
        }

        
    }
}
