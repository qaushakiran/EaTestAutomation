using System;
using EaFramework.Config;
using EaFramework.Driver;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace EaSpecflowTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly TestSettings _testSettings;
        private readonly Task<IPage> _page;

        public Hooks(IPlaywrightDriver playwrightDriver, TestSettings testSettings)
        {
            _testSettings = testSettings;
            _page = playwrightDriver.Page;
        }
        
        
        [BeforeScenario]
        public async Task BeforeScenario()
        {
            await (await _page).GotoAsync(_testSettings.ApplicationUrl);
        }
    }
}