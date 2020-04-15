// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;

namespace N11Demo_Test
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver driver = new FirefoxDriver();
        [SetUp]
        public void Login()
        {
           
            driver.Url = "http://n11.com/giris-yap";

            driver.Manage().Window.Maximize();
            

            driver.FindElement(By.Id("email")).SendKeys("username@n11.com");
            driver.FindElement(By.Id("password")).SendKeys("EnterYourPassword" + Keys.Enter);

            

        }
        [Test]
        public void searchBar()
        {
            Thread.Sleep(15000);
           
            driver.FindElement(By.XPath("//*[@id='searchData']")).Click();
            driver.FindElement(By.XPath("//*[@id='searchData']")).SendKeys("samsung" + Keys.Enter);
            try
            {
               
                var text = (driver.FindElement(By.XPath("//*[@id='searchData']"))).Text;
               // if (string.IsNullOrEmpty(text))
               if("samsung"!=text)
                {
                    System.Console.WriteLine("Login page test has granted");
                }


            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine("search box test is failed");
            }

            Thread.Sleep(15000);

            driver.FindElement(By.XPath("//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]")).Click();
            string url = driver.Url;
            if ("https://www.n11.com/arama?q=samsung&pg=2"==url)
            {
                System.Console.WriteLine("Second page test is granted");
            }
            else
            {
                System.Console.WriteLine("Second page test has failed");
            }


            Thread.Sleep(10000);

            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div[2]/section[1]/div[2]/ul/li[3]/div/div[1]/span")).Click();
            var element2 = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div[2]/section[1]/div[2]/ul/li[3]/div/div[1]/a/h3")).Text;
            
            Thread.Sleep(7000);
            
            //driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div[2]/section[1]/div[2]/ul/li[3]/div/div[1]/a/h3")).Click();
            //Thread.Sleep(7000);
            //driver.FindElement(By.XPath("/html/body/div[1]/header/div/div/div[2]/div[2]/div[2]/div[2]/div/a[2]")).Click();
            driver.Navigate().GoToUrl("https://www.n11.com/hesabim/favorilerim");
            
            Thread.Sleep(5000);
           
            var element1 = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[3]/div[1]/div[2]/ul/li[1]/div/div[1]/a/h3")).Text;
            
            
            try
            {
                Assert.AreEqual(element1, element2);
                System.Console.WriteLine("The product are the same");
            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine(ex);
            }
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[3]/div[1]/div[2]/ul/li[1]/div/div[3]/span")).Click();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("https://www.n11.com/hesabim/favorilerim");
            Thread.Sleep(2000);

            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(driver.FindElements(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[3]/div[1]/div[2]/ul/li[1]/div/div[1]/a/h3")));
            
            if (elementList.Count > 0)
            {
                Console.WriteLine("Failed to remove item from favourites");
                //If the count is greater than 0 your element exists.
                elementList[0].Click();
            }
            else
            {
                Console.WriteLine("The item succesfully removed from favourites");
            }


        }

    }
}
