using OpenQA.Selenium;

namespace NUnitFrameworkDemo.Pages
{
    public class MainPage
    {
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            this._driver = driver;
        }
    }
}
