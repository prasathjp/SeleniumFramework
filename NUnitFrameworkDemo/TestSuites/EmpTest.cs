using NUnitFrameworkDemo.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NUnitFrameworkDemo.TestSuites
{
    public class EmpTest : Wrapper
    {
        [Test]
        public void AddEmpCheck()
        {
            LoginTest.LoginDetails("Admin", "admin123", chromeDriver);

            //Dashboard Header
            IWebElement hdDash = chromeDriver.FindElement(By.TagName("h6"));
            string actTxt = hdDash.Text;
            string expTxt = "Dashboard";

            Assert.That(actTxt, Is.EqualTo(expTxt));

            string strEmpFirstName = "John";
            string strEmpLastName = "Wick";

            //PIM Menu Span
            IWebElement spanPIM = chromeDriver.FindElement(By.XPath("//span[text()='PIM']"));
            spanPIM.Click();

            //Add Emp Link
            IWebElement lnkAddEmp = chromeDriver.FindElement(By.LinkText("Add Employee"));
            lnkAddEmp.Click();

            //FirstName Textbox
            IWebElement txtFname = chromeDriver.FindElement(By.XPath("//input[@name='firstName']"));
            txtFname.SendKeys(strEmpFirstName);

            //MidName Textbox
            IWebElement txtMname = chromeDriver.FindElement(By.XPath("//input[@name='middleName']"));
            txtMname.SendKeys("D");

            //LastName Textbox
            IWebElement txtLname = chromeDriver.FindElement(By.XPath("//input[@name='lastName']"));
            txtLname.SendKeys(strEmpLastName);

            //Save Button
            IWebElement btnSave = chromeDriver.FindElement(By.XPath("//button[@type='submit']"));
            btnSave.Click();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(chromeDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            //FirstName Textbox
            IWebElement txtFirstName = fluentWait.Until(dom => dom.FindElement(By.XPath("//input[@name='firstName']")));
            string strFname = txtFirstName.GetAttribute("value");
            Assert.That(strFname, Does.Contain(strEmpFirstName), "Assert failed for Firstname textbox");

            //Emp Name Header
            bool isHeaderLoad = fluentWait.Until(dom => dom.FindElement(By.XPath("//div[@class='orangehrm-edit-employee-name']//h6")).GetAttribute("innerText") != string.Empty);
            IWebElement headEmpName = fluentWait.Until(dom => dom.FindElement(By.XPath("//div[@class='orangehrm-edit-employee-name']//h6")));
            string actFullName = headEmpName.GetAttribute("innerText");
            string expFullName = strEmpFirstName + " " + strEmpLastName;
            Assert.That(actFullName, Is.EqualTo(expFullName), "Assert failed for Emp Firstname and Lastname");
        }
    }
}