using Automation.Pages;
using Automation.ProjectTestSetUp;
using FinalTest.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.TestCase
{
    public class Update_Delete_EmPloyeeTest: NUnitWebTestSetUp
    {
        private String titleElement = "Elements";
        private String ElementXpath = "//div[@class='main-header']";
        private String fristnameUpdate = "HoaLe";

        private String xpathUpdate = "//div[text()='HoaLe']";
        [Test]
        public void UpdateEmployee()

        {
            /*
             * 1.Go to the application
             * 2.Select section: Element and verify web 
             * 3. Select WebTable
             * 4.Verify WebTable screen is displayed
             * 5.Click on button update of Employee name: Kierra
             * 6.Update all information of that employee to new value and click submit
             * 7.Verify data of that employee in the table is updated correctly
             * 8.Click delete that user
             * 9.Verify that the user is no longer displayed in the table
             */
            HomePage homePage = new HomePage(_driver);
            ElementPage elementPage = new ElementPage(_driver);
            elementPage.GetToElement();
            elementPage.VerifyElement(ElementXpath, titleElement);
            //verify go to HomePage
            WebTables webTables = new WebTables(_driver);
         
            webTables.CliclItmWebTables();
            UpdatePopUp updatePopUp = new UpdatePopUp(_driver);
            updatePopUp.ClickBtnEdit();
            Thread.Sleep(3000);
            updatePopUp.UpdateNameEmployee(fristnameUpdate);
            updatePopUp.VerifyDataUpdate(xpathUpdate, fristnameUpdate);
            DeleteEmployee deleteEmployee = new DeleteEmployee(_driver);
            deleteEmployee.ClickBtnDelete();
           // Assert.False(deleteEmployee.FindElementByXpath(xpathUpdate) != null) ;

        }

    }
}
