using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHomepageSearch
{
    public class HomePage
    {

        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region elements

        private IWebElement SearchText
        {
            get { return driver.FindElement(By.Name("q")); }
        }

        private IWebElement SearchButton
        {
            get { return driver.FindElement(By.Name("btnK")); }
        }

        private IList<IWebElement> suggestionsList
        {
            get {

                var element = driver.FindElement(By.CssSelector("ul[role='listbox'] li"));
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(condition => element.Displayed);
                return driver.FindElements(By.CssSelector("ul[role='listbox'] li"));
            }
        }

        #endregion


        #region actions

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
        }

        public void EnterText(string text)
        {
            SearchText.SendKeys(text);
        }

        public void ClickOnSearchButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(condition => SearchButton.Displayed && SearchButton.Enabled);
            SearchButton.Click();
        }

        public List<string> GetSuggestionsList()
        {
            return suggestionsList.Select(x => x.Text).ToList();
        }

        internal void ClickOnFirstSuggestion()
        {
            suggestionsList.ElementAt(0).Click();
        }
        #endregion
    }
}
