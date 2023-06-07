using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    public class Locators
    {
        // Xpath, Css, id, classname, name, tagname.

        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {

            
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
            // Implicit 5 seconds wait can be declare globally here
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                driver.Manage().Window.Maximize();
                driver.Url = "https://app.hubspot.com/login";
                //driver.Url = "https://account.bbc.com/signin";
        }

        [Test]
        public void LocatorIdentification()

        {
            driver.FindElement(By.Id("username")).SendKeys("nelytino@yahoo.com");
            //driver.FindElement(By.Id("username")).Clear();
            //driver.FindElement(By.Id("username)")).SendKeys("estina@yahoo.com");
             //driver.FindElement(By.CssSelector("#password")).SendKeys("Cap2222!");
            driver.FindElement(By.CssSelector("#password")).SendKeys("Kamsi12@");
            // //CSS selector & Xpath
            // //tagname[attribute = 'value'] = CSS 
            // driver.FindElement(By.CssSelector("button[id='loginBtn']")).Click();
            // //driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            // //  //tagName[@attribute = 'value']
            // // CSS - .text-info span:nth-child(1) input
            // // Xpath - //label[@class='text-info']/span/input
           // driver.FindElement(By.XPath("//*[@id=\"submit-button\"]/span")).Click(); // Writing using selectorHub
                                                                                                                                    // //validate url of the link text
           //driver.FindElement(By.XPath("//button[@id='loginBtn']")).Click();

            //Thread.Sleep(3000);

            //8seconds [Explicit Wait]
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            //.TextToBePresentInElementValue(driver.FindElement(By.Id("//button[@id='loginBtn']")),"log In"));
           
           // String erromessage = driver.FindElement(By.ClassName("private-alert__body has--vertical-spacing")).Text;
          // TestContext.Progress.WriteLine(erromessage);

           // IWebElement link = driver.FindElement(By.LinkText("Return to where you originally came from"));
           //string hrefAttr = link.GetAttribute("href");
           // string expectedUrl = "https://static.files.bbci.co.uk/account/";
           // Assert.AreEqual(expectedUrl, hrefAttr);
            
        }

        public void Test1()
        {
            driver.Quit();
            driver.Dispose();   
        }


        
    }
}

    

