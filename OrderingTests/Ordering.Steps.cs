using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightBDD.XUnit2;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace OrderingTests
{
    public partial class Ordering : FeatureFixture, IDisposable
    {
        private IWebDriver _driver;

        public Ordering()
        {
            _driver = new ChromeDriver();
        }

        private void Given_the_user_is_about_to_login()
        {

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        private void Given_the_user_entered_valid_login(string userName)
        {
            _driver.FindElement(By.Id("user-name"))
                .SendKeys(userName);
        }

        private void Given_the_user_entered_valid_password(string password)
        {
            _driver.FindElement(By.Id("password"))
                .SendKeys(password);
        }

        private void When_the_user_clicks_login_button()
        {
            _driver.FindElement(By.Id("login-button"))
                .Click();
        }

        private void Then_the_login_is_successful()
        {
            var _inventoryPage = _driver.Url;
            Assert.Equal("https://www.saucedemo.com/inventory.html", _inventoryPage);
        }
        private void Given_the_user_adds_an_item_to_the_cart(string item)
        {
            _driver.FindElement(By.Id(item))
                .Click();
        }

        private void When_user_views_the_cart()
        {
            _driver.FindElement(By.Id("shopping_cart_container"))
                .Click();
        }
        private void Then_the_item_should_be_added_to_the_cart(string itemName)
        {
            var _itemName = itemName;
            var parentElement = _driver.FindElement(By.ClassName("inventory_item_name"));
            parentElement.FindElement(By.XPath("//div[text()='" + _itemName + "']"));
        }

        private void Given_the_user_proceeds_to_checkout()
        {
            _driver.FindElement(By.Id("checkout"))
               .Click();
        }

        private void When_the_user_inserts_personal_data(string firstName, string lastName, string postalCode)
        {
            var _firstName = firstName;
            var _lastName = lastName;
            var _postalCode = postalCode;
            _driver.FindElement(By.Id("first-name"))
                .SendKeys(_firstName);
            _driver.FindElement(By.Id("last-name"))
                .SendKeys(_lastName);
            _driver.FindElement(By.Id("postal-code"))
                .SendKeys(_postalCode);
        }

        private void When_the_user_clicks_continue()
        {
            _driver.FindElement(By.Id("continue"))
                .Click();
        }

        private void Then_the_overview_should_contain_correct_item_total(string expectedItemTotal)
        {
            var _expectedItemTotal = expectedItemTotal;
            var _actualItemTotal = _driver.FindElement(By.ClassName("summary_subtotal_label"))
                .Text;
            Assert.Contains(_expectedItemTotal, _actualItemTotal);

        }
        private void Then_the_overview_should_contain_correct_total_amount(string expected_total)
        {
            var _expectedTotal = expected_total;
            var _actualTotal = _driver.FindElement(By.ClassName("summary_total_label"))
                .Text;
            Assert.Contains(_expectedTotal, _actualTotal);
        }
        private void Then_the_overview_should_contain_correct_tax(string expectedTax)
        {
            var _expectedTax = expectedTax;
            var _actualTax = _driver.FindElement(By.ClassName("summary_tax_label"))
                .Text;
            Assert.Contains(_expectedTax, _actualTax);
        }

        private void When_the_user_clicks_finish()
        {
            _driver.FindElement(By.Id("finish"))
                .Click();
        }
        private void Then_the_order_should_be_dispatched()
        {
            var parentElement = _driver.FindElement(By.Id("checkout_complete_container")).Text;
            Assert.Contains("order has been dispatched", parentElement);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
