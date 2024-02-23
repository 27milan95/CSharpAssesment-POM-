using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel
{
    internal class PageClass : BaseClass
    {

        public Boolean NewCustomerLink()
        {
            return Driver.FindElement(By.LinkText("Continue")).Displayed;
        }

        public void Login(String Email, String Password)
        {
            Driver.FindElement(By.Name("email_address")).SendKeys(Email);
            Driver.FindElement(By.Name("password")).SendKeys(Password);
            Driver.FindElement(By.Id("tdb1")).Click();
        }

        public String Title()
        {
            return Driver.Title;
        }

        public ReadOnlyCollection<IWebElement> TopMenuList()
        {
            ReadOnlyCollection<IWebElement> list = Driver.FindElements(By.XPath(TestUtilities.XpathTopMenuList));


            return list;
        }

        public void ManufacturingTab(String DropdownSelector)
        {
            IWebElement Tab = Driver.FindElement(By.Name("manufacturers_id"));
            SelectElement dropbdown = new SelectElement(Tab);

            dropbdown.SelectByText(DropdownSelector);



        }

        public void AddToCart()
        {
            Driver.FindElement(By.LinkText("tata->")).Click();
            Driver.FindElement(By.LinkText("Smartwatches")).Click();
            Driver.FindElement(By.LinkText("Buy Now")).Click();

        }
    }
}