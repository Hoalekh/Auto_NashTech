using Automation.Pages;
using Automation.ProjectTestSetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.TestCase
{
    public class AddNewEmployeeTest: NUnitWebTestSetUp
    {
        private String titleElement = "Elements";


        private String ElementXpath = "//div[@class='main-header']";
        
        private String FristName = "Le";
        private String LastName = "Hoa";
        private String Email = "hoale@example.com";
        private String Age = "21";
        private String Salary = "50000000";
        private String Department = "Tester";

        [Test]
        public void CreatNewEmployeeTest()

        { /*
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
            AddNewEmployee addNewEmployee =new AddNewEmployee(_driver);
            addNewEmployee.ClickBtnAdd();
            addNewEmployee.AddEmployee(FristName, LastName, Email, Age, Salary, Department);

        }

        
    }
}
