using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace UnitTest
{
	public class UnitTest3
	{
		public static IBrowserContext browserContext { get; set; }
		public static IPage Page;
	
		[Test]
		public async Task ThirdTest()
		{
			var playwright = await Playwright.CreateAsync();
			var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Channel = "chrome", Headless = false, Args = new[] { "--start-maximized" }, SlowMo = 1000 }).ConfigureAwait(false);
			var contextOptions = new BrowserNewContextOptions()
			{

				ViewportSize = ViewportSize.NoViewport

			};
			browserContext = await browser.NewContextAsync(contextOptions);
			
			
			var storedCookiesJson = File.ReadAllText("./LoginAuth.txt");
			var storedCookies = JObject.Parse(storedCookiesJson).ToString();
			Environment.SetEnvironmentVariable("SESSION_STORAGE", storedCookies);

		
			var loadedSessionStorage = Environment.GetEnvironmentVariable("SESSION_STORAGE");
			await browserContext.AddInitScriptAsync(@"(storage => {
    if (window.location.hostname === 'example.com') {
      const entries = JSON.parse(storage);
      for (const [key, value] of Object.entries(entries)) {
        window.sessionStorage.setItem(key, value);
      }
    }
  })('" + loadedSessionStorage + "')");
			Page = await browserContext.NewPageAsync();
			await Page.GotoAsync("https://slowautocx.test2016.com");
			
		}
	}
}
