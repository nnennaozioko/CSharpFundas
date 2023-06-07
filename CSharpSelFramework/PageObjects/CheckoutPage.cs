using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.PageObjects
{
    public class CheckoutPage
    {
        IWebDriver driver;
        //driver.FindElements(By.CssSelector("h4 a"));
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //(By.CssSelector(".btn-success") By.CssSelector(".card-title a")

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButton;


        public IList<IWebElement> getCards()
        {
            return checkoutCards;
        }

        public void checkOut()
        {
            checkoutButton.Click();
            //object of next page
        }
    }
}
