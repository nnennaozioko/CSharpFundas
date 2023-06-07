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
using OpenQA.Selenium.DevTools.V111.Network;

namespace SeleniumLearning
{
    public class FunctionalTest
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {


            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            //driver.Url = "https://courses.prepmajor.com/user-account-2/";// for dropdown
            // driver.Url = "https://offers.hubspot.com/crm-platform-demo"; 
            driver.Url = "https://www.facebook.com/reg/?app_id=0&logger_id";// for Radio button
            //driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            //driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            //driver.Url = "";

        }

        [Test]

        public void dropDown() // These are for static drop down
        {
            // Thread.Sleep(5000);
            //driver.FindElement(By.CssSelector("//*[@id=\"firstname-dd3abfde-a04d-4a60-8e01-589751844027_2579\"]")).SendKeys("Nnenna");
            //driver.FindElement(By.Id("lastname-dd3abfde-a04d-4a60-8e01-589751844027_6036")).SendKeys("Ozioko");
            //driver.FindElement(By.Id("input#email-dd3abfde-a04d-4a60-8e01-589751844027_7939")).SendKeys("nelytino@yahoo.com");
            //driver.FindElement(By.XPath("//*[@id=\"label-phone-dd3abfde-a04d-4a60-8e01-589751844027_7939\"]/span[1]")).SendKeys("07495712394");
            //driver.FindElement(By.Id("company-dd3abfde-a04d-4a60-8e01-589751844027_7939")).SendKeys("Sogeti");
            //driver.FindElement(By.XPath("//*[@id=\"website-dd3abfde-a04d-4a60-8e01-589751844027_7939\"]")).SendKeys("https://www.sogeti.com/");


            driver.FindElement(By.CssSelector("[title='Allow all cookies']")).Click();
            //Thread.Sleep(10000);
            // IWebElement dropDown = driver.FindElement(By.CssSelector("#members-order-by"));
            //SelectElement s = new SelectElement(dropDown); //s or selectElement
            //s.SelectByText("Newest Registered");
            //s.SelectByValue("alphabetical");
            //s.SelectByIndex(1);

            //IWebElement dropDown = driver.FindElement(By.CssSelector("#day"));
            //SelectElement s = new SelectElement(dropDown);
            ////s.SelectByValue("6");
            //s.SelectByIndex(5);




            //driver.FindElement(By.XPath("//*[@id=\"hsForm_dd3abfde-a04d-4a60-8e01-589751844027_7063\"]/div/div[2]/input")).Click();

            //Radio Button
            //Thread.Sleep(5000);
            //driver.FindElement(By.CssSelector("input#u_0_4_CV")).Click(); // for single radio button
            IList<IWebElement> rdos = driver.FindElements(By.CssSelector("[type='radio']")); // for multiple radio button
            //rdos[0].Click();
            foreach (IWebElement radioButton in rdos)
            {
                if (rdos[0].GetAttribute("value").Equals("female")) // NOTE
                //if (radioButton.GetAttribute("value").Equals("Custom"))
                {
                    radioButton.Click();
                }

                //foreach (IWebElement radioButton in rdos)
                //{
                //    if (radioButton.GetAttribute("value").Equals("radio1"))
                //        driver.FindElements(By.CssSelector("#gdpr-optin"));

                //    {

                //        radioButton.Click();
                //    }

                //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
                //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));

                //    driver.FindElement(By.Id("okayBtn")).Click();
                //    Boolean result = driver.FindElement(By.Id("usertype")).Selected;

                //    Assert.That(result, Is.True);


                //}


                //driver.FindElement(By.CssSelector("#radio-btn-example > fieldset > label:nth-child(1)")).Click();






                }


            }
    }
}
