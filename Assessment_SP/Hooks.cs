using TechTalk.SpecFlow;

namespace Assessment_SP
{
    [Binding]
    public class Hooks : Common
    {
        [AfterFeature]
        public static void TearDown()
        {
            CloseChrome();
        }
    }

}
