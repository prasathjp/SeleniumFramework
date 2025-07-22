using DocumentFormat.OpenXml.ExtendedProperties;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFrameworkDemo.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void EnterUsername(string uName)
        {
            //Username Textbox
            IWebElement txtUsername = _driver.FindElement(By.Name("username"));
            txtUsername.SendKeys(uName);
        }

        public void EnterPassword(string pWord)
        {
            //Password Textbox
            IWebElement txtPassword = _driver.FindElement(By.Name("password"));
            txtPassword.SendKeys(pWord);
        }

        public void ClickLogin()
        {
            ////Login Button
            IWebElement btnLogin = _driver.FindElement(By.XPath("//button[@type='submit']"));
            btnLogin.Click();
        }
    }
}
