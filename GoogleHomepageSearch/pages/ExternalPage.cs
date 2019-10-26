using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHomepageSearch.pages
{
    public class ExternalPage
    {
        private IWebDriver driver;

        public ExternalPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region locators

        #endregion

        #region actions

        public string GetTitle()
        {
            return driver.Title;
        }
        #endregion
    }
}
