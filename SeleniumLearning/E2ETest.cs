using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using AngleSharp.Text;

namespace SeleniumLearning
{
    public class E2ETest
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {


            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
           // driver.Url = "https://www.currys.co.uk/phones";
           //driver.Url = "https://www.asda.com/register";
            //driver.Url = "https://www.asda.com/login";
            driver.Url = "https://groceries.asda.com/search/phones";


        }

        [Test]


        
        public void EndToEndFlow()
        {
            //Thread.Sleep(5000);
            //driver.FindElement(By.Id("register-email")).SendKeys("nelytino@yahoo.com");
            //driver.FindElement(By..email-phone-input (".show-password")).SendKeys("Cap2222!");
            //driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            //driver.FindElement(By.CssSelector(".checkmark")).Click();
            //driver.FindElement(By.CssSelector("#app > main > div > div > div > div > form > button")).Click();


            //driver.FindElement(By.CssSelector("[id=onetrust-accept-btn-handler]")).Click(); // to accept cookies
            //driver.FindElement(By.CssSelector(".email-phone-input ")).SendKeys("nelytino@yahoo.com");
            //driver.FindElement(By.CssSelector("[type='password']")).SendKeys("Cap2222!");
            //driver.FindElement(By.CssSelector("[type='submit']")).Click();

            //driver.FindElement(By.CssSelector("[id=onetrust-accept-btn-handler]")).Click();
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("SignIn")));
            //driver.FindElement(By.XPath("//a[contains(@class,'asda-btn asda-btn--secondary asda-btn--fluid')]")).Click();
            //driver.FindElement(By.CssSelector(".username-box > div > div > input")).SendKeys("nelytino@yahoo.com");
            //driver.FindElement(By.CssSelector(".show-password")).SendKeys("Cap2222!");
            //driver.FindElement(By.CssSelector("[type='submit']")).Click();
            //driver.FindElement(By.CssSelector("input[name='postcode-tandc-modal__postcode']")).SendKeys("SS14 2EJ");
            //driver.FindElement(By.CssSelector("#postcode-tandc-modal__terms-check")).Click();
            //driver.FindElement(By.CssSelector("section > div > form > button")).Click();

            string[] Coproducts = { "TCL 305 Mobile Phone", "BT 2200 Twin Phone" };
            driver.FindElement(By.CssSelector("[id=onetrust-accept-btn-handler]")).Click();
           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("")));

            IList<IWebElement> products = driver.FindElements(By.TagName("source type"));
            foreach(IWebElement product in products)
            {
                if(Coproducts.Contains(product.FindElement(By.CssSelector("image/webp")).Text))
                {
                    product.FindElement(By.CssSelector(".add-button-with-tooltip")).Click();
                }

               
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector("image/webp")).Text);
            }


            
            



        }



    }
}
