using FluentAssertions;
using NUnit;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Adapter;
using System;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V85.DOM;

namespace Assessment_SP
{
    public class Actions : Common
    {
        #region Locators
        public string titleHomepageLocator = "xpath=//img[@title = 'Spanish Point Technologies']";
        public string AcceptAllCookiesButtonLocator = "id=wt-cli-accept-btn";
        public string TopMenuLocator = "xpath=//ul[@class = 'navbar-nav ml-auto']";
        public string TopMenuOptionsTextLocator = "xpath=//ul[@class = 'navbar-nav ml-auto']/li/a/span";
        public string SubMenuOptionsTextLocator = "xpath=//li[@class = 'menu-item menu-item-type-post_type menu-item-object-page']/a/span";
        public string SectionTitle = "xpath=//h2[text() = '{0}']";
        public string SectionsOptionsTextLocator = "xpath=//ul[@class = 'vc_tta-tabs-list']/li/a/span";
        public string SectionLocator = "xpath=//div[@class = 'vc_tta-panels-container']";
        public string SectionHeaderTextLocator = "xpath=//div[@class = 'vc_tta-panels-container']/descendant::div[@class='vc_tta-panel vc_active']/descendant::div[@class = 'wpb_wrapper']/descendant::h3";
        public string SectionParagraphStatingTextLocator = "xpath=//div[@class = 'vc_tta-panels-container']/descendant::div[@class='vc_tta-panel vc_active']/descendant::div[@class = 'wpb_wrapper'][2]/descendant::strong";
        #endregion

        public bool NavigateTo(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();
            if (IsElementVisible(titleHomepageLocator, 2))
            {
                return true;
            }
            return false;
        }

        public void AcceptAllCookies()
        {
            if (IsElementVisible(AcceptAllCookiesButtonLocator, 1))
            {
                FindElement(ByLocator(AcceptAllCookiesButtonLocator)).Click();
            }
        }

        public void ClickTopMenuOption(string menuOption)
        {
            if (!IsElementVisible(TopMenuLocator, 1))
            {
                Assert.Inconclusive("Top menu not visible in the page");
            }
            IList<IWebElement> TopMenuOptionsTextList = GetElements(TopMenuOptionsTextLocator, 2);
            if (!ClickSpecificOptioninAList(TopMenuOptionsTextList, menuOption))
            {
                Assert.Inconclusive($"{menuOption} is not in top menu options");
            }
        }

        public void ClickTopSubmenuOption(string submenuOption)
        {
            IList<IWebElement> SubMenuOptionsTextList = GetElements(SubMenuOptionsTextLocator, 2);
            if (!ClickSpecificOptioninAList(SubMenuOptionsTextList, submenuOption))
            {
                Assert.Inconclusive($"{submenuOption} is not in submenu options");
            }
        }

        public bool SectionVisible(string Section)
        {
            if (IsElementVisible(string.Format(SectionTitle, Section), 3))
            {
                return true;
            }
            return false;
        }

        public void ClickSectionOption(string OptioninSection)
        {
            IList<IWebElement> SubMenuOptionsTextList = GetElements(SectionsOptionsTextLocator, 1);
            if (!ClickSpecificOptioninAList(SubMenuOptionsTextList, OptioninSection))
            {
                Assert.Inconclusive($"{OptioninSection} is not in Section options");
            }
        }

        public string GetActualPanelHeaderText()
        {
            ScrollElementIntoView(SectionLocator, 2);
            return GetElementText(SectionHeaderTextLocator, 1);
        }

        public string GetActualParagraphStartingText(int expectedParagraphStartingTextLength)
        {
            ScrollElementIntoView(SectionLocator);
            return GetElementText(SectionParagraphStatingTextLocator).Substring(0, expectedParagraphStartingTextLength);
        }
    }
}
