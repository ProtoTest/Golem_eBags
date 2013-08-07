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
        //Store feature settings here for use in page objects
        Element Submit_Button = new Element("Submit_Button", By.XPath("//body/div/form/input[2]"));
        //This will be used to store features
        List<Element> EnabledFeatures;
        

        public eBags_EnabledFeatures()
        {
             
            //get's all the checkboxes on the page
            List<IWebElement> checkboxes = driver.FindElements(By.XPath("//input[@type='checkbox']")).ToList();
            EnabledFeatures = new List<Element>();

            //gather all the checkboxes and build a Golem.Element for them
            for (int i = 0; i < checkboxes.Count; i++)
            {
                string labelPath = string.Format("//body/div/form/div[{0}]/label", i + 1);
                IWebElement thing = driver.FindElement(By.XPath(labelPath));
                string thingid = checkboxes[i].GetAttribute("id");                
                Element feature = new Element(thing.Text, By.Id(thingid));
                EnabledFeatures.Add(feature);
            }
            
            //This will get all the statuses of the checkboxes and build a feature for each with it's status for later page objects to referance
            for (int i = 0; i < EnabledFeatures.Count; i++)
            {
                bool onOff;
                if (EnabledFeatures[i].GetAttribute("checked") == null)
                {
                    onOff = false;
                }
                else //(EnabledFeatures[i].GetAttribute("checked") == "true")
                {
                    onOff = true;
                }                
                //TestConfig.FeatureStatus(EnabledFeatures[i].name, i, enabled);
                eBags_Feature ebag = new eBags_Feature();
                ebag.FeatureName = EnabledFeatures[i].name;
                ebag.FeatureID = i;
                ebag.enabled = onOff;
                eBags_TestConfiguration.FeatureStatus(ebag);

            }

        }

        //This function will be used to turn on or off specific features
        public eBags_EnabledFeatures FeatureSelector(int FeatureID, bool Enabled)
        {
            try
            {
                if (Enabled)
                {
                    if (EnabledFeatures[FeatureID].GetAttribute("checked") == null)
                    {
                        EnabledFeatures[FeatureID].Click();
                        eBags_TestConfiguration.Update(FeatureID, Enabled);
                    }
                    
                }
                if(!Enabled)
                {
                    if (EnabledFeatures[FeatureID].GetAttribute("checked") == "true")
                    {
                        EnabledFeatures[FeatureID].Click();
                        eBags_TestConfiguration.Update(FeatureID, Enabled);
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
