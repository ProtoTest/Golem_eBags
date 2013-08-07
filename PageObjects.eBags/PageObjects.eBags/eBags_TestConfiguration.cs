using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageObjects.eBags
{
    public static class eBags_TestConfiguration
    {
        /* This class will be used to determine enabled features at the start of the test. 
         * PageObjects will use this to determine the configuration of the test and which Elements will be displayed and which Elements 
         * won't.
         * There should be a value for all the features available on the site, however right now we're concentrating on HeaderFooter features
         */


        private static List<eBags_Feature> eBags_web_Features;

        public static void FeatureStatus(eBags_Feature feature)
        {
            if (eBags_web_Features != null)
            {
                eBags_web_Features.Add(feature);
            }
            else
            {
                eBags_web_Features = new List<eBags_Feature>();
                eBags_web_Features.Add(feature);
            }

        }

        //These two functions will check if the feature is enabled
        public static bool Enabled(int fID)
        {
            return eBags_web_Features[fID].enabled;
        }
        public static bool Enabled(string fName)
        {
            bool onOff;
            eBags_Feature feature = eBags_web_Features.Find
                (
                    delegate(eBags_Feature ef)
                    {
                        return ef.FeatureName == fName;
                    }
                );
            if(feature != null)
            {
                onOff = feature.enabled;
            }
            else
            {
                onOff = false;
            }

            return onOff;            
        }

        //Update the status of the feature should only be called form the eBags_EnabledFeatures PageObject
        public static void Update(int fid, bool state)
        {
            eBags_web_Features[fid].enabled = state;
        }


        


    }
}
