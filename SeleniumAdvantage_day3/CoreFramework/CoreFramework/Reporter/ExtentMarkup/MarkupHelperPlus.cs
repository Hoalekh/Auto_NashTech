using AventStack.ExtentReports.MarkupUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.APICore;

namespace CoreFramework.Reporter.ExtentMarkup
{
    public class MarkupHelperPlus
    {
        public static IMarkup CreateAPIRequestLog(APIRequest request, APIResponse response)
        {
            return new APIRequestLog(request, response);
        }
    }
}