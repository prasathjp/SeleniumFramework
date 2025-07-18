using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFrameworkDemo.Base
{
    public class Wrapper
    {
        protected IWebDriver chromeDriver;

        [SetUp]
        public void LaunchBrowser()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromeDriver.Url = "https://opensource-demo.orangehrmlive.com/";
        }

        [TearDown]
        public void ExitBrowser()
        {
            chromeDriver.Quit();
            chromeDriver.Dispose();
        }
    }
}
