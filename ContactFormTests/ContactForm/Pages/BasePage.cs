using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ContactForm.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; }
    }
}
