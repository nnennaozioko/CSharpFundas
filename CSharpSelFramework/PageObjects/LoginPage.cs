using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V111.Page;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.PageObjects
{
    public class LoginPage
    {
        //  driver.FindElement(By.Id("username"))
        // By.Id("username"))
        // driver.FindElement(By.Name("password")).SendKeys("learning");
       // driver.FindElements(By.CssSelector("input[type='radio']");
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Pageobject factory


        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;

        [FindsBy(How = How.CssSelector, Using = "#signInBtn")]
        private IWebElement signInButton; 

        public ProductsPage validLogin(string user,string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkbox.Click();
            signInButton.Click();
            return new ProductsPage(driver);
        }



        public IWebElement getUserName()
        {
            return username;
        }




    }
}
