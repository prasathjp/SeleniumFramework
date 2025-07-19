using NUnitFrameworkDemo.Base;
using OpenQA.Selenium;

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

        [TestCase("abcd", "abcd123")]
        [TestCase("wxyz", "wxyz123")]
        public void InvalidLoginChecks(string uName, string pWord)
        {
            objTestClass = new LoginTest();
            objTestClass.LoginDetails(uName, pWord, chromeDriver);

            //Invalid Credentials Paratag
            IWebElement pInvalidCred = chromeDriver.FindElement(By.XPath("//p[contains(normalize-space(),'Invalid')]"));
            string actTxt = pInvalidCred.Text;
            string expTxt = "Invalid credentials";

            Assert.That(actTxt.Contains(expTxt), "Assert failed for invalid credentials");
        }

        [TestCaseSource(typeof(LoginTest), nameof(loginDataSource))]
        public void InvalidLoginCheckSource(string uName, string pWord)
        {
            objTestClass = new LoginTest();
            objTestClass.LoginDetails(uName, pWord, chromeDriver);

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

        public static object[] loginDataSource()
        {
            string[] strArrLogin1 = new string[] { "aaaa", "aaaa123" };
            string[] strArrLogin2 = new string[] { "bbbb", "bbbb123" };

            object[] objCred = new object[2];
            objCred[0] = strArrLogin1;
            objCred[1] = strArrLogin2;
            return objCred;
        }
    }
}
