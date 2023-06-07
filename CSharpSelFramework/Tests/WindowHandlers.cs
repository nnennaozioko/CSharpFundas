using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Numerics;
using System.Reflection.Metadata;

namespace SeleniumLearning
{
    [Parallelizable(ParallelScope.Self)]
    public class WindowHandlers
    {

        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {


            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";


        }

        [Test]
                // To switch from one window to another
        public void WindowHandler()
        {
            string email = "mentor@rahulshettyacademy.com";
            string parentWindowId = driver.CurrentWindowHandle; // this is applied when you want place the email address to the parent window
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count); //1
            //driver.SwitchTo().Window(driver.WindowHandles[0]);
            string childWindowName = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);

            // To extract email address from the text
            string text = driver.FindElement(By.CssSelector(".red")).Text;
            //Please email us at mentor @rahulshettyacademy.com with below template to receive response
            string[] splittedText = text.Split("at");

            //mentor @rahulshettyacademy.com with below template to receive response

            string[] trimmedString = splittedText[1].Trim().Split(" ");

            Assert.AreEqual(email, trimmedString[0]);

            driver.SwitchTo().Window(parentWindowId); // switch to the parent window

            driver.FindElement(By.Id("username")).SendKeys(trimmedString[0]);



        }
    }
}
