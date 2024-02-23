using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel
{
    internal class TestClass : BaseClass
    {

        PageClass page;

        
        
        

        //Initialize the browser & PageClass object--------------------------------------------------------------------------------------
        [SetUp]
        public void InitializeBrowser()
        {
            Setup();
            page = new PageClass();
           
            // Console.WriteLine("driver initialize");
        }



        //Below Test will verify the login functionality of the application ensuring USERNAME is being generated or not----------------
       [Test, Order(1)]
        public void VerifyLoginFunctionality()
        {
            page.Login(TestUtilities.Email, TestUtilities.password);
            String Actual = Driver.FindElement(By.ClassName("greetUser")).Text;
            //Console.WriteLine(Actual);  
            Assert.That(Actual.Equals("Vraj!"));
        }




        //Below Test will verify new customer link on login page ia available for new customer or not-------------------------------------------
        [Test, Order(2)]
        public void VerifyNewCustomerLink()
        {
            Assert.IsTrue(page.NewCustomerLink(),"false");
        }




        //Will verify the title of the Webpage-------------------------------------------------------------------------------------
        [Test, Order(3)]
        public void VerifyPageTitle()
        {
            Assert.That(page.Title().Equals("Gadgets Gallery"), "Statement fail");
        }




        //Top menu list verification before login and after login as Webelement size changes from 5 to 6.------------------------
        //Also I verified webelement is present on not.-----------------------------------------------------------------------
        [Test, Order(4)]
        public void VerifyTopMenu()
        {
           // Console.WriteLine(page.TopMenuList().Count);
            Assert.That(page.TopMenuList().Count().Equals(5));

            page.Login(TestUtilities.Email, TestUtilities.password);
            Assert.That(page.TopMenuList().Count().Equals(6));
            
            foreach(IWebElement element in page.TopMenuList())
            {
                //Console.WriteLine(element.Text);
                if (element.Text.Equals("Specials"))
              {
                   Assert.That(element.Text, Is.EqualTo("Specials"));
                   break;
                }

            }
            
        }


        //Below Test verifies that while changing webelement from dropdown in manufacturing tab, webpage titles get changed---------------------
       [Test, Order(5)]
        public void VerifyLaptopPage()
        {
            String expected = "Laptop, Gadgets Gallery";
            page.ManufacturingTab(TestUtilities.DropdownSelector);
            String Actual = Driver.Title;
            Assert.That(expected.Equals(Actual), "Title does't match");
        }


        //Verify Add to the cart functionality-----------------------------------------------------------------------------------
      [Test, Order(6)]
        public void VerifyAddToCart()
        {
            page.Login(TestUtilities.Email, TestUtilities.password);
            page.AddToCart();
            String Actual = Driver.FindElement(By.PartialLinkText("Shopping Cart")).Text;
            Assert.That(Actual.Equals("Shopping Cart (1)"));

            Thread.Sleep(1000);

            Driver.FindElement(By.LinkText("remove")).Click();
        }



        //Close the browser------------------------------------------------------------------------------------------------------
        [TearDown]
        public void CloseBrowser()
        {
            TearDown();
        }

    }
}
