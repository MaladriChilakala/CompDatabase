using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CompDatabase
{
    [TestClass]
    public class ComputerDatabase   
    {
        static IWebDriver driverff;
               
        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driverff = new FirefoxDriver(service);
           
        }
        [TestMethod]
        public void AddComputer()
        {
            driverff.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
            IWebElement header = driverff.FindElement(By.XPath("/html/body/section/h1"));
            Assert.IsTrue(header.Displayed);
            driverff.FindElement(By.Id("add")).Click();
            IWebElement acheader = driverff.FindElement(By.XPath("/html/body/section/h1"));
            Assert.IsTrue(acheader.Displayed);
            driverff.FindElement(By.Id("name")).SendKeys("Testing Name");
            driverff.FindElement(By.Id("introduced")).SendKeys("2012-02-20");
            driverff.FindElement(By.Id("discontinued")).SendKeys("2013-02-20");
            driverff.FindElement(By.Id("company")).SendKeys("Apple");
            driverff.FindElement(By.XPath("/html/body/section/form/div/input")).Click();
        }

        [TestMethod]
        public void SearchComputer()
        {
            driverff.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
            driverff.FindElement(By.Id("searchbox")).SendKeys("Testing Name");
            driverff.FindElement(By.Id("searchsubmit")).Click();
            IWebElement searchResult = driverff.FindElement(By.XPath("/html/body/section/table/tbody/tr/td[1]/a"));
            Assert.IsTrue(searchResult.Displayed);
        }

        [TestMethod]
        public void EditComputer()
        {
            SearchComputer();
            driverff.FindElement(By.XPath("/html/body/section/table/tbody/tr/td[1]/a")).Click();
            driverff.FindElement(By.Id("name")).Clear();
            driverff.FindElement(By.Id("name")).SendKeys("updated Name");
            driverff.FindElement(By.Id("introduced")).Clear();
            driverff.FindElement(By.Id("introduced")).SendKeys("2012-03-20");
            driverff.FindElement(By.Id("discontinued")).Clear();
            driverff.FindElement(By.Id("discontinued")).SendKeys("2013-02-20");
            driverff.FindElement(By.Id("company")).Clear();
            driverff.FindElement(By.Id("company")).SendKeys("Apple");
            driverff.FindElement(By.XPath("/html/body/section/form[1]/div/input")).Click();
        }

        [TestMethod]
        public void DeleteComputer()
        {
            SearchComputer();
            driverff.FindElement(By.XPath("/html/body/section/table/tbody/tr/td[1]/a")).Click();
            driverff.FindElement(By.XPath("/html/body/section/form[2]/input")).Click();

        }
    }
}
