using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TestProject
{
    [TestFixture]
    public class NunitTestClass
    {
        public IWebDriver driver;

        [SetUp]
        public void init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void NavigateToGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            Thread.Sleep(5000);
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
