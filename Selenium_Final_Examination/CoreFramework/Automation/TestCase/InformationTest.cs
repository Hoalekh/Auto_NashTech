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
using Automation.Common;
using Automation.ProjectTestSetUp;
using System.Net;
using Automation.DAO;

namespace TestCase

{


    [TestFixture]
    public class InformationTest : NUnitWebTestSetUp
    {
        private String titleElement = "Elements";
    

        private String ElementXpath = "//div[@class='main-header']";

        [Test]
        public void VerifyDefaultInfor()

        {
            HomePage homePage = new HomePage(_driver);
            /*
             * 1.Go to the application
             * 2.Select section: Element and verify web redirected correctly (url = baseurl + /elements)
             * 3.On the Menu bar, select WebTable
             * 4.Verify WebTable screen is displayed
             */

            ElementPage elementPage = new ElementPage(_driver);
            elementPage.GetToElement();
            elementPage.VerifyElement(ElementXpath, titleElement);
            //verify go to HomePage
            WebTables webTables = new WebTables(_driver);
            webTables.CliclItmWebTables();

        }
      




    } 
}
    


