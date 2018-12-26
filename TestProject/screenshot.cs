using System;
using System.IO;
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

    class Screenshot
    {
        IWebDriver driver;

        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.youtube.com/");
        }

        [Test]

        public void ScreenShot()
        {
            Init();
            try
            {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(DateTime.Now.ToShortDateString()+".png", ScreenshotImageFormat.Png);
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
