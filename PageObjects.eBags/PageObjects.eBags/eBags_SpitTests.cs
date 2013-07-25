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

        public static eBags_SpitTests OpenSplit(string url)
        {
            TestBaseClass.driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
            return new eBags_SpitTests();
        }

        public eBags_SpitTests SetupSplit(char EmailSplit, char HFSplit, char FSSplit)
        {
            List<IWebElement> FoundElements;
            IWebElement ElementToDetermine;
            char EmailAcquisitionSplit;
            char HeaderFooterSplit;
            char FeaturedSortSplit;

            //Determine the active split for the email acquisition first
            FoundElements = EB_email_acquisition_split_test.FindElements(By.XPath("//[@class=" + SelectedPartitionClassName + "]")).ToList<IWebElement>();
            if (FoundElements.Count > 0)
            {
                EmailAcquisitionSplit = DetermineSplit(FoundElements[0]);
            }
            else
            {
                EmailAcquisitionSplit = 'X';
            }
            //Determine the active split for the HeaderFooter
            FoundElements.Clear();
            FoundElements = EB_HeaderFooter_dept_redesign_split_test.FindElements(By.XPath("//[@class=" + SelectedPartitionClassName + "]")).ToList<IWebElement>();
            if (FoundElements.Count > 0)
            {
                HeaderFooterSplit = DetermineSplit(FoundElements[0]);
            }
            else
            {
                HeaderFooterSplit = 'X';
            }
            //Determine the active split for the FeaturedSort There are three active splits for this
            FoundElements.Clear();
            FoundElements = EB_Featured_sort_split_test.FindElements(By.XPath("//*[@class=" + SelectedPartitionClassName + "]")).ToList<IWebElement>();
            if (FoundElements.Count > 0)
            {
                FeaturedSortSplit = DetermineSplit(FoundElements[0]);
            }
            else
            {
                FeaturedSortSplit = 'X';
            }
            
            //Select the appropriate email split
            if (EmailSplit == 'A')
            {
                if((EmailAcquisitionSplit == 'B') || (EmailAcquisitionSplit == 'X'))
                {
                    EB_email_ASplit.WaitUntilPresent().Click();
                }
            }
            if (EmailSplit == 'B')
            {
                if((EmailAcquisitionSplit == 'A') || (EmailAcquisitionSplit == 'X'))
                {
                    EB_email_BSplit.WaitUntilPresent().Click();
                }
            }
            //select the appropriate header/footer split
            if (HFSplit == 'A')
            {
                if((HeaderFooterSplit == 'B') || (EmailAcquisitionSplit == 'X'))
                {
                    EB_HeaderFooter_ASplit.WaitUntilPresent().Click();
                }
            }
            if (HFSplit == 'B')
            {
                if((HeaderFooterSplit == 'A') || (HeaderFooterSplit == 'X'))
                {
                    EB_HeaderFooter_BSplit.WaitUntilPresent().Click();
                }
            }
            //Select the appropriate Featured Sort Split
            if (FSSplit == 'A')
            {
                if ((FeaturedSortSplit == 'B') || (FeaturedSortSplit == 'C') || (FeaturedSortSplit == 'X'))
                {
                    EB_FeaturedSort_ASplit.WaitUntilPresent().Click();
                }
            }
            if (FSSplit == 'B')
            {
                if ((FeaturedSortSplit == 'A') || (FeaturedSortSplit == 'C') || (FeaturedSortSplit == 'X'))
                {
                    EB_FeaturedSort_BSplit.WaitUntilPresent().Click();
                }
            }
            if (FSSplit == 'C')
            {
                if ((FeaturedSortSplit == 'A') || (FeaturedSortSplit == 'B') || (FeaturedSortSplit == 'X'))
                {
                    EB_FeaturedSort_CSplit.WaitUntilPresent().Click();
                }
            }

            return new eBags_SpitTests();
        }

        private char DetermineSplit(IWebElement ElementToDetermine)
        {
            char[] AvailableSplits = { 'A', 'B', 'C', 'X' };
            string[] ElementParts;
            int ReturnChar = 3;

            ElementParts = ElementToDetermine.Text.Split('-');
            if (ElementParts.Contains("A"))
            {
                ReturnChar = 0;
            }
            if (ElementParts.Contains("B"))
            {
                ReturnChar = 1;
            }
            if (!ElementParts.Contains("A") && !ElementParts.Contains("B"))
            {
                if (ElementParts.Contains("enabled"))
                {
                    ReturnChar = 0;
                }
                if (ElementParts.Contains("control"))
                {
                    ReturnChar = 1;
                }
                if (ElementParts.Contains("redesign"))
                {
                    ReturnChar = 2;
                }
            }

            return AvailableSplits[ReturnChar];
        }


        public override void WaitForElements()
        {

        }
    }
}
