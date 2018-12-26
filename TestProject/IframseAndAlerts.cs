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
using System;
using System.Diagnostics;

namespace TestProject
{
    class IframseAndAlerts
    {
        IWebDriver driver;

        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        //Test for handling Iframes in page
        [Test]
        public void IframesTest()
        {
            Init();
            driver.Navigate().GoToUrl("http://toolsqa.com/iframe-practice-page/");
            Thread.Sleep(5000);
            try
            {
                IWebElement FrameOne = driver.FindElement(By.Name("iframe1"));
                IWebElement FrameTwo = driver.FindElement(By.Name("iframe1"));
                driver.SwitchTo().Frame(FrameOne);
                IWebElement DivText = driver.FindElement(By.CssSelector(".vc_message_box.vc_message_box-standard"));
                string TextInsideDiv = DivText.Text;
                Console.WriteLine(TextInsideDiv);
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(FrameTwo);
                IWebElement HeadingTitle = driver.FindElement(By.ClassName("entry-title"));
                string HeadingText = HeadingTitle.Text;
                Console.WriteLine(HeadingText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                driver.Quit();
            }
        }

        //Test for 
        [Test]

        public void HandlingAlertsTest()
        {
            Init();
            driver.Navigate().GoToUrl("http://toolsqa.com/handling-alerts-using-selenium-webdriver/");
            Thread.Sleep(5000);
            try
            {
                IWebElement SimpleAlertBtn = driver.FindElement(By.XPath("//button[.= 'Simple Alert']"));
                SimpleAlertBtn.Click();
                Thread.Sleep(2000);
                IAlert SimpleAlert = driver.SwitchTo().Alert();
                Console.WriteLine(SimpleAlert.Text);
                SimpleAlert.Accept();
                driver.SwitchTo().DefaultContent();

                IWebElement ConfirmAlertBtn = driver.FindElement(By.XPath("//button[.= 'Confirm Pop up']"));
                ConfirmAlertBtn.Click();
                Thread.Sleep(2000);
                IAlert ConfirmAlert = driver.SwitchTo().Alert();
                Console.WriteLine(ConfirmAlert.Text);
                ConfirmAlert.Dismiss();
                driver.SwitchTo().DefaultContent();

                IWebElement PromptPopupBtn = driver.FindElement(By.XPath("//button[.= 'Prompt Pop up']"));
                PromptPopupBtn.Click();
                Thread.Sleep(2000);
                IAlert PromptAlert = driver.SwitchTo().Alert();
                Console.WriteLine(PromptAlert.Text);
                PromptAlert.SendKeys("Yes");
                PromptAlert.Accept();


            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                driver.Quit();
            }
           

        }

    }
}
