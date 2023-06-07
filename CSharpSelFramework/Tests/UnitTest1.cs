using CSharpSelFramework.PageObjects;
using CSharpSelFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpSelFramework.Tests
{
    [Parallelizable(ParallelScope.Children)]
    public class E2ETest2 : Base
    {


        [Test, TestCaseSource("AddTestDataConfig"), Category("Regression")]

        //[TestCase("rahulshettyacademy", "learning")]
        //[TestCase("rahulshetty", "learning")]

        // run all data sets of Test method in parallel
        // run all test methods in one class parallel
        // run all test files in project parallel

        //donet test pathto.csproj (All tests)
        //donet test pathto.csproj --filter TestCategory=Smoke or Regression
        //donet test pathto.csproj --filter TestCategory=Smoke -- TestRun

        [Parallelizable(ParallelScope.All)]
        public void EndToEndFlow2(String username, String password, String[] expectedProducts)

        {

            //username1 -100
            //Login page ->
            //Documents request ->


            //String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productPage = loginPage.validLogin(username, password);
            productPage.waitForPageDisplay();


            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    product.FindElement(productPage.addToCartButton()).Click();
                }

            }

            CheckoutPage checkoutPage = productPage.Checkout();
            IList<IWebElement> checkoutCards = checkoutPage.getCards();
            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }

            Assert.AreEqual(expectedProducts, actualProducts);
            checkoutPage.checkOut();

            //driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.Value.FindElement(By.Id("country")).SendKeys("ind");

            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.Value.FindElement(By.LinkText("India")).Click();
            driver.Value.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.Value.FindElement(By.CssSelector("[value='Purchase']")).Click();
            string confirText = driver.Value.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", confirText);
        }

            [Test, Category("Smoke")]
            public void LocatorIdentification()

            {
                driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
                //driver.Value.FindElement(By.Id("username")).Clear();
                //driver.Value.FindElement(By.Id("username)")).SendKeys("rahulshettyacademy");
                //driver.Value.FindElement(By.CssSelector("#password")).SendKeys("learning");
                driver.Value.FindElement(By.CssSelector("#password")).SendKeys("learning");
                
                driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click(); // Writing using selectorHub
                driver.Value.FindElement(By.XPath("//input[@value='Sign In']")).Click();                                                                         // //validate url of the link text
                                                                                                                                                           //driver.FindElement(By.XPath("//button[@id='loginBtn']")).Click();

                //WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                //.TextToBePresentInElementValue(driver.Value.FindElement(By.CssSelector("[type='submit']")), "SignIn"));

                String erromessage = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
                TestContext.Progress.WriteLine(erromessage);

            }
            // IEnumerable in interface that is available in c# which is use to collect all the data

            public static IEnumerable<TestCaseData> AddTestDataConfig()
            {
                yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
                yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
                // yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"), getDataParser().extractDataArray("products"));
            }

        
}   }
        