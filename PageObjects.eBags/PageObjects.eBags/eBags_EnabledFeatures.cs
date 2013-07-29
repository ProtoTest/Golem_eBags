using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Golem.Framework;
using OpenQA.Selenium;

namespace PageObjects.eBags
{
    public class eBags_EnabledFeatures : BasePageObject
    {
        Element FaceBook = new Element("Facebook", By.Id("EnabledFeatures_0__IsEnabledFeatureActive"));
        Element Facebook_Logging = new Element("Facebook.Logging", By.Id("EnabledFeatures_1__IsEnabledFeatureActive"));
        Element Facebook_Sharing = new Element("Facebook.Sharing", By.Id("EnabledFeatures_2__IsEnabledFeatureActive"));
        Element Pinterest = new Element("Pinterest", By.Id("EnabledFeatures_3__IsEnabledFeatureActive"));
        Element Janrain = new Element("Janrain", By.Id("EnabledFeatures_4__IsEnabledFeatureActive"));
        Element Prop65_Wishlist = new Element("Prop65.Wishlist", By.Id("EnabledFeatures_5__IsEnabledFeatureActive"));
        Element WebAnalytics = new Element("WebAnalytics", By.Id("EnabledFeatures_6__IsEnabledFeatureActive"));
        Element PageLocation = new Element("PageLocation", By.Id("EnabledFeatures_7__IsEnabledFeatureActive"));
        Element Monetate = new Element("Monetate", By.Id("EnabledFeatures_8__IsEnabledFeatureActive"));
        Element EmailLightbox = new Element("EmailLightbox", By.Id("EnabledFeatures_9__IsEnabledFeatureActive"));
        Element HeaderFooterDeptRedesign = new Element("HeaderFooterDeptRedesign", By.Id("EnabledFeatures_10__IsEnabledFeatureActive"));
        Element HeaderFooterDeptRedesign_HeaderFooter = new Element("HeaderFooterDeptRedesign.HeaderFooter", By.Id("EnabledFeatures_11__IsEnabledFeatureActive"));
        Element HeaderFooterDeptRedesign_CertonaBlocks = new Element("HeaderFooterDeptRedesign.CertonaBlocks", By.Id("EnabledFeatures_12__IsEnabledFeatureActive"));
        Element HeaderFooterDeptRedesign_BrandSelector = new Element("HeaderFooterDeptRedesign.BrandSelector", By.Id("EnabledFeatures_13__IsEnabledFeatureActive"));
        Element HeaderFooterDeptRedesign_DepartmentMapper = new Element("HeaderFooterDeptRedesign.DepartmentMapper", By.Id("EnabledFeatures_14__IsEnabledFeatureActive"));
        Element BloomreachPixel = new Element("BloomreachPixel", By.Id("EnabledFeatures_15__IsEnabledFeatureActive"));
        Element BloomreachWidgets = new Element("BloomreachWidgets", By.Id("EnabledFeatures_16__IsEnabledFeatureActive"));
        Element BloomreachThematicPage = new Element("BloomreachThematicPage", By.Id("EnabledFeatures_17__IsEnabledFeatureActive"));
        Element ListPageContentSpots = new Element("ListPageContentSpots", By.Id("EnabledFeatures_18__IsEnabledFeatureActive"));
        Element PricingDisplayRedesign_PCart = new Element("PricingDisplayRedesign.PCart", By.Id("EnabledFeatures_19__IsEnabledFeatureActive"));
        Element PricingDisplayRedesign_PDP = new Element("PricingDisplayRedesign.PDP", By.Id("EnabledFeatures_20__IsEnabledFeatureActive"));
        Element PricingDisplayRedesign_Cart = new Element("PricingDisplayRedesign.Cart", By.Id("EnabledFeatures_21__IsEnabledFeatureActive"));
        Element FeaturedProduct = new Element("FeaturedProduct", By.Id("EnabledFeatures_22__IsEnabledFeatureActive"));
        Element MerchandisedPage = new Element("MerchandisedPage", By.Id("EnabledFeatures_23__IsEnabledFeatureActive"));
        Element AlternateImages = new Element("AlternateImages", By.Id("EnabledFeatures_24__IsEnabledFeatureActive"));
        Element ListPageRedesign = new Element("ListPageRedesign", By.Id("EnabledFeatures_25__IsEnabledFeatureActive"));
        Element PDPRedesign = new Element("PDPRedesign", By.Id("EnabledFeatures_26__IsEnabledFeatureActive"));

        Element Submit_Button = new Element("Submit_Button", By.XPath("//body/div/form/input[2]"));

        List<Element> EnabledFeatures;
        

        public eBags_EnabledFeatures()
        {
            EnabledFeatures = new List<Element>();
            EnabledFeatures.Add(FaceBook);
            EnabledFeatures.Add(Facebook_Logging);
            EnabledFeatures.Add(Facebook_Sharing);
            EnabledFeatures.Add(Pinterest);
            EnabledFeatures.Add(Janrain);
            EnabledFeatures.Add(Prop65_Wishlist);
            EnabledFeatures.Add(WebAnalytics);
            EnabledFeatures.Add(PageLocation);
            EnabledFeatures.Add(Monetate);
            EnabledFeatures.Add(EmailLightbox);
            EnabledFeatures.Add(HeaderFooterDeptRedesign);
            EnabledFeatures.Add(HeaderFooterDeptRedesign_HeaderFooter);
            EnabledFeatures.Add(HeaderFooterDeptRedesign_CertonaBlocks);
            EnabledFeatures.Add(HeaderFooterDeptRedesign_BrandSelector);
            EnabledFeatures.Add(HeaderFooterDeptRedesign_DepartmentMapper);
            EnabledFeatures.Add(BloomreachPixel);
            EnabledFeatures.Add(BloomreachWidgets);
            EnabledFeatures.Add(BloomreachThematicPage);
            EnabledFeatures.Add(ListPageContentSpots);
            EnabledFeatures.Add(PricingDisplayRedesign_PCart);
            EnabledFeatures.Add(FeaturedProduct);
            EnabledFeatures.Add(MerchandisedPage);
            EnabledFeatures.Add(AlternateImages);
            EnabledFeatures.Add(ListPageRedesign);
            EnabledFeatures.Add(PDPRedesign);

        }

        public eBags_EnabledFeatures FeatureSelector(int FeatureID, bool Enabled)
        {
            try
            {
                if (Enabled)
                {
                    if (EnabledFeatures[FeatureID].GetAttribute("checked") == null)
                    {
                        EnabledFeatures[FeatureID].Click();
                    }
                    //string derp = EnabledFeatures[FeatureID].GetAttribute("checked");
                }
                if(!Enabled)
                {
                    if (EnabledFeatures[FeatureID].GetAttribute("checked") == "true")
                    {
                        EnabledFeatures[FeatureID].Click();
                    }
                    
                }
            }
            catch (Exception e)
            {
                
            }

            Submit_Button.WaitUntilVisible().Click();
            return new eBags_EnabledFeatures();
        }





        public override void WaitForElements()
        {
            //foreach (Element ele in EnabledFeatures)
            //{
            //    ele.WaitUntilVisible();
            //}
        }
    }
}
