using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_nunit_spec.page_object_models
{
    public class PlanPage : BasePage
    {
       
        public PlanPage(IWebDriver driver) : base(driver)
        { 
        }

        public String getCountry()
        {
            return driver.Url;
        }

        public String GetDestination()
        {
            return "bali";
        }

    }

   
}
