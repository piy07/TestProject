using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace TestProject
{
    class Second5
    {
        //initializing driver
        public IWebDriver driver;
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.savemoneyindia.com/");
        }

        //closing browser after every test run
        public void Close()
        {
            driver.Close();
        }

        //Page sections test
        [TestMethod]
        public void PageSectionsTest()
        {
            Init();
            IWebElement topDeals = driver.FindElement(By.Id("text-10"));
            Assert.IsTrue(topDeals.Displayed);
            IWebElement recentComments = driver.FindElement(By.Id("recent-comments-3"));
            Assert.IsTrue(recentComments.Displayed);
            IWebElement recentPosts = driver.FindElement(By.Id("recent-posts-4"));
            Assert.IsTrue(recentPosts.Displayed);
            Close();
        }


        //Search test
        [TestMethod]
        public void SearchTest()
        {
            Init();
            IWebElement searchBox = driver.FindElement(By.Id("s"));
            Assert.IsTrue(searchBox.Enabled);
            IWebElement searchIcon = searchBox.FindElement(By.XPath("//input[@type='image']"));
            Assert.IsTrue(searchIcon.Displayed);
            searchBox.SendKeys("games");
            searchIcon.Click();
            string actualURL = driver.Url;
            StringAssert.Contains(actualURL, "games");
            Close();
        }

        // Test for search results
        [TestMethod]
        public void SearchResultTest()
        {
            Init();
            IWebElement searchBox = driver.FindElement(By.Id("s"));
            searchBox.SendKeys("games" + Keys.Enter);
            List<string> searchResults = new List<string>();
            ReadOnlyCollection<IWebElement> searchItems = driver.FindElements(By.CssSelector(".entry-box .entry-title"));
            foreach (IWebElement search in searchItems)
            {
                StringAssert.Contains(search.Text.ToLower(), "games", "search results matched");
            }
            Close();
        }

        //Ads show page reply section test
        [TestMethod]
        public void AdShowPageReplyTest()
        {
            Init();
            IWebElement firstAd = driver.FindElement(By.XPath("((//div[contains(@id, 'post')])[1]//a)[1]"));
            firstAd.Click();
            IWebElement name = driver.FindElement(By.Id("author"));
            Assert.IsTrue(name.Displayed);
            Assert.IsTrue(name.Enabled);
            IWebElement email = driver.FindElement(By.Id("email"));
            Assert.IsTrue(email.Displayed);
            Assert.IsTrue(name.Enabled);
            IWebElement comment = driver.FindElement(By.Id("comment"));
            Assert.IsTrue(comment.Displayed);
            Assert.IsTrue(comment.Enabled);
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            Assert.IsTrue(submitButton.Displayed);
            Assert.IsTrue(submitButton.Enabled);
            submitButton.Click();
            IWebElement pageMessage = driver.FindElement(By.Id("error-page"));
            Assert.IsTrue(pageMessage.Displayed);
            string pageMsg = pageMessage.Text;
            StringAssert.Contains(pageMsg, "ERROR", "Text Matched");
            Close();
        }

    }
}
