using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Assessment_SP.Steps
{
    [Binding]
    public class Assessment_SP : Actions
    {
        private readonly FeatureContext _featureContext;

        public Assessment_SP(FeatureContext featurecontext)
        {
            _featureContext = featurecontext;
        }

        [Given(@"the user has navigated to '(.*)'")]
        public void GivenTheUserHasNavigatedTo(string URL)
        {
            if (!_featureContext.ContainsKey("navigated"))
            {
                if (NavigateTo(URL))
                {
                    if (!_featureContext.ContainsKey("navigated"))
                    {
                        _featureContext.Add("navigated", true);
                    }
                    else
                    {
                        _featureContext["navigated"] = true;
                    }
                    AcceptAllCookies();
                    Console.WriteLine("Navigation OK");
                }
                else
                {
                    Assert.Inconclusive("Web page not correctly displayed");
                }
            }
        }

        [Given(@"the user expands '(.*)' option in top menu")]
        public void GivenTheUserExpandsOptionInTopMenu(string menuOption)
        {
            ClickTopMenuOption(menuOption);
        }

        [Given(@"the user selects '(.*)' option in the menu displayed")]
        public void GivenTheUserSelectsOptionInTheMenuDisplayed(string submenuOption)
        {
            ClickTopSubmenuOption(submenuOption);
        }

        [When(@"the user selects '(.*)' under the '(.*)' section")]
        public void WhenTheUserSelectsUnderTheSection(string OptioninSection, string Section)
        {
            if (!SectionVisible(Section))
            {
                Assert.Inconclusive($"The Section {Section} is not visible");
            }
            ClickSectionOption(OptioninSection);
        }

        [Then(@"the displayed panel has the a header with the text '(.*)'")]
        public void ThenTheDisplayedPanelHasTheAHeaderWithTheText(string expectedPanelHeaderText)
        {
            Assert.That(GetActualPanelHeaderText(), Is.EqualTo(expectedPanelHeaderText), "Expected and Actual title differs");
        }

        [Then(@"the displayed paragraph starts with the text '(.*)'")]
        public void ThenTheDisplayedParagraphStartsWithTheText(string expectedParagraphStartingText)
        {
            int expectedParagraphStartingTextLength = expectedParagraphStartingText.Length;
            Assert.That(GetActualParagraphStartingText(expectedParagraphStartingTextLength), Is.EqualTo(expectedParagraphStartingText), "Actual paragraph starts is not contained in the Actual title differs");
        }
    }
}