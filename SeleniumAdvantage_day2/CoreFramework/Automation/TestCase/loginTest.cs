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
using Automation.ProjectTestSetUp;
namespace TestCase

{


    [TestFixture]
    public class loginTest : ProjectTestSetUp
    {
     /*
        [Test]
        public void Id1_login()
        {

            loginPage loginPage = new loginPage(_driver);
            loginPage.inputUserName("test");
        }

        [Test]
        public void Id2_loginfail()
        {

            HomePage getvideo = new HomePage(_driver);
            getvideo.inputUserName("test");
        }*/
        

        [Test]
        public void InputSearch1()

        {


            string key = "Waiting for you anh yeu em hoho";

            Search googleSearch = new Search(_driver);
            googleSearch.BrowserCommandTests(key);

         

        }
        [Test]
        public void CheckTitlePage()

        {
          
            string xpathpage = "(//div[@id='search']//a/h3)[1]";
            string key = "Waiting for you anh yeu em hoho";

            Search googleSearch = new Search(_driver);
            ResultPages titlePage = new ResultPages(_driver);

            googleSearch.BrowserCommandTests(key);
            titlePage.CheckTitlePage(key);


        }
        [Test]
        public void FristResult()

        {

            string xpathpage = "(//div[@id='search']//a/h3)[1]";
            string key = "Waiting for you anh yeu em hoho";

            Search googleSearch = new Search(_driver);
            ResultPages Page = new ResultPages(_driver);

            googleSearch.BrowserCommandTests(key);
          
            Page.FirstResult(xpathpage);

        }

    }
    }


