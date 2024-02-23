using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectModel
{
    public class BaseClass
    {
       protected static IWebDriver? Driver = null;

        

        public void Setup()
        {

            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(TestUtilities.WebPageURL);
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        
        public void TearDown()
        {
            
            Driver.Quit();
        }
    }
}