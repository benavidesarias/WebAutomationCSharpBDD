using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHomepageSearch.pages
{
    class GoogleResultPage
    {
        private IWebDriver driver;

        public GoogleResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region locator

        private IWebElement firstResult
        {
            get { return driver.FindElement(By.CssSelector(".r a h3")); }
        }

        #endregion

        #region actions

        public string GetTextFirstResult()
        {
            return firstResult.Text;
        }

        public void ClickOnFirstResult()
        {
            firstResult.Click();
        }
        #endregion
    }
}
