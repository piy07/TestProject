using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Threading;
using System;

namespace TestProject
{
    class GoogleSignIn
    {
        [TestClass]
        public class FirstTestClass
        {
            public IWebDriver driver;
            public string url = "https://accounts.google.com/";
            public void Init()
            {
                if (driver == null)
                    driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.google.com/");
            }

            //Google Sign In Test
            [TestMethod]
            public void GoogleSignInTest()
            {
                try
                {
                    Init();
                    string expectedEmail = "doe777530@gmail.com";
                    Thread.Sleep(5000);
                    IWebElement signInButton = driver.FindElement(By.Id("gb_70"));
                    Assert.IsTrue(signInButton.Displayed);
                    Assert.IsTrue(signInButton.Enabled);
                    signInButton.Click();
                    string actualURL = driver.Url;
                    Assert.IsTrue(actualURL.Contains(url));
                    IWebElement email = driver.FindElement(By.Id("identifierId"));
                    Assert.IsTrue(email.Displayed);
                    Assert.IsTrue(email.Enabled);
                    IWebElement placeHolder = driver.FindElement(By.CssSelector(".snByac"));
                    Assert.IsTrue(placeHolder.Displayed);
                    email.SendKeys(expectedEmail);
                    IWebElement next = driver.FindElement(By.CssSelector(".CeoRYc"));
                    next.Click();
                    IWebElement password = driver.FindElement(By.Id("password"));
                    Assert.IsTrue(password.Displayed);
                    Assert.IsTrue(password.Enabled);
                    password.SendKeys("test@1234");
                    next.Click();
                    IWebElement logo = driver.FindElement(By.Id("hplogo"));
                    Assert.IsTrue(logo.Displayed);
                    Assert.IsFalse(signInButton.Displayed, "User Signed In");
                    IWebElement userIcon = driver.FindElement(By.XPath("//a[contains(@title, 'Google Account')]"));
                    userIcon.Click();
                    IWebElement userEmail = driver.FindElement(By.XPath("(//div[contains(text(), 'doe777530')])[1]"));
                    StringAssert.Equals(userEmail.Text, expectedEmail);

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
        }
    }
}
