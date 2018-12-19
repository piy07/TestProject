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
    [TestClass]
    public class FirstTestClass
    {
        public IWebDriver driver;
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.savemoneyindia.com/");
        }

        public void Close()
        {
            driver.Close();
        }

        [TestMethod]
        public void SaveMoneyIndiaTitle()
        {
            Init();
            string expectedResult = "SaveMoneyIndia | The Best Online Shopping Deals, Coupons & Freebies";
            string actualResult;
            actualResult = driver.Title;
            Assert.IsTrue(actualResult.Contains(expectedResult), "Test Passed");
            Close();
        }

        [TestMethod]
        public void Search()
        {
            Init();
            //IWebDriver driver = new ChromeDriver();
            string link = "Nokia Mobiles upto 30% off from Rs. 949 – Amazon";
            //driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl("https://www.savemoneyindia.com/");
            driver.FindElement(By.Id("s")).SendKeys("Nokia");
            driver.FindElement(By.ClassName("submit")).Click();
            IWebElement actualink = driver.FindElement(By.LinkText("Nokia Mobiles upto 30% off from Rs. 949 – Amazon"));
            string text = actualink.Text;
            Assert.IsTrue(text.Contains(link), "Test Passed");
            Close();
        }

        [TestMethod]

        public void MenuCategoriesTest()
        {
            Init();

            string[] arrayCatg = new string[8] { "Multiple Categories", "Mobiles", "Recharge", "Computers & Tablets", "Electronics & Appliances", "Clothing", "Home & Kitchen", "Kids & Baby" };
            List<string> items = new List<string>();
            ReadOnlyCollection<IWebElement> category = driver.FindElements(By.XPath("//ul[@id = 'cat-nav']/li[contains(@id, 'menu-item')]/a"));
            foreach (IWebElement wb in category)
            {
                items.Add(wb.Text);
            }
            CollectionAssert.AreEqual(items, arrayCatg);

            Close();


        }

        public void PaginationCommon()
        {

            IWebElement pagination = driver.FindElement(By.CssSelector(".wp-pagenavi"));
            //Actions action = new Actions(driver);

            //action.MoveToElement(pagination).Build().Perform();
            Assert.IsTrue(pagination.Displayed);
            IWebElement page2 = driver.FindElement(By.XPath("//div[@class = 'wp-pagenavi']//a[1]"));
            page2.Click();
        }

        [TestMethod]

        public void PaginationTest()
        {
            Init();
            string page2Url = "https://www.savemoneyindia.com/page/2/";
            string page1Url = "https://www.savemoneyindia.com/";
            PaginationCommon();

            string url = driver.Url;
            Assert.IsTrue(url.Contains(page2Url), "Test Passed");
            driver.Navigate().Back();
            url = driver.Url;
            Assert.IsTrue(url.Contains(page1Url), "Test passed");
            Close();
        }

        [TestMethod]

        public void PaginationPageLinksTest()
        {
            Init();
            PaginationCommon();
            List<string> linkText2 = new List<string>();
            ReadOnlyCollection<IWebElement> linkItems2 = driver.FindElements(By.CssSelector(".entry-box .entry-title"));
            foreach (IWebElement link in linkItems2)
            {
                linkText2.Add(link.Text);
            }
            driver.Navigate().Back();
            List<string> linkText1 = new List<string>();
            ReadOnlyCollection<IWebElement> linkItems1 = driver.FindElements(By.CssSelector(".entry-box .entry-title"));
            foreach (IWebElement link in linkItems1)
            {
                linkText1.Add(link.Text);
            }
            //Assert by comparing both lists
            CollectionAssert.AreNotEquivalent(linkText1, linkText2);
            //CollectionAssert.AllItemsAreUnique(linkText1, linkText2, "Unique Links");

            Close();
        }

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

        [TestMethod]
        public void AdsLinkTest()
        {
            Init();
            IWebElement firstAd = driver.FindElement(By.XPath(""));
            Assert.IsTrue(firstAd.Displayed);
            IWebElement firstLink = firstAd.FindElement(By.XPath(""));
            string expectedURL = firstLink.GetAttribute("href"); 
            Assert.IsTrue(firstLink.Displayed);
            firstLink.Click();
            ReadOnlyCollection<string> tabs = driver.WindowHandles;
            tabs.IndexOf("1");
            //driver.SwitchTo().Window;
            string actualURL = driver.Url;
            Assert.IsTrue(expectedURL.Contains(expectedURL));
        }


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
            StringAssert.Contains(pageMsg, "ERROR", "Text MAtched");
            Close();
        }


        #region
        //[TestMethod]
        //public void FirefoxMethod()
        //{
        //    IWebDriver driver = new FirefoxDriver();
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl("https://www.savemoneyindia.com/");
        //    driver.Close();
        //}

        //[TestMethod]
        //public void IEMethod()
        //{
        //    IWebDriver driver = new InternetExplorerDriver();
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl("https://www.savemoneyindia.com/");
        //    driver.Quit();
        //}
        #endregion

    }
}
