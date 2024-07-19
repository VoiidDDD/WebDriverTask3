using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
namespace WebDriverTask3
{
    public class Tests
    {
        private ChromeDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator");

            driver.FindElement(By.CssSelector("button.xhASFc")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("div.DzHYNd")).FindElements(By.CssSelector("div.VobRQb"))[0].Click();
            var add = driver.FindElements(By.CssSelector("button.wX4xVc-Bz112c-LgbsSe "))[1];
            for (int i = 0; i < 3; i++)
            {
                add.Click();
            }
            driver.FindElements(By.CssSelector("div.VfPpkd-O1htCb-OWXEXe-ztc6md"))[3].Click();
            
            driver.FindElements(By.CssSelector("ul.VfPpkd-rymPhb"))[6].FindElements(By.TagName("li"))[6].Click();

            driver.FindElements(By.CssSelector("button.eBlXUe-scr2fc-OWXEXe-uqeOfd"))[5].Click();
            
            var buttons = driver.FindElements(By.CssSelector("div.YgByBe"));
            while (buttons.Count < 11)
            {
                buttons = driver.FindElements(By.CssSelector("div.YgByBe"));
            }

            IWebElement result11 = buttons[0], result12 = buttons[0], result21 = buttons[0], result22 = buttons[0];
            bool found = false;
            bool found1 = false;
            foreach (var button in buttons)
            {
                if (found && found1)
                {
                    break;
                }
                foreach (var span in button.FindElements(By.TagName("span")))
                {
                    if (span.Text.Equals("GPU Model"))
                    {
                        result11 = button;
                        found = true;
                        break;
                    }
                    if (span.Text.Equals("Local SSD"))
                    {
                        result12 = button;
                        found1 = true;
                        break;
                    }
                }
            }
            result11.Click();
            var lists = driver.FindElements(By.CssSelector("ul.VfPpkd-OJnkse"));
            while (lists.Count < 11)
            {
                lists = driver.FindElements(By.CssSelector("ul.VfPpkd-OJnkse"));
            }
            found = false;
            found1 = false;
            bool wrong = true;
            foreach (var list in lists)
            {
                if (found && found1)
                {
                    break;
                }
                foreach (var span in list.FindElements(By.TagName("li")))
                {
                    if (span.GetAttribute("data-value").Equals("0"))
                    {
                        wrong = false;
                    }
                    if (span.GetAttribute("data-value").Equals("nvidia-tesla-v100"))
                    {
                        result21 = span;
                        found = true;
                        break;
                    }
                    if (span.GetAttribute("data-value").Equals("2") && !wrong)
                    {
                        result22 = span;
                        found1 = true;
                        break;
                    }
                }
            }
            
            result21.Click();

            result12.Click();
            result22.Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
            }
        }
    }
}