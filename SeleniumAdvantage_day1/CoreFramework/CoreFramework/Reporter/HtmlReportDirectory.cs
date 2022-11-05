using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Reporter
{
    internal class HtmlReportDirectory
    {
        public static string REPORT_ROOT { get; set; }
        public static string REPORT_FOLDER_PATH { get; set; }
        public static string REPORT_FILE_PATH { get; set; }
        public static string SCREENSHOT_PATH { get; set; }

        public static void InitReportDirection()
        {
            string projectPath = FilePath.GetCurrentDirectoryPath();
        }

        private static void checkExistReportAndRename()
        {

        }
    }
}
