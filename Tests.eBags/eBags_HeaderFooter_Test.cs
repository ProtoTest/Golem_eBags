﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; //might want to take this out later
using Golem.Framework;
using PageObjects.eBags;
using MbUnit.Framework;
using OpenQA.Selenium;

namespace Tests.eBags
{
    public class eBags_HeaderFooter_Test : TestBaseClass
    {
        [Test]
        public void TestSplit()
        {
            eBags_SpitTests.OpenSplit("http://stintdev.ebags.com/internal/SplitTests", 460).SetupSplit('B', 'B', 'A').ClickEnabledFeatures().ClickHomePage().checkHeader();
            Thread.Sleep(4000);
        }

    }
}
