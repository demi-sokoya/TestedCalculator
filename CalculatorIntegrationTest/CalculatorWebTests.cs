using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace CalculatorIntegrationTest
{
    [TestClass]
    public class CalculatorWebTests
    {
        IWebDriver _driver;

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestThatWebSiteAdds()
        {
            _driver.Navigate().GoToUrl("https://localhost:5000/");

            var left = _driver.FindElement(By.CssSelector("input[name=left]"));
            var right = _driver.FindElement(By.CssSelector("input[name=right]"));
            var form = _driver.FindElement(By.CssSelector("form]"));

            left.SendKeys("1");
            right.SendKeys("1");
            form.Submit();

            var output = _driver.FindElement(By.CssSelector("output"));
            Assert.AreEqual(2, output.Text);
        }

        [TestCleanup]
        public void Shutdown()
        {
            _driver.Quit();
        }
    }
}
