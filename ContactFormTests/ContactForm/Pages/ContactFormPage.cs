using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ContactForm.Pages.ContactForm
{
    public class ContactFormPage : BasePage
    {
        public ContactFormPage(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement FirstName => Driver.FindElement(By.Id("Textbox-1"));

        public IWebElement LastName => Driver.FindElement(By.Id("Textbox-4"));

        public IWebElement Email => Driver.FindElement(By.Id("Email-1"));

        public IWebElement PhoneNumber => Driver.FindElement(By.Id("Textbox-5"));

        public IWebElement Company => Driver.FindElement(By.Id("Textbox-2"));

        public IWebElement ProductInterest => Driver.FindElement(By.Id("Dropdown-1"));

        public IWebElement JobTitle => Driver.FindElement(By.Id("Textbox-3"));

        public SelectElement Country => new SelectElement(Driver.FindElement(By.Id("Country-1")));

        public IWebElement Message => Driver.FindElement(By.Id("Textarea-1"));

        public IWebElement ContactUsButton => Driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement ThankYouMessage => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@data-sf-role='success-message']")));

        public IWebElement FirstNameErrorMessage => Wait.Until(d => d.FindElement(By.CssSelector("#C022_Col00 > div:nth-child(1) > p")));

        public IWebElement EmailAddressErrorMessage => Wait.Until(d => d.FindElement(By.CssSelector("#C022_Col00 > div:nth-child(2) > p")));

        public IWebElement PhoneNumberErrorMessage => Wait.Until(d => d.FindElement(By.CssSelector("#C022_Col01 > div:nth-child(2) > p")));

    }
}
