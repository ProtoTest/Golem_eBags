using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Golem.Framework;
using OpenQA.Selenium;

namespace PageObjects.eBags
{
    public class eBags_TabHeaderFooter : BasePageObject
    {
        /*There needs to be a seperate page object based on enabled features.  For example the split A header and split B header 
         * will both be the same depending on the features enabled (headerfooter Features)  The test is to make sure that both splits 
         * work the same way with features on and features off.
         */



        public override void WaitForElements()
        {
            
        }
    }
}
