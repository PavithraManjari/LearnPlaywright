using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UnitTest
{
	public class UnitTest2 
	{
		public static IBrowserContext browserContext { get; set; }
		public static IPage Page;
		public static IPage Page1;
		[Test]
		public async Task SecondTest()
		{/*Below Performed cookie-based authentication using two browser contexts.
		  Note:The stored Json file cannot be used for second test.That stored cookie will expire after the logout.*/
			var playwright = await Playwright.CreateAsync();
			var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Channel = "chrome", Headless = false, Args = new[] { "--start-maximized" }, SlowMo = 1000 }).ConfigureAwait(false);
			var contextOptions = new BrowserNewContextOptions()
			{

				ViewportSize = ViewportSize.NoViewport

			};
			browserContext = await browser.NewContextAsync(contextOptions);
			
			Page = await browserContext.NewPageAsync();
			await Page.GotoAsync("https://slowautocx.test2016.com");
			await Page.Locator("xpath=//span[text()='Peppermint CX']").ClickAsync();
			await Page.Locator("xpath=//input[@id='userNameInput']").FillAsync("accountant1@testhost.com");
			await Page.Locator("xpath=//input[@id='passwordInput']").FillAsync("Password1");
			await Page.Locator("xpath=//span[@id='submitButton']").ClickAsync();
			await Page.Context.StorageStateAsync(new BrowserContextStorageStateOptions() { Path = "./LoginAuth.json"});
			var context = await browser.NewContextAsync(new()
			{
				StorageStatePath = "./LoginAuth.json",
				ViewportSize = ViewportSize.NoViewport
			});
			//var context = await browser.NewContextAsync();
			Page1 = await context.NewPageAsync();
			await Page1.GotoAsync("https://slowautocx.test2016.com");

		}
	}
}
