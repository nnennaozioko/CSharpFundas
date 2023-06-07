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
using CSharpSelFramework.utilities;

namespace SeleniumLearning
{
    public class WindowHandlers2 : Base
    {

       
        [Test]
          
        // To switch from one window to another


        public void WindowHandler()
        {
            string email = "mentor@rahulshettyacademy.com";
            string parentWindowId = driver.Value.CurrentWindowHandle; // this is applied when you want place the email address to the parent window
            driver.Value.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, driver.Value.WindowHandles.Count); //1
            //driver.SwitchTo().Window(driver.WindowHandles[0]);
            string childWindowName = driver.Value.WindowHandles[1];
            driver.Value.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector(".red")).Text);

            // To extract email address from the text
            string text = driver.Value.FindElement(By.CssSelector(".red")).Text;
            //Please email us at mentor @rahulshettyacademy.com with below template to receive response
            string[] splittedText = text.Split("at");

            //mentor @rahulshettyacademy.com with below template to receive response

            string[] trimmedString = splittedText[1].Trim().Split(" ");

            Assert.AreEqual(email, trimmedString[0]);

            driver.Value.SwitchTo().Window(parentWindowId); // switch to the parent window

            driver.Value.FindElement(By.Id("username")).SendKeys(trimmedString[0]);



        }
    }
}
