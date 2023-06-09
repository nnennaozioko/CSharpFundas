﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using AngleSharp.Dom;
using System.Reflection.Emit;

namespace SeleniumLearning
{
    public class SortWebTables
    {

        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {


            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";


        }

        [Test]

        public void SortTable()
        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");


            // step 1 - Get all veggi names into arraylist A
           IList <IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach(WebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }
            //step 2- sort this arrylist
            //a.Sort();
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            TestContext.Progress.WriteLine("After sorting");

            a.Sort();
            foreach(String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }
            //step 3 - go and click the colume
            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();



            // step 4- Get all veggi names into arraylist B
            ArrayList b = new ArrayList();
            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in sortedVeggies)
            {
                b.Add(veggie.Text);
            }
            // arraylist A to B = equal

            Assert.AreEqual(a, b);


        }

    }
}        
