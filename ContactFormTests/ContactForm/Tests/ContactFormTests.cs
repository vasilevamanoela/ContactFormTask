using ContactForm.Pages.ContactForm;
using ContactForm.Tests;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ContactForm
{
    [TestFixture]
    public class ContactFormTests : BaseTest
    {
        private ContactFormPage _contactFormPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("https://www.ipswitch.com/test-form-page");
            _contactFormPage = new ContactFormPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void FillInContactFormWithValidData()
        {
            //Arrange
            _contactFormPage.FirstName.SendKeys("Ivan");
            _contactFormPage.LastName.SendKeys("Ivanov");
            _contactFormPage.Email.SendKeys("some.email@gmail.com");
            _contactFormPage.PhoneNumber.SendKeys("123456");
            _contactFormPage.Company.SendKeys("Some Company");
            _contactFormPage.ProductInterest.SendKeys(Keys.Down + Keys.Enter);
            _contactFormPage.JobTitle.SendKeys("Some job title");
            _contactFormPage.Country.SelectByText("Armenia");
            _contactFormPage.Message.SendKeys("Some message");

            //Act
            _contactFormPage.ContactUsButton.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, 0)");

            //Assert
            Assert.IsTrue(_contactFormPage.ThankYouMessage.Displayed);
        }

        [Test]
        public void FillInContactFormWithoutFirstName()
        {
            //Arrange
            _contactFormPage.FirstName.SendKeys(String.Empty);
            _contactFormPage.LastName.SendKeys("Ivanov");
            _contactFormPage.Email.SendKeys("some.email@gmail.com");
            _contactFormPage.PhoneNumber.SendKeys("123456");
            _contactFormPage.Company.SendKeys("Some Company");
            _contactFormPage.ProductInterest.SendKeys(Keys.Down + Keys.Enter);
            _contactFormPage.JobTitle.SendKeys("Some job title");
            _contactFormPage.Country.SelectByText("Armenia");
            _contactFormPage.Message.SendKeys("Some message");

            //Act
            _contactFormPage.ContactUsButton.Click();

            //Assert
            Assert.AreEqual(_contactFormPage.FirstNameErrorMessage.Text, "First Name is Required");
        }

        [Test]
        public void FillInContactFormWithInvalidEmailAddress()
        {
            //Arrange
            _contactFormPage.FirstName.SendKeys("Ivan");
            _contactFormPage.LastName.SendKeys("Ivanov");
            _contactFormPage.Email.SendKeys("some.email");
            _contactFormPage.PhoneNumber.SendKeys("123456");
            _contactFormPage.Company.SendKeys("Some Company");
            _contactFormPage.ProductInterest.SendKeys(Keys.Down + Keys.Enter);
            _contactFormPage.JobTitle.SendKeys("Some job title");
            _contactFormPage.Country.SelectByText("Armenia");
            _contactFormPage.Message.SendKeys("Some message");

            //Act
            _contactFormPage.ContactUsButton.Click();

            //Assert
            Assert.AreEqual(_contactFormPage.EmailAddressErrorMessage.Text, "Enter a Valid Business Email Address example@yourdomain.com");
        }

        [Test]
        public void FillInContactFormWithInvalidPhoneNumber()
        {
            //Arrange
            _contactFormPage.FirstName.SendKeys("Ivan");
            _contactFormPage.LastName.SendKeys("Ivanov");
            _contactFormPage.Email.SendKeys("some.email@gmail.com");
            _contactFormPage.PhoneNumber.SendKeys("phone number");
            _contactFormPage.Company.SendKeys("Some Company");
            _contactFormPage.ProductInterest.SendKeys(Keys.Down + Keys.Enter);
            _contactFormPage.JobTitle.SendKeys("Some job title");
            _contactFormPage.Country.SelectByText("Armenia");
            _contactFormPage.Message.SendKeys("Some message");

            //Act
            _contactFormPage.ContactUsButton.Click();

            //Assert
            Assert.AreEqual(_contactFormPage.PhoneNumberErrorMessage.Text, "Phone Number field input is invalid");
        }

        [Test]
        public void FillInContactFormWithoutMessage()
        {
            //Arrange
            _contactFormPage.FirstName.SendKeys("Ivan");
            _contactFormPage.LastName.SendKeys("Ivanov");
            _contactFormPage.Email.SendKeys("some.email@gmail.com");
            _contactFormPage.PhoneNumber.SendKeys("123456");
            _contactFormPage.Company.SendKeys("Some Company");
            _contactFormPage.ProductInterest.SendKeys(Keys.Down + Keys.Enter);
            _contactFormPage.JobTitle.SendKeys("Some job title");
            _contactFormPage.Country.SelectByText("Armenia");
            _contactFormPage.Message.SendKeys(String.Empty);

            //Act
            _contactFormPage.ContactUsButton.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, 0)");

            //Assert
            Assert.IsTrue(_contactFormPage.ThankYouMessage.Displayed);
        }
    }
}