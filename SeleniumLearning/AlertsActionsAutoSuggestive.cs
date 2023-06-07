using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace SeleniumLearning
{
    public class AlertsActionsAutoSuggestive
    {
        WebDriver driver;

        [SetUp]
        public void StartBrowser()
        {


            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";


        }


        [Test] 
        
        //Frame or iFrame -> Three parameters you can pass frame ie index, name or id
                
        public void frames()
        {
            //Scroll
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js =(IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);

            // id, name, index
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
            driver.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
        }




        [Test]  // pop Alert
        public void test_Alert()
        {
            string name = "Nelly";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();
            String alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept(); 
            //driver.SwitchTo().Alert().Dismiss();
            //driver.SwitchTo().Alert().SendKeys("hello"); // if there is edit box

            StringAssert.Contains(name, alertText);

        }

        [Test] //dynamic dropdown

        public void test_AutoSuggestiveDropDowns()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");

            Thread.Sleep(3000);
            IList <IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
             foreach(IWebElement option in options)
             {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }
             }


           TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));

        }




        [Test] // Hover Action
        public void test_Actions()
        {

            //driver.Url = "https://rahulshettyacademy.com";
            Actions a = new Actions(driver);
            //a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            //driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a")).Click();  
            //a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();


            //driver.Url = "https://delightful-sand-072182f03.2.azurestaticapps.net/";
            //Actions a = new Actions(driver);
            //a.MoveToElement(driver.FindElement(By.XPath("//li[@class='nav-item has-dropdown features']"))).Perform();
            //a.MoveToElement(driver.FindElement(By.XPath("//div[@class='media-body'][1]/h6[1]"))).ClickAndHold().Perform();

                   // drag and drop action
              driver.Url = "https://demoqa.com/droppable";
              a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();




        }





    }
}

