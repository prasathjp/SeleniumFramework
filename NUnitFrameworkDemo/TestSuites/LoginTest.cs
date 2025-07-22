using DocumentFormat.OpenXml.Bibliography;
using NUnitFrameworkDemo.Base;
using NUnitFrameworkDemo.Pages;
using NUnitFrameworkDemo.Utilities;
using OpenQA.Selenium;

namespace NUnitFrameworkDemo.TestSuites
{
    public class LoginTest : Wrapper
    {
        [Test]
        public void ValidLoginCheck()
        {
            LoginDetails("Admin", "admin123", chromeDriver);

            //Dashboard Header
            IWebElement hdDash = chromeDriver.FindElement(By.TagName("h6"));
            string actTxt = hdDash.Text;
            string expTxt = "Dashboard";

            Assert.That(actTxt, Is.EqualTo(expTxt));
        }

        [Test]
        public void InvalidLoginCheck()
        {
            LoginDetails("John", "john123", chromeDriver);

            //Invalid Credentials Paratag
            IWebElement pInvalidCred = chromeDriver.FindElement(By.XPath("//p[contains(normalize-space(),'Invalid')]"));
            string actTxt = pInvalidCred.Text;
            string expTxt = "Invalid credentials";

            Assert.That(actTxt, Does.Contain(expTxt), "Assert failed for invalid credentials");
        }

        [TestCase("abcd", "abcd123")]
        [TestCase("wxyz", "wxyz123")]
        public void InvalidLoginChecks(string uName, string pWord)
        {
            LoginDetails(uName, pWord, chromeDriver);

            //Invalid Credentials Paratag
            IWebElement pInvalidCred = chromeDriver.FindElement(By.XPath("//p[contains(normalize-space(),'Invalid')]"));
            string actTxt = pInvalidCred.Text;
            string expTxt = "Invalid credentials";

            Assert.That(actTxt, Does.Contain(expTxt), "Assert failed for invalid credentials");
        }

        [TestCaseSource(typeof(DataSource), nameof(Utilities.DataSource.LoginDataSource))]
        public void InvalidLoginCheckSource(string uName, string pWord)
        {
            LoginDetails(uName, pWord, chromeDriver);

            //Invalid Credentials Paratag
            IWebElement pInvalidCred = chromeDriver.FindElement(By.XPath("//p[contains(normalize-space(),'Invalid')]"));
            string actTxt = pInvalidCred.Text;
            string expTxt = "Invalid credentials";

            Assert.That(actTxt, Does.Contain(expTxt), "Assert failed for invalid credentials");
        }

        [TestCaseSource(typeof(DataSource), nameof(Utilities.DataSource.LoginDataSourceFromExcel))]
        public void InvalidLoginCheckSourceFromExcel(string uName, string pWord, string expTxt)
        {
            LoginDetails(uName, pWord, chromeDriver);

            //Invalid Credentials Paratag
            IWebElement pInvalidCred = chromeDriver.FindElement(By.XPath("//p[contains(normalize-space(),'Invalid')]"));
            string actTxt = pInvalidCred.Text;

            Assert.That(actTxt, Does.Contain(expTxt), "Assert failed for invalid credentials");
        }

        internal static void LoginDetails(string uName, string pWord, IWebDriver chromeDriver)
        {
            LoginPage loginPage = new LoginPage(chromeDriver);
            loginPage.EnterUsername("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLogin();
        }
    }
}