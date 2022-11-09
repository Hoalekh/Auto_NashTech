using CoreFramework.NUnitTestSetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.ProjectPOM
{
    internal class ProjectPOM : NUnitTestSetUp
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://www.google.com/";
        }
        [TearDown]
        public void TearDown()
        {

        }
    }


}
