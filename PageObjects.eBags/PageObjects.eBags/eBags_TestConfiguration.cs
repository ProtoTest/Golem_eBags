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
        private  const int SUPER_WIDE = 1183;
        private  const int WIDE = 943;  //Shop all departments button shows up -ebags brand removed
        private  const int TABLET = 750; //uppermax
        private  const int MOBILE = 463;

        private static bool _super_wide = false;
        private static bool _wide = false;
        private static bool _tablet = false;
        private static bool _mobile = false;

        private static List<eBags_Feature> eBags_web_Features;
        private static int browserWidth = 0;
        private static int browserHeight = 0;
        private static string navURL = "NOT SET";

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

        public static void setBrowserDimensions(int width, int height)
        {
            browserWidth = width;
            browserHeight = height;
            setFlags();
        }
        private static void setFlags()
        {
            if (browserWidth >= SUPER_WIDE)
            {
                _super_wide = true;
            }
            if ((browserWidth >= WIDE) && (browserWidth < SUPER_WIDE))
            {
                _wide = true;
            }
            if ((browserWidth >= TABLET) && (browserWidth < WIDE))
            {
                _tablet = true;
            }
            if (browserWidth <= MOBILE)
            {
                _mobile = true;
            }
        }

        public static int browWidth()
        {
            return browserWidth;
        }
        public static int browHeight()
        {
            return browserHeight;
        }
        public static void setNavURL(string url)
        {
            navURL = url;
        }
        public static string getNavURL()
        {
            return navURL;
        }
        public static bool isSuperWide()
        {
            return _super_wide;
        }
        public static bool isWide()
        {
            return _wide;
        }
        public static bool isTablet()
        {
            return _tablet;
        }
        public static bool isMobile()
        {
            return _mobile;
        }


        


    }
}
