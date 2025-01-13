using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Testcase3
    {
        private FirefoxDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheCase3Test()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.XPath("//div[2]/div/div/a/img")).Click();
            driver.FindElement(By.Id("giftcard_2_RecipientName")).Click();
            driver.FindElement(By.Id("giftcard_2_RecipientName")).Clear();
            driver.FindElement(By.Id("giftcard_2_RecipientName")).SendKeys("Test");
            driver.FindElement(By.Id("giftcard_2_RecipientEmail")).Click();
            driver.FindElement(By.Id("giftcard_2_RecipientEmail")).Clear();
            driver.FindElement(By.Id("giftcard_2_RecipientEmail")).SendKeys("filipleskovic159@gmail.com");
            driver.FindElement(By.Id("giftcard_2_Message")).Click();
            driver.FindElement(By.Id("giftcard_2_Message")).Clear();
            driver.FindElement(By.Id("giftcard_2_Message")).SendKeys("Message");
            driver.FindElement(By.Id("add-to-cart-button-2")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
