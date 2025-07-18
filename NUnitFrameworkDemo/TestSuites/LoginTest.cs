using NUnitFrameworkDemo.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFrameworkDemo.TestSuites
{
    public class LoginTest : Wrapper
    {
        private LoginTest objTestClass = null;

        [Test]
        public void ValidLoginCheck()
        {
            objTestClass = new LoginTest();
            objTestClass.LoginDetails("Admin", "admin123", chromeDriver);

            //Dashboard Header
            IWebElement hdDash = chromeDriver.FindElement(By.TagName("h6"));
            string actTxt = hdDash.Text;
            string expTxt = "Dashboard";

            Assert.That(actTxt, Is.EqualTo(expTxt));
        }

        [Test]
        public void InvalidLoginCheck()
        {
            objTestClass = new LoginTest();
            objTestClass.LoginDetails("John", "john123", chromeDriver);

            //Invalid Credentials Paratag
            IWebElement pInvalidCred = chromeDriver.FindElement(By.XPath("//p[contains(normalize-space(),'Invalid')]"));
            string actTxt = pInvalidCred.Text;
            string expTxt = "Invalid credentials";

            Assert.That(actTxt.Contains(expTxt), "Assert failed for invalid credentials");
        }

        public void LoginDetails(string uName, string pWord, IWebDriver chromeDriver)
        {
            //Username Textbox
            IWebElement txtUsername = chromeDriver.FindElement(By.Name("username"));
            txtUsername.SendKeys(uName);

            //Password Textbox
            IWebElement txtPassword = chromeDriver.FindElement(By.Name("password"));
            txtPassword.SendKeys(pWord);

            //Login Button
            IWebElement btnLogin = chromeDriver.FindElement(By.XPath("//button[@type='submit']"));
            btnLogin.Click();
        }
    }
}
