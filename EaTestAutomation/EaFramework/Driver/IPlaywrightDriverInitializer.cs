using EaFramework.Config;
using Microsoft.Playwright;

namespace EaFramework.Driver;

public interface IPlaywrightDriverInitializer
{
    Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings);
    Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings);
    Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings);
    Task<IBrowser> GetWebKitDriverAsync(TestSettings testSettings);
}