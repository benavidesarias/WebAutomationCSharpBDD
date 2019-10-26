using GoogleHomepageSearch.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace GoogleHomepageSearch.definitions
{
    [Binding]
    public class GoogleHomepageSearchSteps
    {
        private IWebDriver driver;
        private HomePage homePage;
        private GoogleResultPage resultPage;
        private ExternalPage externalPage;

        public GoogleHomepageSearchSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            homePage = new HomePage(driver);
            homePage.GoToHomePage();
        }
        
        [When(@"I type '(.*)' into the search field")]
        public void WhenITypeIntoTheSearchField(string word)
        {
            homePage.EnterText(word);
        }
        
        [When(@"I click the Google Search button")]
        public void WhenIClickTheGoogleSearchButton()
        {
            homePage.ClickOnSearchButton();
        }

        [Then(@"I go to the search results page")]
        public void ThenIGoToTheSearchResultsPage()
        {
            resultPage = new GoogleResultPage(driver);
        }

        [Then(@"the first result is '(.*)'")]
        public void ThenTheFirstResultIs(string expected)
        {
            var firstResultText = resultPage.GetTextFirstResult();
            Assert.AreEqual(expected, firstResultText);
        }

        [When(@"I click on the first result link")]
        public void WhenIClickOnTheFirstResultLink()
        {
            resultPage.ClickOnFirstResult();
        }

        [Then(@"I go to the '(.*)'")]
        public void ThenIGoToThe(string expectedPageTitle)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            externalPage = new ExternalPage(driver);
            var actualPageTitle = externalPage.GetTitle();
            Assert.AreEqual(expectedPageTitle,actualPageTitle);
        }

        [When(@"the suggestions list is displayed")]
        public void WhenTheSuggestionsListIsDisplayed()
        {
            var suggestionsList = homePage.GetSuggestionsList();
            Assert.Greater(suggestionsList.Count,1, "The suggestions list should show options");
        }
        
        [When(@"I click on the first suggestion in the list")]
        public void WhenIClickOnTheFirstSuggestionInTheList()
        {
            homePage.ClickOnFirstSuggestion();
        }
    }
}
