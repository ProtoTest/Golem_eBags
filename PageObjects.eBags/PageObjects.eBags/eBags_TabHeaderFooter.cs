using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Golem.Framework;
using OpenQA.Selenium;
using MbUnit.Framework;

namespace PageObjects.eBags
{
    public class eBags_TabHeaderFooter : BasePageObject
    {
        /* The new header footer page is live
         * Since HeaderFooter will be on most pages, future page object should Enherit from this pageObject
         * */
        #region Mobile Size Header
        //Mobile Header
        Element PromoBar_Micro = new Element("PromoBar_Micro", By.Id("cpMicroPromoBar"));
        Element eBags_Logo = new Element("eBags_Logo", By.ClassName("logoCon"));
        Element Account_Mobile = new Element("Mobile_Header", By.ClassName("mobileAccountCon"));
        Element Menu_Mobile = new Element("Menu_Mobile", By.ClassName("mobileMenuCon"));
        Element Cart_Mobile = new Element("Cart_Mobile", By.ClassName("mobileCartCon"));
        Element Search_Mobile = new Element("Search_Moble", By.Id("txtSearchResponsiveHeader"));
        Element ShopAllDepartments_Mobile = new Element("ShopALLDepartments_Mobile", By.XPath("//*[@id='MainNavItems']/li[11]")); //might be in all header items

        //mobile account buttons
        Element CreateAccount_Mobile = new Element("Create Account", By.XPath("//*[@class='slider for-mobileAccountCon slideMenu clearfix']/ul/li[1]/a"));
        Element YourAccount_Mobile = new Element("Your Account", By.XPath("//*[@class='slider for-mobileAccountCon slideMenu clearfix']/ul/li[2]/a"));
        Element ManageWishList_Mobile = new Element("Manage Wishlist", By.XPath("//*[@class='slider for-mobileAccountCon slideMenu clearfix']/ul/li[3]/a"));
        Element ManageAddressBook_Mobile = new Element("Manage Address Book", By.XPath("//*[@class='slider for-mobileAccountCon slideMenu clearfix']/ul[2]/li[1]/a"));
        Element ManagePaymentMethods_Mobile = new Element("Manage Payment Methods", By.XPath("//*[@class='slider for-mobileAccountCon slideMenu clearfix']/ul[2]/li[2]/a"));
        Element TrackOrders_Mobile = new Element("Track Orders", By.XPath("//*[@class='slider for-mobileAccountCon slideMenu clearfix']/ul[2]/li[3]/a"));

        //mobile Menu buttons
        Element ContactUs_Mobile = new Element("Contact Us", By.XPath("//*[@class='slider for-mobileMenuCon slideMenu clearfix']/ul/li[1]/a"));
        Element Returns_Mobile = new Element("Returns", By.XPath("//*[@class='slider for-mobileMenuCon slideMenu clearfix']/ul[2]/li[1]/a"));
        Element JoineBags_Mobile = new Element("Join eBags Rewards Club", By.XPath("//*[@class='slider for-mobileMenuCon slideMenu clearfix']/ul/li[2]/a"));
        Element StealOfTheDay_Mobile = new Element("Steal of the Day", By.XPath("//*[@class='slider for-mobileMenuCon slideMenu clearfix']/ul/li[3]/a"));

        //Shop Departments Buttons
        Element SeasonalButton = new Element("Seasonal_Button", By.XPath("//*[@class='mainNav']/div/div[9]/div/div/h2/a"));
        Element Luggage_button = new Element("Luggage", By.XPath("//*[@class='mainNav']/div/div[9]/div/div/h2[2]/a"));
        Element Handbags_button = new Element("Handbags", By.XPath("//*[@class='mainNav']/div/div[9]/div/div[1]/h2[3]/a"));
        Element eBags_button = new Element("eBags Brand",  By.XPath("//*[@class='mainNav']/div/div[9]/div/div[2]/h2/a"));
        Element Accessories_button = new Element("Accessories", By.XPath("//*[@class='mainNav']/div/div[9]/div/div[2]/h2[2]/a"));
        Element Business_Button = new Element("Business", By.XPath("//*[@class='mainNav']/div/div[9]/div/div[3]/h2[1]/a"));
        Element Backpacks_button = new Element("Backpacks", By.XPath("//*[@class='mainNav']/div/div[9]/div/div[3]/h2[2]/a"));
        Element Sports_button = new Element("Sports", By.XPath("//*[@class='mainNav']/div/div[9]/div/div[4]/h2[1]/a"));
        Element Sale_Button = new Element("Sale", By.XPath("//*[@class='mainNav']/div/div[9]/div/div[4]/h2[2]/a"));
        Element Brands_Button = new Element("Brands", By.XPath("//*[@class='mainNav']/div/div[9]/div/div[4]/h2[3]/a"));
        #endregion

        
        


