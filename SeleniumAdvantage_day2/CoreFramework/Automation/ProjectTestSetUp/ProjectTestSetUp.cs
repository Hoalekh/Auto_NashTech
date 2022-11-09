using CoreFramework.NUnitTestSetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.ProjectTestSetUp
{
    public class ProjectTestSetUp: NUnitTestSetUp
    {
        [SetUp]
        public void SetUp()
        {
            //  _driver.Url = "https://demo.guru99.com/v4/index.php";
            _driver.Url = "https://www.google.com/";
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}
