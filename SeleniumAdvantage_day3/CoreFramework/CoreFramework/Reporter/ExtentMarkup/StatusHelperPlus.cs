using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Reporter.ExtentMarkup
{
    public class StatusHelperPlus
    {
        public class Status //This is the jSON status
        {
            public bool error { get; set; }
            public int code { get; set; }
            public string type { get; set; }
            public string message { get; set; }
        }
        public class Validations
        {
            public Status statusObject { get; set; }


            public Validations(Status statusObject, int userid)
            {
                this.statusObject = statusObject;

            }

            public void StatusValidations()
            {
                switch (statusObject.code)
                {
                    case 200:
                        bool actualError200 = statusObject.error;
                        string actualType200 = statusObject.type;
                        string actualMessage200 = statusObject.message;

                        Assert.IsFalse(actualError200, $"Status error is mismatch");
                        Assert.AreEqual("success", actualType200, $"Status type is mismatch");
                        Assert.AreEqual("Success", actualMessage200, $"Status message is mismatch");
                        break;

                    case 400:
                        bool actualError400 = statusObject.error;
                        string actualType400 = statusObject.type;
                        string actualMessage400 = statusObject.message;

                        Assert.IsTrue(actualError400, $"Status error is mismatch");
                        Assert.AreEqual("bad request", actualType400, $"Status type is mismatch");
                        Assert.AreEqual("Authorization Information is incorrect", actualMessage400, $"Status message is mismatch");
                        break;

                    case 401:
                        bool actualError401 = statusObject.error;
                        string actualType401 = statusObject.type;
                        string actualMessage401 = statusObject.message;

                        Assert.IsTrue(actualError401, $"Status error is mismatch");
                        Assert.AreEqual("Unauthorized", actualType401, $"Status type is mismatch");
                        Assert.AreEqual("Authentication Failure", actualMessage401, $"Status message is mismatch");
                        break;

                    case 403:
                        bool actualError403 = statusObject.error;
                        string actualType403 = statusObject.type;
                        string actualMessage403 = statusObject.message;

                        Assert.IsTrue(actualError403, $"Status error is mismatch");
                        Assert.AreEqual("forbidden", actualType403, $"Status type is mismatch");
                        Assert.AreEqual("user is not authorized to access this User", actualMessage403, $"Status message is mismatch");
                        break;

                    case 404:
                        bool actualError404 = statusObject.error;
                        string actualType404 = statusObject.type;
                        string actualMessage404 = statusObject.message;

                        Assert.IsTrue(actualError404, $"Status error is mismatch");
                        Assert.AreEqual("not found", actualType404, $"Status type is mismatch");

                        break;

                    default:
                        break;

                }
            }
        }
    }
}
