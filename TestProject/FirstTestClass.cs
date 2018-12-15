using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace TestProject
{
    [TestClass]
    public class FirstTestClass
    {
        [TestMethod]
        public void SaveMoneyIndiaTitle()
        {
            IWebDriver driver = new ChromeDriver();
            string expectedResult = "SaveMoneyIndia | The Best Online Shopping Deals, Coupons & Freebies";
            string actualResult;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.savemoneyindia.com/");
            actualResult = driver.Title;
            Assert.IsTrue(actualResult.Contains(expectedResult), "Test Passed");
            driver.Close();
        }

        [TestMethod]
        public void Search()
        {
            IWebDriver driver = new ChromeDriver();
            string link = "Nokia Mobiles upto 30% off from Rs. 949 – Amazon";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.savemoneyindia.com/");
            driver.FindElement(By.Id("s")).SendKeys("Nokia");
            driver.FindElement(By.ClassName("submit")).Click();
            IWebElement actualink = driver.FindElement(By.LinkText("Nokia Mobiles upto 30% off from Rs. 949 – Amazon"));
            string text = actualink.Text;
            Assert.IsTrue(text.Contains(link), "Test Passed");
            driver.Close();
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
