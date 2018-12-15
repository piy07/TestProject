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

namespace TestProject
{
    [TestFixture]
    [Parallelizable]
    public class NunitParallelTest : BaseClass
    {
        [Test]
        public void SearchGoogle()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.Name("q")).SendKeys("Piyush Verma" + Keys.Enter);
            Thread.Sleep(5000);
            driver.Quit();
        }
    }

    [TestFixture]
    [Parallelizable]
    public class NunitParallelTest2 : BaseClass
    {
        [Test]
        public void SearchGoogle2()
        {
            driverff = new FirefoxDriver();
            driverff.Manage().Window.Maximize();
            driverff.Navigate().GoToUrl("https://www.google.com/");
            driverff.FindElement(By.Name("q")).SendKeys("Aquaman" + Keys.Enter);
            Thread.Sleep(5000);
            driverff.Quit();
        }
    }
}
