using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class PlayPause
    {
        IWebDriver driver;

        [Test]

        public void PlayPauseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.microsoft.com/en-in/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);
            //IWebElement ele = driver.FindElement(By.XPath("//button[contains(@data-m,'Pause')]"));
             

            IWebElement button = driver.FindElement(By.CssSelector(".glyph-pause"));
            Assert.IsTrue(button.Displayed);

            Task.Delay(4000).Wait();
            Actions act = new Actions(driver);
            act.MoveToElement(button).Build().Perform();
            Task.Delay(10000).Wait();
            IWebElement tootip = driver.FindElement(By.Id("coreui-hero-q4ifivkplaypause"));
            StringAssert.Contains("Pause", tootip.Text);
            driver.Quit();
        }
    }
}
