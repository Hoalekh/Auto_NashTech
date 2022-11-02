using Automation.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CoreFramework.NUnitTestSetUp;
using Automation.Pages;
using Automation.ProjectTestSetUp;
namespace TestCase

{


    [TestFixture]
    public class CaptureScreen : ProjectTestSetUp
    {
        [SetUp]
        public void Setup()
        {
        }
       
        [Test]
        public void TestCaptureScreenGoogle()
        {
            
            _driver.Navigate().GoToUrl("https://google.com");
            var searchBox = _driver.FindElement(By.CssSelector("[name='q'"));
            if (searchBox != null)
            {
                searchBox.SendKeys("ABC");
            }
            // Sele command to take screenshot
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile($"Downloads", ScreenshotImageFormat.Png);
            _driver.Quit();
        }

    }
    }


