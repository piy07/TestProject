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
    class First5
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

        //Title Test
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

        //Search an item
        [TestMethod]
        public void Search()
        {
            Init();
            string link = "Nokia Mobiles upto 30% off from Rs. 949 – Amazon";
            driver.FindElement(By.Id("s")).SendKeys("Nokia");
            driver.FindElement(By.ClassName("submit")).Click();
            IWebElement actualink = driver.FindElement(By.LinkText("Nokia Mobiles upto 30% off from Rs. 949 – Amazon"));
            string text = actualink.Text;
            Assert.IsTrue(text.Contains(link), "Test Passed");
            Close();
        }

        //Test Categories available
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

        //Using in some other test case
        public void PaginationCommon()
        {

            IWebElement pagination = driver.FindElement(By.CssSelector(".wp-pagenavi"));
            Assert.IsTrue(pagination.Displayed);
            IWebElement page2 = driver.FindElement(By.XPath("//div[@class = 'wp-pagenavi']//a[1]"));
            page2.Click();
        }

        //Pagination Page URL Test
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

        //Pagination Test for Links availability on 1 and 2 Page
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
            CollectionAssert.AreNotEquivalent(linkText1, linkText2);
            Close();
        }
    }
}
