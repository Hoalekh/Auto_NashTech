using CoreFramework.CoreDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Pages
{
    public class DeleteEmployee : WebDriverAction
    {
        public DeleteEmployee(IWebDriver driver) : base(driver)
        {

        }
        private String btnDelete = "//*[@id=\"delete-record-3\"]";
        public void ClickBtnDelete()
        {
            IsElementDisplay(btnDelete);
            Click(btnDelete);


        }
        public void VerifyDataDelete(string xpath)
        {
            try
            {
                if(FindElementByXpath(xpath) == null)
                {
                    Console.WriteLine(" Data is deleted");
                }
                
                
            }
            catch(Exception e)
            {
                throw e;
                Console.WriteLine("Data is not deleted. ");
            }
            
            

        }
    }
}