        List<Element> MobileHeaderElements;
        List<Element> MobileAccountButtons;  
        List<Element> MobileMenuButtons;
        List<Element> ShopDepartmentsButtons;

        List<IWebElement> tempContainer;

        public eBags_TabHeaderFooter()
        {
            MobileHeaderElements = new List<Element>();
            MobileHeaderElements.Add(PromoBar_Micro);
            MobileHeaderElements.Add(eBags_Logo);
            MobileHeaderElements.Add(Account_Mobile);
            MobileHeaderElements.Add(Menu_Mobile);
            MobileHeaderElements.Add(Cart_Mobile);
            MobileHeaderElements.Add(Search_Mobile);
            MobileHeaderElements.Add(ShopAllDepartments_Mobile);

            MobileAccountButtons = new List<Element>();
            MobileAccountButtons.Add(CreateAccount_Mobile);
            MobileAccountButtons.Add(YourAccount_Mobile);
            MobileAccountButtons.Add(ManageWishList_Mobile);
            MobileAccountButtons.Add(ManageAddressBook_Mobile);
            MobileAccountButtons.Add(ManagePaymentMethods_Mobile);
            MobileAccountButtons.Add(TrackOrders_Mobile);

            MobileMenuButtons = new List<Element>();
            MobileMenuButtons.Add(ContactUs_Mobile);
            MobileMenuButtons.Add(Returns_Mobile);
            MobileMenuButtons.Add(JoineBags_Mobile);
            MobileMenuButtons.Add(StealOfTheDay_Mobile);

            ShopDepartmentsButtons = new List<Element>();
            ShopDepartmentsButtons.Add(SeasonalButton);
            ShopDepartmentsButtons.Add(Luggage_button);
            ShopDepartmentsButtons.Add(Handbags_button);
            ShopDepartmentsButtons.Add(eBags_button);
            ShopDepartmentsButtons.Add(Accessories_button);
            ShopDepartmentsButtons.Add(Business_Button);
            ShopDepartmentsButtons.Add(Backpacks_button);
            ShopDepartmentsButtons.Add(Sports_button);
            ShopDepartmentsButtons.Add(Sale_Button);
            ShopDepartmentsButtons.Add(Brands_Button);

            
        }

        public eBags_TabHeaderFooter checkHeader()
        {
            if(eBags_TestConfiguration.isMobile())
            {
                doMobileHeader();
            }
            if(eBags_TestConfiguration.isTablet())
            {
                //dotabletheader
            }
            if(eBags_TestConfiguration.isWide())
            {
                //dowideheader
            }
            if(eBags_TestConfiguration.isSuperWide())
            {
                //dosuperwide
            }
            return new eBags_TabHeaderFooter();
        }

        private void doMobileHeader()
        {
            
            for(int i = 0; i < MobileHeaderElements.Count; i++)
            {
                MobileHeaderElements[i].WaitUntilVisible();
            }
            //Assert.AreEqual(eBags_TestConfiguration.getNavURL(), eBags_Logo.GetAttribute("href"));

            Account_Mobile.WaitUntilVisible().Click();
            for(int i = 0; i < MobileAccountButtons.Count; i++)
            {
                MobileAccountButtons[i].WaitUntilVisible();
                Assert.AreEqual(MobileAccountButtons[i].name, MobileAccountButtons[i].Text);
            }

            Menu_Mobile.WaitUntilVisible().Click();
            for(int i = 0; i < MobileMenuButtons.Count; i++)
            {
                MobileMenuButtons[i].WaitUntilVisible();
                Assert.AreEqual(MobileMenuButtons[i].name, MobileMenuButtons[i].Text);
            }
            ShopAllDepartments_Mobile.WaitUntilVisible().Click();
            ShopDepartmentsButtons[0].WaitUntilVisible(); //Since this button's text changes we don't want to include in the loop
            for(int i = 1; i < ShopDepartmentsButtons.Count; i++)
            {
                ShopDepartmentsButtons[i].WaitUntilVisible();
                Assert.AreEqual(ShopDepartmentsButtons[i].name, ShopDepartmentsButtons[i].Text);
            }
        }



        public override void WaitForElements()
        {
            
        }
    }
}
