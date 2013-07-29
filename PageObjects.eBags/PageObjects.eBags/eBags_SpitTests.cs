using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Golem.Framework;
using OpenQA.Selenium;

namespace PageObjects.eBags
{
    public class eBags_SpitTests : BasePageObject
    {
        private string SelectedPartitionClassName = "'partitionDetailSelected'";

        Element EB_email_acquisition_split_test = new Element("EmailAcquisitionSplit", By.XPath("//*[@id='bodyWrapper']/table/tbody"));
        Element EB_email_BSplit = new Element("EB_Email_Bsplit", By.LinkText("EB-Email-Acquisition-B-split-lightbox"));
        Element EB_email_ASplit = new Element("EB_Email_Asplit", By.LinkText("EB-Email-Acquisition-A-split-control"));

        Element EB_HeaderFooter_dept_redesign_split_test = new Element("HeaderFooterSplit", By.XPath("//*[@id='bodyWrapper']/table[2]/tbody"));
        Element EB_HeaderFooter_BSplit = new Element("EB_HeaderFooter_BSplit", By.LinkText("EB-header-footer-dept-redesign-B-split"));
        Element EB_HeaderFooter_ASplit = new Element("EB_HeaderFooter_ASplit", By.LinkText("EB-header-footer-dept-redesign-A-split"));

        Element EB_Featured_sort_split_test = new Element("FeaturedSortSplit", By.XPath("//*[@id='bodyWrapper']/table[5]/tbody"));
        Element EB_FeaturedSort_ASplit = new Element("EB_FeaturedSort_ASplit", By.LinkText("EB-featured-sort-enabled"));
        Element EB_FeaturedSort_BSplit = new Element("EB_FeaturedSort_BSplit", By.LinkText("EB-featured-sort-control"));
        Element EB_FeaturedSort_CSplit = new Element("EB_FeaturedSort_CSplit", By.LinkText("EB-featured-sort-list-page-redesign"));

        Element InternalTools_Button = new Element("InternalTools_Button", By.XPath("//header/nav/ul/li[2]/a"));
        Element EnabledFeatures = new Element("EnabledFeatures", By.XPath("//*[@id='bodyWrapper']/div/ul/li[11]/a"));

        public static eBags_SpitTests OpenSplit(string url)
        {
            TestBaseClass.driver.Navigate().GoToUrl(url);
            return new eBags_SpitTests();
        }

        public eBags_SpitTests SetupSplit(char EmailSplit, char HFSplit, char FSSplit)
        {
            List<IWebElement> FoundElements;
            IWebElement ElementToDetermine;
            char EmailAcquisitionSplit;
            char HeaderFooterSplit;
            char FeaturedSortSplit;

            //The cookies on will be deleted at the start of each automated test
            //The email acquisition and the featured sort should have no splits available
            //The header-footer should have a selected by default 
            if (EmailSplit == 'A')
            {
                EB_email_ASplit.WaitUntilPresent().Click();
            }
            else
            {
                //BSplit
                EB_email_BSplit.WaitUntilPresent().Click();
            }
            if (HFSplit == 'B')
            {
                EB_HeaderFooter_BSplit.WaitUntilPresent().Click();
            }
            if (FSSplit == 'A')
            {
                EB_FeaturedSort_ASplit.WaitUntilPresent().Click();
            }
            if (FSSplit == 'B')
            {
                EB_FeaturedSort_BSplit.WaitUntilPresent().Click();
            }
            if (FSSplit == 'C')
            {
                EB_FeaturedSort_CSplit.WaitUntilPresent().Click();
            }


            return new eBags_SpitTests();
        }

        public eBags_EnabledFeatures ClickEnabledFeatures()
        {
            InternalTools_Button.WaitUntilPresent().Click();
            EnabledFeatures.WaitUntilPresent().Click();
            return new eBags_EnabledFeatures();
        }
        


        public override void WaitForElements()
        {

        }
    }
}
