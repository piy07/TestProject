using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using System.Threading;

namespace MultipleBrowserTesting
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class BlogTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver _driver;

        [Test]
        public void Can_Visit_Google()
        {
            _driver = new TWebDriver();

            // Navigate
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://www.google.com/");
        }

        [TearDown]
        public void FixtureTearDown()
        {
            if (_driver != null)
                _driver.Close();
        }
    }
}