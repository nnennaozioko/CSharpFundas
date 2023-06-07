using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirst
    {
        IWebDriver driver;

      [SetUp]
        public void StartBrowser()
        {

            //Methods -geturl, click-
            //Chromedriver.exe on chrome browser
            //edgedriver.exe
            //99.exe (99) // version of your chrome
            //geckodriver
            //WebDriverManager-( help us to get all the drivers we need from our local machine
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
           // new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
             driver = new ChromeDriver();
            // driver = new FirefoxDriver();
            //driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [Test]
        public void Test1()
        {
           
            driver.Url = "https://account.bbc.com/signin"; // set property
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url); // get property
            //driver.PageSource;
            driver.Close(); // close window that open by browser(1 window)
            //driver.Quit(); //2 windows, it will close all windows that open by the automation
            
        }



    }
}
