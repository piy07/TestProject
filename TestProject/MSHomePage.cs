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
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace TestProject
{

    class MSHomePage
    {

        IWebDriver driver;

        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.microsoft.com/en-in/");
        }
        //Test for slider play/pause button
        [Test]
        public void PlayPauseTest()
        {
            Init();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);
            try
            {
                IWebElement buttonPause = driver.FindElement(By.CssSelector(".glyph-pause"));
                Assert.IsTrue(buttonPause.Displayed);
                Task.Delay(4000).Wait();
                Actions act = new Actions(driver);
                act.MoveToElement(buttonPause).Build().Perform();
                Task.Delay(10000).Wait();
                IWebElement tootip = driver.FindElement(By.Id("coreui-hero-q4ifivkplaypause"));
                StringAssert.Contains("Pause", tootip.Text);
                buttonPause.Click();
                IWebElement buttonPlay = driver.FindElement(By.CssSelector(".glyph-play"));
                Assert.IsTrue(buttonPlay.Displayed);
                StringAssert.Contains("Play", tootip.Text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                driver.Close();
            }
        }


        [Test]
        //Test for slider image
        public void SliderTest()
        {
            Init();
            Thread.Sleep(2000);
            IWebElement button = driver.FindElement(By.CssSelector(".glyph-pause"));
            button.Click();
            try
            { 
            IWebElement firstSliImg = driver.FindElement(By.XPath("//h2[contains(text(), 'Surface Pro')]"));
            Assert.IsTrue(firstSliImg.Displayed, "Image not displayed");
            firstSliImg.Click();
            Thread.Sleep(2000);
            string url = driver.Url;
            driver.Navigate().Back();
            Thread.Sleep(7000);
            button.Click();
            IWebElement secondSliImg = driver.FindElement(By.XPath("//h2[contains(text(),'Surface Laptop')]"));
            Assert.IsTrue(secondSliImg.Displayed, "Image not displayed");
            secondSliImg.Click();
            string url2 = driver.Url;
            Assert.IsTrue(true, (url = url2));
            }
            catch (Exception e)
            {
                Console.WriteLine("Message:" + e);
            }
            finally
            { 
                driver.Close();
            }
        }

        [Test]
        // Test for search bar
        public void SearchBarTest()
        {
            Init();
            IWebElement support = driver.FindElement(By.Id("l1_support"));
            IWebElement searchIcon = driver.FindElement(By.Id("search"));
            searchIcon.Click();
            Thread.Sleep(2000);
            Assert.IsFalse(support.Displayed);
            IWebElement searchBar = driver.FindElement(By.Id("cli_shellHeaderSearchInput"));
            Assert.IsTrue(searchBar.Enabled);
            IWebElement cancelBtn = driver.FindElement(By.Id("cancel-search"));
            Assert.IsTrue(cancelBtn.Enabled);
            cancelBtn.Click();
            Assert.IsTrue(support.Displayed);
            driver.Close();
        }

        [Test]
        //Test for search
        public void SearchTest()
        {
            Init();
            IWebElement searchIcon = driver.FindElement(By.Id("search"));
            searchIcon.Click();
            IWebElement searchBar = driver.FindElement(By.Id("cli_shellHeaderSearchInput"));
            searchBar.SendKeys("surface");
            Thread.Sleep(5000);
            try
            {
                List<string> searchList = new List<string>();
                ReadOnlyCollection<IWebElement> searchResults = driver.FindElements(By.CssSelector(".f-product"));
                foreach (IWebElement ser in searchResults)
                {
                    StringAssert.Contains("Surface",ser.Text, "Results Matched");
                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
            } finally
            {
                driver.Close();
            }
            
        }

        [Test]
        //Test for page sections
        public void PageSectionsTest()
        {
            Init();
            string expectedURL = "https://www.microsoft.com/en-in/p/xbox-game-pass/";
            IWebElement sliderSection = driver.FindElement(By.Id("primaryR1"));
            Assert.IsTrue(sliderSection.Displayed);
            IWebElement storeLinks = driver.FindElement(By.Id("primaryR2"));
            Assert.IsTrue(storeLinks.Displayed);
            IWebElement xBoxSection = driver.FindElement(By.Id("primaryR3"));
            Assert.IsTrue(xBoxSection.Displayed);
            IWebElement workSection = driver.FindElement(By.Id("primaryR4"));
            Assert.IsTrue(workSection.Displayed);
            IWebElement shopNowLink = xBoxSection.FindElement(By.LinkText("SHOP NOW"));
            shopNowLink.Click();
            IWebElement heading = driver.FindElement(By.Id("DynamicHeading_productTitle"));
            Assert.IsTrue(heading.Displayed);
            string actualURL = driver.Url;
            Assert.IsTrue(actualURL.Contains(expectedURL));
            driver.Close();
        }

    }

}
